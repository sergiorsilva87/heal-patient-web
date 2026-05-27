namespace Heal.Patient.Web.Services;

public static class MockData
{
    public sealed record ExamItem(
        string Protocol,
        string Type,
        DateOnly ExamDate,
        DateOnly ReportDate,
        string Procedure,
        string AccessNumber,
        string PerformingDoctor,
        string PerformingDoctorCrm,
        string PerformingDoctorCrmUf,
        string RequestingDoctor,
        string? RequestingDoctorCrm,
        string? RequestingDoctorCrmUf,
        string UnitName,
        string RadiologyTechnicianName,
        string RadiologyTechnicianRegistry,
        string RadiologyTechnicianRegistryUf,
        string StatusCode
    )
    {
        public string Date => ExamDate.ToString("dd/MM/yyyy");
        public string ReportDateText => ReportDate.ToString("dd/MM/yyyy");
    }

    public static class Patient
    {
        public const string Name = "Maria Aparecida da Silva";
        public const string PatientId = "PAT-000245981";
        public const string BirthDate = "15/03/1975";
        public const string CpfMasked = "***.456.***-12";
    }

    public static readonly ExamItem[] Exams =
    [
        new(
            "2024001234",
            "Ressonancia Magnetica de Cranio",
            new DateOnly(2026, 5, 22),
            new DateOnly(2026, 5, 23),
            "Ressonancia magnetica do cranio sem contraste",
            "ACC-00231077",
            "Dr. Carlos Eduardo Mendes",
            "CRM 123456",
            "SP",
            "Dr. Marcelo Tavares",
            null,
            null,
            "Unidade Centro",
            "Tec. Julia Nascimento",
            "CRTR 004587",
            "SP",
            "ready-report"
        ),
        new(
            "2024001288",
            "Tomografia Computadorizada de Torax",
            new DateOnly(2026, 5, 18),
            new DateOnly(2026, 5, 19),
            "Tomografia computadorizada de torax",
            "ACC-00229815",
            "Dra. Ana Paula Monteiro",
            "CRM 998877",
            "SP",
            "Dr. Leandro Peixoto",
            null,
            null,
            "Unidade Norte",
            "Tec. Rafael Moreira",
            "CRTR 003912",
            "SP",
            "images-available"
        ),
        new(
            "2024001321",
            "Ultrassonografia Abdome Total",
            new DateOnly(2026, 5, 14),
            new DateOnly(2026, 5, 15),
            "Ultrassonografia de abdomen total",
            "ACC-00228004",
            "Dr. Renato Lopes",
            "CRM 456321",
            "SP",
            "Dra. Fernanda Rios",
            null,
            null,
            "Unidade Leste",
            "Tec. Bruno Matias",
            "CRTR 002744",
            "SP",
            "processing"
        )
    ];

    public static class Exam
    {
        public static string Protocol => Exams[0].Protocol;
        public static string Type => Exams[0].Type;
        public static string Date => Exams[0].Date;
        public static string ReportDate => Exams[0].ReportDateText;
        public static string Procedure => Exams[0].Procedure;
        public static string AccessNumber => Exams[0].AccessNumber;
        public static string RequestDoctor => Exams[0].RequestingDoctor;
        public static string PerformingDoctor => Exams[0].PerformingDoctor;
        public static string PerformingDoctorCrm => Exams[0].PerformingDoctorCrm;
        public static string PerformingDoctorCrmUf => Exams[0].PerformingDoctorCrmUf;
        public static string RequestingDoctor => Exams[0].RequestingDoctor;
        public static string? RequestingDoctorCrm => Exams[0].RequestingDoctorCrm;
        public static string? RequestingDoctorCrmUf => Exams[0].RequestingDoctorCrmUf;
        public static string UnitName => Exams[0].UnitName;
        public static string RadiologyTechnicianName => Exams[0].RadiologyTechnicianName;
        public static string RadiologyTechnicianRegistry => Exams[0].RadiologyTechnicianRegistry;
        public static string RadiologyTechnicianRegistryUf => Exams[0].RadiologyTechnicianRegistryUf;
        public static string Status => Exams[0].StatusCode;
    }

    public const string ReportBody = @"
<p><strong>Tecnica:</strong> Exame realizado em equipamento de 1.5T, com sequencias multiplanares.</p>
<p><strong>Achados:</strong> Nao ha evidencias de lesoes expansivas, restricao a difusao ou hemorragia aguda.</p>
<p><strong>Conclusao:</strong> Exame dentro dos limites da normalidade para a faixa etaria.</p>";

    public const string AddendumBody = @"
<p>Adendo: correlacionar com quadro clinico e exames laboratoriais previos, a criterio medico.</p>";

    public static readonly (string Question, string Answer)[] Faq =
    [
        (
            "Como acesso meu exame?",
            "Informe o numero de protocolo e data de nascimento na tela inicial."
        ),
        (
            "Nao tenho numero de protocolo. E agora?",
            "Solicite um codigo de acesso na recepcao da clinica e entre com CPF + codigo."
        ),
        (
            "Posso baixar o laudo em PDF?",
            "Sim. Na area do exame, clique em 'Baixar PDF'."
        )
    ];

    public const string QrLink = "https://clinica-abc.whitemage.com.br/patient/exam/mock-token-123";
}
