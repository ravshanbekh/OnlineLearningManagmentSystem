using Domain.Commons;

namespace Domain.Entities;

public class Submission : Auditable
{
    public long UserId { get; set; }
    public long AssigmentId { get; set; }
    public string SubmissionText { get; set; }
    public DateTime SubmissionTime { get; set; }
}
