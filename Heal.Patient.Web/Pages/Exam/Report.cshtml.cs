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
    public bool AllowPatientSupportingDocumentsUpload => MockData.TenantPortalPolicy.AllowPatientSupportingDocumentsUpload;
    public bool AllowExternalPhysicianReviewRequest => MockData.TenantPortalPolicy.AllowExternalPhysicianReviewRequest;
    public bool AllowPatientOrGuardianReviewRequest => MockData.TenantPortalPolicy.AllowPatientOrGuardianReviewRequest;
    public bool AllowInternalPhysicianReviewRequest => MockData.TenantPortalPolicy.AllowInternalPhysicianReviewRequest;
    public IReadOnlyList<MockData.ReportItem> Reports { get; private set; } = [];
    public IReadOnlyList<MockData.ExamAttachmentItem> Attachments { get; private set; } = [];

    [BindProperty]
    public string ReviewRequesterType { get; set; } = string.Empty;

    [BindProperty]
    public string ReviewRequestReason { get; set; } = string.Empty;

    [BindProperty]
    public IFormFile? SupportingDocumentFile { get; set; }

    public void OnGet()
    {
        _auditTrail.Track(Protocol, "report-viewed", Request.Path);
        Reports = MockData.GetReportsByProtocol(Protocol);
        Attachments = MockData.GetAttachmentsByProtocol(Protocol);
    }

    public IActionResult OnGetDownloadAllReportsZip()
    {
        _auditTrail.Track(Protocol, "reports-all-zip-downloaded", Request.Path);
        var reportCount = MockData.GetReportsByProtocol(Protocol).Count;
        var content = Encoding.UTF8.GetBytes(
            $"Mock ZIP with all {reportCount} reports and attachments for protocol {Protocol}");
        return File(content, "application/zip", $"{Protocol}-laudos.zip");
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

    public IActionResult OnPostSubmitReviewRequest()
    {
        if (string.IsNullOrWhiteSpace(ReviewRequesterType) || string.IsNullOrWhiteSpace(ReviewRequestReason))
        {
            TempData["ReviewRequestError"] = "required";
            return RedirectToPage();
        }

        var isAllowed = ReviewRequesterType switch
        {
            "external-physician" => AllowExternalPhysicianReviewRequest,
            "patient-or-guardian" => AllowPatientOrGuardianReviewRequest,
            "internal-physician" => AllowInternalPhysicianReviewRequest,
            _ => false
        };

        if (!isAllowed)
        {
            TempData["ReviewRequestError"] = "not-allowed";
            return RedirectToPage();
        }

        _auditTrail.Track(Protocol, "report-review-requested", Request.Path);
        TempData["ReviewRequestSuccess"] = "ok";
        return RedirectToPage();
    }

    public IActionResult OnPostUploadSupportingDocument()
    {
        if (!AllowPatientSupportingDocumentsUpload)
        {
            TempData["SupportingDocumentError"] = "not-allowed";
            return RedirectToPage();
        }

        if (SupportingDocumentFile is null || SupportingDocumentFile.Length == 0)
        {
            TempData["SupportingDocumentError"] = "required";
            return RedirectToPage();
        }

        _auditTrail.Track(Protocol, "supporting-document-uploaded", Request.Path);
        TempData["SupportingDocumentSuccess"] = SupportingDocumentFile.FileName;
        return RedirectToPage();
    }
}
