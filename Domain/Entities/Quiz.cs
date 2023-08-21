using Domain.Commons;

namespace Domain.Entities;

public class Quiz:Auditable
{
    public long CourseId { get; set; }
    public string Title { get; set; }
    public IEnumerable<QuizQuestion> Questions { get; set; }
    public DateTime TimeLimit { get; set; }
}
