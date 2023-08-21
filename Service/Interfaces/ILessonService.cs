using Service.DTOs.Lesson;

namespace Service.Interfaces;

public interface ILessonService
{
    Task<LessonResultDto> AddAsync(LessonCreationDto dto);
    Task<LessonResultDto> ModifyAsync(LessonUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<LessonResultDto> RetrieveByIdAsync(long id); 
    Task<IEnumerable<LessonResultDto>> RetrieveAllAsync();

}
