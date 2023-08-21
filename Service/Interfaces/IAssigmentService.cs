using Service.DTOs.Assigment;

namespace Service.Interfaces;

public interface IAssigmentService
{
    Task<AssigmentResultDto> AddAsync(AssigmentCreationDto dto);
    Task<AssigmentResultDto> ModifyAsync(AssigmentUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<IEnumerable<AssigmentResultDto>> RetrieveAllAsync();
    Task<AssigmentResultDto> RetrieveByIdAsync(long id);
}
