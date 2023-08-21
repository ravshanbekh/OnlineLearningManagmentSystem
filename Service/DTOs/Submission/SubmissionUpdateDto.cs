namespace Service.DTOs.Submission;

public class SubmissionUpdateDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long AssigmentId { get; set; }
    public string SubmissionText { get; set; }
    public DateTime SubmissionTime { get; set; }
}
