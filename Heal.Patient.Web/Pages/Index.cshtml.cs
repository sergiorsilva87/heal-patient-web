using Heal.Patient.Web;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;

namespace Heal.Patient.Web.Pages;

public class IndexModel : PageModel
{
    private readonly IStringLocalizer<SharedResource> _localizer;

    public IndexModel(IStringLocalizer<SharedResource> localizer)
    {
        _localizer = localizer;
    }

    [BindProperty]
    public string? Protocol { get; set; }

    [BindProperty]
    public DateTime? BirthDate { get; set; }

    [BindProperty]
    public string? Cpf { get; set; }

    [BindProperty]
    public string? Code { get; set; }

    public string ActiveTab { get; private set; } = "protocol";

    public void OnGet()
    {

    }

    public IActionResult OnPostProtocol()
    {
        ActiveTab = "protocol";

        if (string.IsNullOrWhiteSpace(Protocol))
        {
            ModelState.AddModelError(nameof(Protocol), _localizer["Número de protocolo é obrigatório."]);
        }

        if (!BirthDate.HasValue)
        {
            ModelState.AddModelError(nameof(BirthDate), _localizer["Data de nascimento é obrigatória."]);
        }
        else if (BirthDate.Value.Date > DateTime.Today)
        {
            ModelState.AddModelError(nameof(BirthDate), _localizer["Data de nascimento não pode ser futura."]);
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        return RedirectToPage("/Exam/Index");
    }

    public IActionResult OnPostCpf()
    {
        ActiveTab = "cpf";

        if (string.IsNullOrWhiteSpace(Cpf))
        {
            ModelState.AddModelError(nameof(Cpf), _localizer["CPF é obrigatório."]);
        }
        else
        {
            var digits = Regex.Replace(Cpf, "[^0-9]", string.Empty);
            if (digits.Length != 11)
            {
                ModelState.AddModelError(nameof(Cpf), _localizer["Informe um CPF válido com 11 dígitos."]);
            }
        }

        if (string.IsNullOrWhiteSpace(Code))
        {
            ModelState.AddModelError(nameof(Code), _localizer["Código de acesso é obrigatório."]);
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        return RedirectToPage("/Exam/Index");
    }
}
