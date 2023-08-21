namespace Service.DTOs.QuizQuestion;

public class QuizQuestionResultDto
{
    public long Id { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
    public long QuizId { get; set; }
}
