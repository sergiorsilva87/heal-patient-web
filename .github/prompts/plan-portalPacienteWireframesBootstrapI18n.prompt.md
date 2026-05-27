# Plan: Portal do Paciente — Wireframes com Bootstrap + i18n

## TL;DR

Criar ~15 novas páginas Razor + ~25 arquivos (recursos, shared, serviços mock) que cobrem todos os fluxos descritos no README.md. Sem regras de negócio, sem banco — tudo mockado. Bootstrap 5.3.8 via CDN. i18n via `.resx` (PT-BR padrão, ES, EN). Layout clean white-label com troca de idioma no header.

---

## Fase 1 — Infraestrutura (base para tudo)

1. **`Program.cs`** — adicionar `AddLocalization()`, `AddSession()`, `UseRequestLocalization()` com default `pt-BR`, suporte a `pt-BR / es / en`. CookieRequestCultureProvider incluso por padrão.

2. **`Resources/SharedResource.cs`** — classe marcadora vazia no namespace `Heal.Patient.Web.Resources`.

3. **`Resources/SharedResource.resx`** — strings PT-BR (default/fallback).

4. **`Resources/SharedResource.en.resx`** — strings EN.

5. **`Resources/SharedResource.es.resx`** — strings ES.

6. **`Pages/_ViewImports.cshtml`** — adicionar `@inject` do `IStringLocalizer<SharedResource>` como `L` (disponível em todas as views).

7. **`Pages/Culture.cshtml.cs`** — OnGet(culture, returnUrl): seta cookie `.AspNetCore.Culture` + `LocalRedirect`. Sem .cshtml (não tem body).

8. **`wwwroot/css/portal.css`** — variáveis CSS (`--clinic-primary`, `--clinic-secondary`) + overrides Bootstrap mínimos.

---

## Fase 2 — Layout e partials (depende de Fase 1)

9. **`Pages/Shared/_Layout.cshtml`** — substituir Bootstrap local por CDN 5.3.8. Header com: logo da clínica (mock SVG), nome da clínica, dropdown idioma (PT-BR / Español / English), link Ajuda. Footer com links Termos e Privacidade. Sem navbar de navegação interna (contextual por página).

10. **`Pages/Shared/_CookieConsentPartial.cshtml`** — banner fixo no bottom: texto LGPD localizado, links Termos e Privacidade, botão Aceitar. Controle via `localStorage` (JS puro). Inserido no `_Layout.cshtml`.

---

## Fase 3 — Mock data service (depende de Fase 1)

11. **`Services/MockData.cs`** — classe estática com constantes:
    - `ClinicInfo` (nome, cor, slogan)
    - `ExamInfo` (accession number, paciente, data, modalidade, médico solicitante)
    - `ReportHtml` (texto de laudo simulado)
    - `AddendumHtml` (adendo simulado)
    - Lista de FAQs para Help
    - QR Code URL fake

---

## Fase 4 — Páginas de acesso (depende de Fases 1-3)

12. **`Pages/Index.cshtml` + `.cs`** — Login. Dois tabs Bootstrap:
    - Tab 1 "Número de protocolo": campos Accession Number + Data de Nascimento + botão Acessar
    - Tab 2 "CPF e código": campos CPF + Código de acesso + botão Acessar
    - OnPost: qualquer dado → redireciona para `/exam` (mock)
    - Layout: sem header nav de exame, apenas logo centralizado + idioma

---

## Fase 5 — Área do Exame (depende de Fase 4)

13. **`Pages/Exam/Index.cshtml` + `.cs`** — Dashboard do exame. Cards com:
    - Info do paciente (nome, data nascimento) + info do exame (tipo, data, médico)
    - Botões/cards de ação: Ver Laudo, Ver Imagens, Baixar PDF, QR Code, Imprimir Imagens
    - Badge "Resultado disponível"
    - Link "Sair" no header

14. **`Pages/Exam/Report.cshtml` + `.cs`** — Visualizador do laudo:
    - Cabeçalho com dados do exame
    - Corpo do laudo (HTML mockado, read-only)
    - Seção "Adendo" (expandível, com badge "Novo")
    - Badge de assinatura ICP-Brasil (mockado)
    - Botão "Baixar PDF"

