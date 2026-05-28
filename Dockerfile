# syntax=docker/dockerfile:1

# ─── Stage 1: restore ─────────────────────────────────────────────────────────
# Copy only project descriptors first — this layer stays cached as long as
# no dependency changes. NuGet packages are stored in a BuildKit cache mount
# (never written into any image layer).
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS restore

WORKDIR /src

COPY Heal.Patient.slnx ./
COPY Heal.Patient.Web/Heal.Patient.Web.csproj            Heal.Patient.Web/
COPY Heal.Patient.Web.Test/Heal.Patient.Web.Test.csproj  Heal.Patient.Web.Test/

RUN --mount=type=cache,target=/root/.nuget/packages \
    dotnet restore Heal.Patient.slnx

# ─── Stage 2: build & test ────────────────────────────────────────────────────
FROM restore AS build

COPY . .

RUN dotnet build Heal.Patient.slnx -c Release --no-restore -nologo -v q

RUN dotnet test  Heal.Patient.slnx -c Release --no-build --no-restore -nologo

# ─── Stage 3: publish ─────────────────────────────────────────────────────────
FROM build AS publish

RUN dotnet publish Heal.Patient.Web/Heal.Patient.Web.csproj \
      -c Release --no-build -o /app/publish \
      /p:UseAppHost=false

# ─── Stage 4: runtime image ───────────────────────────────────────────────────
# aspnet:10.0 is Debian-slim — includes ICU/globalization needed for pt-BR/es/en.
# The base image already ships a non-root user "app" (UID 1654) and sets
# ASPNETCORE_HTTP_PORTS=8080 by default.
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

COPY --from=publish --chown=app:app /app/publish .

USER app

EXPOSE 8080

ENTRYPOINT ["dotnet", "Heal.Patient.Web.dll"]
