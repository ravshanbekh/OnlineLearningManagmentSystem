namespace Service.DTOs.Course;

public class CourseResultDto
{
    public long Id { get; set; }
    public long CourseId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
}