15. **`Pages/Exam/Images.cshtml` + `.cs`** — Visualizador DICOM (mocked):
    - Placeholder cinza simulando o DWV (div com ícone + texto "Carregando imagens...")
    - Toolbar mockada (scroll, zoom, contraste, pan, imprimir)
    - Nota "Powered by DWV"

16. **`Pages/Exam/QrCode.cshtml` + `.cs`** — QR Code:
    - QR code mockado (imagem placeholder ou SVG gerado inline)
    - Texto explicativo
    - Botão copiar link
    - Prazo de validade

17. **`Pages/Exam/ColdStorage.cshtml` + `.cs`** — Status de recuperação de laudo (cold storage):
    - Timeline de status: "Solicitado" → "Em preparação" → "Pronto"
    - Mensagem amigável sem jargão técnico
    - Opção de notificação por e-mail quando pronto

---

## Fase 6 — Páginas institucionais (paralelo com Fase 5)

18. **`Pages/Terms.cshtml` + `.cs`** — Termos e Condições:
    - Conteúdo mockado estruturado (seções: objeto, uso, privacidade, responsabilidade etc.)
    - Localizado

19. **`Pages/Privacy.cshtml` + `.cs`** — Política de Privacidade:
    - Conteúdo mockado com seções LGPD (base legal, dados coletados, retenção, direitos)
    - Localizado (substituir conteúdo placeholder atual)

20. **`Pages/Help.cshtml` + `.cs`** — Central de Ajuda:
    - Accordion com FAQs mockadas
    - Seção "Contato da clínica" (telefone/email mockados)
    - Seção "Como acessar meu exame" (tutorial em steps)

---

## Arquivos modificados

- `Heal.Patient.Web/Program.cs`
- `Heal.Patient.Web/Pages/Shared/_Layout.cshtml`
- `Heal.Patient.Web/Pages/_ViewImports.cshtml`
- `Heal.Patient.Web/Pages/Index.cshtml` + `.cs`
- `Heal.Patient.Web/Pages/Privacy.cshtml` + `.cs`

## Arquivos criados

- `Heal.Patient.Web/Resources/SharedResource.cs`
- `Heal.Patient.Web/Resources/SharedResource.resx` (PT-BR)
- `Heal.Patient.Web/Resources/SharedResource.en.resx`
- `Heal.Patient.Web/Resources/SharedResource.es.resx`
- `Heal.Patient.Web/Services/MockData.cs`
- `Heal.Patient.Web/Pages/Culture.cshtml.cs`
- `Heal.Patient.Web/Pages/Shared/_CookieConsentPartial.cshtml`
- `Heal.Patient.Web/Pages/Exam/Index.cshtml` + `.cs`
- `Heal.Patient.Web/Pages/Exam/Report.cshtml` + `.cs`
- `Heal.Patient.Web/Pages/Exam/Images.cshtml` + `.cs`
- `Heal.Patient.Web/Pages/Exam/QrCode.cshtml` + `.cs`
- `Heal.Patient.Web/Pages/Exam/ColdStorage.cshtml` + `.cs`
- `Heal.Patient.Web/Pages/Terms.cshtml` + `.cs`
- `Heal.Patient.Web/Pages/Help.cshtml` + `.cs`
- `Heal.Patient.Web/wwwroot/css/portal.css`

---

## Verification

1. `dotnet build` sem erros
2. `dotnet run` → navegar em `http://localhost:5000`
3. Login com qualquer dado → redireciona para `/exam`
4. Trocar idioma → URL e textos mudam (PT-BR/ES/EN)
5. Cookie banner aparece na primeira visita; desaparece após aceite
6. Todos os links de navegação interna funcionam sem 404

---

## Decisões

- Bootstrap 5.3.8 CDN (como pedido); remover referência local do bootstrap
- jQuery mantido localmente (já presente, usado pelos tag helpers)
- Localizer injetado como `L` via `_ViewImports` para todas as views
- Mock session: login faz redirect direto, sem cookie de sessão real
- `Culture.cshtml.cs` sem body HTML (não precisa de .cshtml)
- ColdStorage = página separada (acessada via botão "Baixar PDF" quando mock indicar cold storage)
- QR Code mockado com image placeholder (sem biblioteca externa)
