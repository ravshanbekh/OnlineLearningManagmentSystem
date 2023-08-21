using Domain.Commons;

namespace Domain.Entitiesl;

public class Lesson:Auditable
{
    public long CourseId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime ReleaseDate { get; set; }
}
