using Service.DTOs.Submission;

namespace Service.Interfaces;

public interface ISubmissionService
{
    Task<SubmissionResultDto> AddAsync(SubmissionCreationDto dto);
    Task<SubmissionResultDto> ModifyAsync(SubmissionUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<SubmissionResultDto> RetrieveByIdAsync(long id); 
    Task<IEnumerable<SubmissionResultDto>> RetrieveAllAsync();

}