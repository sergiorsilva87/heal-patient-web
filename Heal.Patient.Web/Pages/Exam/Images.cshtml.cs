using Heal.Patient.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Heal.Patient.Web.Pages.Exam;

public class ImagesModel : PageModel
{
    private readonly IExamAuditTrail _auditTrail;

    public ImagesModel(IExamAuditTrail auditTrail)
    {
        _auditTrail = auditTrail;
    }

    public void OnGet()
    {
        _auditTrail.Track(MockData.Exam.Protocol, "images-viewed", Request.Path);
    }

    public IActionResult OnGetRegisterPrint()
    {
        _auditTrail.Track(MockData.Exam.Protocol, "images-printed", Request.Path);
        return new JsonResult(new { ok = true });
    }
}
