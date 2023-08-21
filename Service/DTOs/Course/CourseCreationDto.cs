namespace Service.DTOs.Course;

public class CourseCreationDto
{
    public long CourseId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
}
