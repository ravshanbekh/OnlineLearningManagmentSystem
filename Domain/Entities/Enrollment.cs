using Domain.Commons;

namespace Domain.Entities;

public class Enrollment:Auditable
{
    public long UserId { get; set; }
    public long CourseId { get; set; }
}
