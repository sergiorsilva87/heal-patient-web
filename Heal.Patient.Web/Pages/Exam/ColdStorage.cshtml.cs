using Heal.Patient.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Heal.Patient.Web.Pages.Exam;

public class ColdStorageModel : PageModel
{
    private readonly IExamAuditTrail _auditTrail;

    public ColdStorageModel(IExamAuditTrail auditTrail)
    {
        _auditTrail = auditTrail;
    }

    public void OnGet()
    {
        _auditTrail.Track(MockData.Exam.Protocol, "report-downloaded", Request.Path);
    }
}
