using Service.DTOs.Enrollment;

namespace Service.Interfaces;

public interface IEnrollmentService
{
    Task<EnrollmentResultDto> AddAsync(EnrollmentCreationDto dto);
    Task<EnrollmentResultDto> ModifyAsync(EnrollmentUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<EnrollmentResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<EnrollmentResultDto>> RetrieveAllAsync();

}
