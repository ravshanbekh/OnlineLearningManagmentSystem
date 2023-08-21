using Service.DTOs.QuizQuestion;

namespace Service.Interfaces;

public interface IQuizQuestionService
{
    Task<QuizQuestionResultDto> AddAsync(QuizQuestionCreationDto dto);
    Task<QuizQuestionResultDto> ModifyAsync(QuizQuestionUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<QuizQuestionResultDto> RetrieveByIdAsync(long id); 
    Task<IEnumerable<QuizQuestionResultDto>> RetrieveAllAsync();

}
