namespace Service.DTOs.QuizQuestion;

public class QuizQuestionCreationDto
{
    public string Question { get; set; }
    public string Answer { get; set; }
    public long QuizId { get; set; }
}
