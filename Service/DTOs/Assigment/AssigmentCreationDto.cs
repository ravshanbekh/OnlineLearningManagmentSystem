namespace Service.DTOs.Assigment;

public class AssigmentCreationDto
{
    public long CourseId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
}
