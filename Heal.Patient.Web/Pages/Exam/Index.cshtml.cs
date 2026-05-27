using Heal.Patient.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Heal.Patient.Web.Pages.Exam;

public class IndexModel : PageModel
{
    public string PatientName => MockData.Patient.Name;
    public string PatientId => MockData.Patient.PatientId;
    public string PatientBirthDate => MockData.Patient.BirthDate;
    public string PatientCpfMasked => MockData.Patient.CpfMasked;
    public IReadOnlyList<MockData.ExamItem> PagedExams { get; private set; } = [];
    public int CurrentPage { get; private set; } = 1;
    public int PageSize { get; private set; } = 10;
    public int TotalItems { get; private set; }
    public int TotalPages { get; private set; }
    public int StartItemNumber { get; private set; }
    public int EndItemNumber { get; private set; }

    public void OnGet(int page = 1, int pageSize = 10)
    {
        var allowedPageSizes = new[] { 5, 10, 20, 50 };
        PageSize = allowedPageSizes.Contains(pageSize) ? pageSize : 10;

        var ordered = MockData.Exams
            .OrderByDescending(x => x.ExamDate)
            .ToList();

        TotalItems = ordered.Count;
        TotalPages = TotalItems == 0 ? 1 : (int)Math.Ceiling(TotalItems / (double)PageSize);
        CurrentPage = Math.Clamp(page, 1, TotalPages);

        PagedExams = ordered
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .ToList();

        StartItemNumber = TotalItems == 0 ? 0 : ((CurrentPage - 1) * PageSize) + 1;
        EndItemNumber = TotalItems == 0 ? 0 : StartItemNumber + PagedExams.Count - 1;
    }
}
