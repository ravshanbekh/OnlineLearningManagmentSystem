namespace Service.DTOs.Lesson;

public class LessonCreationDto
{
    public long CourseId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime ReleaseDate { get; set; }
}
