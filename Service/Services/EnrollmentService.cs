using AutoMapper;
using Data.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.Enrollment;
using Service.Exeptions;
using Service.Interfaces;

namespace Service.Services;

public class EnrollmentService : IEnrollmentService
{
    private readonly IMapper mapper;
    private readonly IRepository<Enrollment> repository;

    public EnrollmentService(IRepository<Enrollment> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<EnrollmentResultDto> AddAsync(EnrollmentCreationDto dto)
    {

        var mappedEnrollment = mapper.Map<Enrollment>(dto);
        await this.repository.CreateAsync(mappedEnrollment);
        await this.repository.SaveAsync();

        var result = mapper.Map<EnrollmentResultDto>(mappedEnrollment);
        return result;
    }

    public async Task<EnrollmentResultDto> ModifyAsync(EnrollmentUpdateDto dto)
    {
        Enrollment existEnrollment = await this.repository.GetAsync(x => x.Id.Equals(dto.Id));

        if (existEnrollment is null)
        {
            throw new NotFoundException($"This Enrollment is not found with Id-{dto.Id}");
        }

        var mappedEnrollment = mapper.Map<Enrollment>(dto);
        this.repository.Update(mappedEnrollment);
        await this.repository.SaveAsync();

        var result = mapper.Map<EnrollmentResultDto>(mappedEnrollment);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        Enrollment existEnrollment = await this.repository.GetAsync(x => x.Id.Equals(id));

        if (existEnrollment is null)
        {
            throw new NotFoundException($"This Enrollment is not found with Id-{id}");
        }

        this.repository.Delete(existEnrollment);
        await this.repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<EnrollmentResultDto>> RetrieveAllAsync()
    {
        var Enrollments = await this.repository.GetAll().ToListAsync();
        var result = mapper.Map<IEnumerable<EnrollmentResultDto>>(Enrollments);
        return result;
    }

    public async Task<EnrollmentResultDto> RetrieveByIdAsync(long id)
    {
        Enrollment existEnrollment = await this.repository.GetAsync(x => x.Id.Equals(id));

        if (existEnrollment is null)
        {
            throw new NotFoundException($"This Enrollment is not found with Id-{id}");
        }
        return mapper.Map<EnrollmentResultDto>(existEnrollment);
    }
}
