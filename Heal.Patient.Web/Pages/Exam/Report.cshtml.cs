using Heal.Patient.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace Heal.Patient.Web.Pages.Exam;

public class ReportModel : PageModel
{
    private readonly IExamAuditTrail _auditTrail;

    public ReportModel(IExamAuditTrail auditTrail)
    {
        _auditTrail = auditTrail;
    }

    public string Protocol => MockData.Exam.Protocol;
    public string ExamDate => MockData.Exam.Date;
    public string ReportDate => MockData.Exam.ReportDate;
    public string Procedure => MockData.Exam.Procedure;
    public string ExamType => MockData.Exam.Type;
    public string AccessNumber => MockData.Exam.AccessNumber;
    public string PatientName => MockData.Patient.Name;
    public string PatientId => MockData.Patient.PatientId;
    public string PatientBirthDate => MockData.Patient.BirthDate;
    public string PerformingDoctor => MockData.Exam.PerformingDoctor;
    public string PerformingDoctorCrm => MockData.Exam.PerformingDoctorCrm;
    public string PerformingDoctorCrmUf => MockData.Exam.PerformingDoctorCrmUf;
    public string RequestingDoctor => MockData.Exam.RequestingDoctor;
    public string? RequestingDoctorCrm => MockData.Exam.RequestingDoctorCrm;
    public string? RequestingDoctorCrmUf => MockData.Exam.RequestingDoctorCrmUf;
    public string UnitName => MockData.Exam.UnitName;
    public string RadiologyTechnicianName => MockData.Exam.RadiologyTechnicianName;
    public string RadiologyTechnicianRegistry => MockData.Exam.RadiologyTechnicianRegistry;
    public string RadiologyTechnicianRegistryUf => MockData.Exam.RadiologyTechnicianRegistryUf;
    public string FacilityName => MockData.Facility.Name;
    public string FacilityCnpj => MockData.Facility.Cnpj;
    public string FacilityAddress => MockData.Facility.Address;
    public string FacilityPhone => MockData.Facility.Phone;
    public string FacilityEmail => MockData.Facility.Email;
    public string FacilityFooterText => MockData.Facility.FooterText;
    public string ReportBody => MockData.ReportBody;
    public IReadOnlyList<MockData.AddendumItem> Addendums => MockData.Addendums;
    public IReadOnlyList<MockData.ExamAttachmentItem> Attachments { get; private set; } = [];

    public void OnGet()
    {
        _auditTrail.Track(Protocol, "report-viewed", Request.Path);
        Attachments = MockData.GetAttachmentsByProtocol(Protocol);
    }

    public IActionResult OnGetDownloadAttachment(string attachmentId)
    {
        var attachment = MockData.GetAttachmentById(Protocol, attachmentId);

        if (attachment is null)
        {
            return NotFound();
        }

        _auditTrail.Track(Protocol, "exam-attachment-downloaded", Request.Path);

        var fileBody = $"Mock attachment file for {attachment.FileName} ({attachment.ExamProtocol})";
        return File(Encoding.UTF8.GetBytes(fileBody), attachment.ContentType, attachment.FileName);
    }
}
