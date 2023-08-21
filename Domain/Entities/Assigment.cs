using Domain.Commons;

namespace Domain.Entities;

public class Assigment:Auditable
{
    public long CourseId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
}
