namespace Service.DTOs.Lesson;

public class LessonResultDto
{
    public long Id { get; set; }
    public long CourseId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime ReleaseDate { get; set; }
}