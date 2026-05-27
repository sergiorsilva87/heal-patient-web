using System.Collections.Concurrent;

namespace Heal.Patient.Web.Services;

public sealed record ExamAuditEntry(
    DateTimeOffset TimestampUtc,
    string Protocol,
    string EventName,
    string Path
);

public interface IExamAuditTrail
{
    void Track(string protocol, string eventName, string path);
    IReadOnlyList<ExamAuditEntry> GetRecent(int take = 100);
}

public sealed class InMemoryExamAuditTrail(ILogger<InMemoryExamAuditTrail> logger) : IExamAuditTrail
{
    private readonly ConcurrentQueue<ExamAuditEntry> _entries = new();

    public void Track(string protocol, string eventName, string path)
    {
        var entry = new ExamAuditEntry(
            TimestampUtc: DateTimeOffset.UtcNow,
            Protocol: protocol,
            EventName: eventName,
            Path: path
        );

        _entries.Enqueue(entry);

        while (_entries.Count > 5000)
        {
            _entries.TryDequeue(out _);
        }

        logger.LogInformation(
            "Exam audit event: {EventName} | Protocol: {Protocol} | Path: {Path} | TimestampUtc: {TimestampUtc}",
            entry.EventName,
            entry.Protocol,
            entry.Path,
            entry.TimestampUtc
        );
    }

    public IReadOnlyList<ExamAuditEntry> GetRecent(int take = 100)
    {
        return _entries.Reverse().Take(take).ToList();
    }
}