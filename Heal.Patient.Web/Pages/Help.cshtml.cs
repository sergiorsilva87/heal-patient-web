using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Heal.Patient.Web.Pages;

public class HelpModel : PageModel
{
    private readonly IStringLocalizer<SharedResource> _localizer;

    public HelpModel(IStringLocalizer<SharedResource> localizer)
    {
        _localizer = localizer;
    }

    public (string Question, string Answer)[] FaqItems =>
    [
        (_localizer["Como acesso meu exame?"], _localizer["Informe número de protocolo e data de nascimento na tela inicial."]),
        (_localizer["Não tenho protocolo. O que faço?"], _localizer["Solicite código de acesso na recepção da clínica e entre com CPF + código."]),
        (_localizer["Posso baixar o laudo em PDF?"], _localizer["Sim. No painel do exame, clique em Baixar PDF."])
    ];

    public void OnGet()
    {
    }
}
