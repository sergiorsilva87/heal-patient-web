using Heal.Patient.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Heal.Patient.Web.Pages.Exam;

public class IndexModel : PageModel
{
    public string PatientName => MockData.Patient.Name;
    public string PatientId => MockData.Patient.PatientId;
    public string PatientBirthDate => MockData.Patient.BirthDate;
    public string PatientCpfMasked => MockData.Patient.CpfMasked;
    public IReadOnlyList<MockData.ExamItem> RecentExams { get; private set; } = [];
    public IReadOnlyList<MockData.ExamItem> OlderExams { get; private set; } = [];

    public void OnGet()
    {
        var ordered = MockData.Exams
            .OrderByDescending(x => x.ExamDate)
            .ToList();

        RecentExams = ordered.Take(2).ToList();
        OlderExams = ordered.Skip(2).ToList();
    }
}
