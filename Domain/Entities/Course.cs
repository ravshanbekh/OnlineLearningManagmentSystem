using Domain.Commons;

namespace Domain.Entities;

public class Course:Auditable
{
    public string Title { get; set; }
    public string Description { get; set; }
    public long InsructorId { get; set; }
}
