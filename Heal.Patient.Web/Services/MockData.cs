namespace Heal.Patient.Web.Services;

public static class MockData
{
    public sealed record AddendumItem(
        DateOnly Date,
        string PhysicianName,
        string PhysicianCrm,
        string PhysicianCrmUf,
        string Body
    )
    {
        public string DateText => Date.ToString("dd/MM/yyyy");
    }

    public sealed record ExamAttachmentItem(
        string Id,
        string ExamProtocol,
        DateTimeOffset AttachedAt,
        string FileName,
        string ContentType,
        string UploadedByName,
        string UploadedByRole
    );

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
        ),
        new(
            "2024001330",
            "Mamografia Bilateral",
            new DateOnly(2026, 5, 11),
            new DateOnly(2026, 5, 12),
            "Mamografia bilateral digital",
            "ACC-00227150",
            "Dra. Renata Vieira",
            "CRM 774412",
            "SP",
            "Dra. Camila Duarte",
            null,
            null,
            "Unidade Centro",
            "Tec. Paula Nunes",
            "CRTR 008144",
            "SP",
            "ready-report"
        ),
        new(
            "2024001349",
            "Raio-X de Torax",
            new DateOnly(2026, 5, 9),
            new DateOnly(2026, 5, 9),
            "Radiografia de torax em PA e perfil",
            "ACC-00226411",
            "Dr. Sergio Bastos",
            "CRM 119944",
            "SP",
            "Dr. Paulo Gimenes",
            null,
            null,
            "Unidade Sul",
            "Tec. Roberta Lima",
            "CRTR 009201",
            "SP",
            "images-available"
        ),
        new(
            "2024001363",
            "Densitometria Ossea",
            new DateOnly(2026, 5, 7),
            new DateOnly(2026, 5, 8),
            "Densitometria ossea coluna lombar e femur",
            "ACC-00225388",
            "Dr. Tiago Nery",
            "CRM 667788",
            "SP",
            "Dra. Marina Alves",
            null,
            null,
            "Unidade Centro",
            "Tec. Bianca Faria",
            "CRTR 001822",
            "SP",
            "ready-report"
        ),
        new(
            "2024001378",
            "Tomografia de Seios da Face",
            new DateOnly(2026, 5, 5),
            new DateOnly(2026, 5, 6),
            "Tomografia computadorizada de seios da face",
            "ACC-00224177",
            "Dr. Vinicius Prado",
            "CRM 553311",
            "SP",
            "Dra. Patricia Valverde",
            null,
            null,
            "Unidade Oeste",
            "Tec. Rafael Moreira",
            "CRTR 003912",
            "SP",
            "processing"
        ),
        new(
            "2024001392",
            "Ultrassom Tireoide",
            new DateOnly(2026, 5, 4),
            new DateOnly(2026, 5, 4),
            "Ultrassonografia da tireoide",
            "ACC-00223859",
            "Dra. Sonia Campos",
            "CRM 210034",
            "SP",
            "Dr. Mauro Nogueira",
            null,
            null,
            "Unidade Norte",
            "Tec. Bruno Matias",
            "CRTR 002744",
            "SP",
            "ready-report"
        ),
        new(
            "2024001401",
            "Ressonancia Joelho Direito",
            new DateOnly(2026, 5, 2),
            new DateOnly(2026, 5, 3),
            "Ressonancia magnetica do joelho direito",
            "ACC-00223110",
            "Dr. Leonardo Sena",
            "CRM 991122",
            "SP",
            "Dr. Luis Carvalho",
            null,
            null,
            "Unidade Leste",
            "Tec. Julia Nascimento",
            "CRTR 004587",
            "SP",
            "images-available"
        ),
        new(
            "2024001415",
            "Tomografia Abdome",
            new DateOnly(2026, 4, 29),
            new DateOnly(2026, 4, 30),
            "Tomografia computadorizada de abdomen total",
            "ACC-00221804",
            "Dra. Cintia Mello",
            "CRM 884401",
            "SP",
            "Dr. Reinaldo Fagundes",
            null,
            null,
            "Unidade Centro",
            "Tec. Pedro Santos",
            "CRTR 006310",
            "SP",
            "ready-report"
        ),
        new(
            "2024001422",
            "Raio-X Lombar",
            new DateOnly(2026, 4, 27),
            new DateOnly(2026, 4, 27),
            "Radiografia da coluna lombar",
            "ACC-00220988",
            "Dr. Felipe Rocha",
            "CRM 660051",
            "SP",
            "Dra. Lucia Amaral",
            null,
            null,
            "Unidade Sul",
            "Tec. Roberta Lima",
            "CRTR 009201",
            "SP",
            "processing"
        ),
        new(
            "2024001439",
            "Ultrassom Obstetrico",
            new DateOnly(2026, 4, 24),
            new DateOnly(2026, 4, 24),
            "Ultrassonografia obstetrica",
            "ACC-00219875",
            "Dra. Elisa Monte",
            "CRM 332811",
            "SP",
            "Dra. Andrea Soares",
            null,
            null,
            "Unidade Oeste",
            "Tec. Bianca Faria",
            "CRTR 001822",
            "SP",
            "ready-report"
        ),
        new(
            "2024001447",
            "Ressonancia Coluna Cervical",
            new DateOnly(2026, 4, 20),
            new DateOnly(2026, 4, 21),
            "Ressonancia magnetica da coluna cervical",
            "ACC-00218231",
            "Dr. Henrique Lara",
            "CRM 770012",
            "SP",
            "Dr. Caio Silveira",
            null,
            null,
            "Unidade Norte",
            "Tec. Rafael Moreira",
            "CRTR 003912",
            "SP",
            "images-available"
        )
    ];

    public static readonly AddendumItem[] Addendums =
    [
        new(
            new DateOnly(2026, 5, 24),
            "Dra. Helena Passos",
            "CRM 145920",
            "SP",
            "Correlacionar com quadro clinico e exames laboratoriais previos, a criterio medico."
        )
    ];

    public static readonly ExamAttachmentItem[] ExamAttachments =
    [
        new(
            "att-1",
            "2024001234",
            new DateTimeOffset(2026, 5, 22, 10, 35, 0, TimeSpan.Zero),
            "pedido-medico.pdf",
            "application/pdf",
            "Marcia Souza",
            "reception"
        ),
        new(
            "att-2",
            "2024001234",
            new DateTimeOffset(2026, 5, 22, 10, 39, 0, TimeSpan.Zero),
            "checklist-preparo.docx",
            "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            "Julia Nascimento",
            "radiology-technician"
        ),
        new(
            "att-3",
            "2024001234",
            new DateTimeOffset(2026, 5, 22, 10, 46, 0, TimeSpan.Zero),
            "observacao-sala.jpg",
            "image/jpeg",
            "Bruno Matias",
            "room-assistant"
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

    public static IReadOnlyList<ExamAttachmentItem> GetAttachmentsByProtocol(string protocol)
    {
        return ExamAttachments
            .Where(x => string.Equals(x.ExamProtocol, protocol, StringComparison.OrdinalIgnoreCase))
            .OrderByDescending(x => x.AttachedAt)
            .ToList();
    }

    public static ExamAttachmentItem? GetAttachmentById(string protocol, string attachmentId)
    {
        return ExamAttachments.FirstOrDefault(x =>
            string.Equals(x.ExamProtocol, protocol, StringComparison.OrdinalIgnoreCase) &&
            string.Equals(x.Id, attachmentId, StringComparison.OrdinalIgnoreCase));
    }

    public static class Facility
    {
        public const string Name = "Clinica Imagem Saude";
        public const string Cnpj = "12.345.678/0001-90";
        public const string Address = "Av. Central, 1500 - Sao Paulo/SP";
        public const string Phone = "(11) 3333-0000";
        public const string Email = "contato@clinicaimagemsaude.com.br";
        public const string FooterText = "Documento emitido eletronicamente pelo Portal do Paciente.";
    }

    public const string ReportBody = @"
<p><strong>Tecnica:</strong> Exame realizado em equipamento de 1.5T, com sequencias multiplanares.</p>
<p><strong>Achados:</strong> Nao ha evidencias de lesoes expansivas, restricao a difusao ou hemorragia aguda.</p>
<p><strong>Conclusao:</strong> Exame dentro dos limites da normalidade para a faixa etaria.</p>";

    public static string AddendumBody => Addendums[0].Body;

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
