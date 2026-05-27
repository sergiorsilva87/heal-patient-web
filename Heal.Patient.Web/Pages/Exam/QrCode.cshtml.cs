using Heal.Patient.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Heal.Patient.Web.Pages.Exam;

public class QrCodeModel : PageModel
{
    public string ShareLink => MockData.QrLink;

    public void OnGet()
    {
    }
}
