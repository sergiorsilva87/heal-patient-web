using Heal.Patient.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace Heal.Patient.Web.Pages.Exam;

public class ColdStorageModel : PageModel
{
    private readonly IExamAuditTrail _auditTrail;

    public ColdStorageModel(IExamAuditTrail auditTrail)
    {
        _auditTrail = auditTrail;
    }

    public IReadOnlyList<MockData.ExamAttachmentItem> Attachments { get; private set; } = [];

    public void OnGet()
    {
        _auditTrail.Track(MockData.Exam.Protocol, "report-downloaded", Request.Path);
        Attachments = MockData.GetAttachmentsByProtocol(MockData.Exam.Protocol);
    }

    public IActionResult OnGetDownloadAttachment(string attachmentId)
    {
        var attachment = MockData.GetAttachmentById(MockData.Exam.Protocol, attachmentId);

        if (attachment is null)
        {
            return NotFound();
        }

        _auditTrail.Track(MockData.Exam.Protocol, "exam-attachment-downloaded", Request.Path);

        var fileBody = $"Mock attachment file for {attachment.FileName} ({attachment.ExamProtocol})";
        return File(Encoding.UTF8.GetBytes(fileBody), attachment.ContentType, attachment.FileName);
    }
}
