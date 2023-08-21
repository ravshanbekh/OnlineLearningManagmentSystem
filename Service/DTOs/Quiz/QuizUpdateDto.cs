using Service.DTOs.QuizQuestion;

namespace Service.DTOs.Quiz;

public class QuizUpdateDto
{
    public long Id { get; set; }
    public long CourseId { get; set; }
    public string Title { get; set; }
    public IEnumerable<QuizQuestionResultDto> Questions { get; set; }
    public DateTime TimeLimit { get; set; }
}
