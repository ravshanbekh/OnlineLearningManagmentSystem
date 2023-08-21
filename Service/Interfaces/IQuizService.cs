using Service.DTOs.Quiz;

namespace Service.Interfaces;

public interface IQuizService
{
    Task<QuizResultDto> AddAsync(QuizCreationDto dto);
    Task<QuizResultDto> ModifyAsync(QuizUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<QuizResultDto> RetrieveByIdAsync(long id); 
    Task<IEnumerable<QuizResultDto>> RetrieveAllAsync();

}
