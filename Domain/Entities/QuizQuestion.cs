using Domain.Commons;

namespace Domain.Entities;

public class QuizQuestion:Auditable
{
    public string Question { get; set; }
    public string Answer { get; set; }
    public long QuizId { get; set; }
}
