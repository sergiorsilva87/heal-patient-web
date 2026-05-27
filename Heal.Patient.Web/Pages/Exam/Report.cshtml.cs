using Heal.Patient.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
    public string AccessNumber => MockData.Exam.AccessNumber;
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
    public string ReportBody => MockData.ReportBody;
    public string AddendumBody => MockData.AddendumBody;

    public void OnGet()
    {
        _auditTrail.Track(Protocol, "report-viewed", Request.Path);
    }
}
