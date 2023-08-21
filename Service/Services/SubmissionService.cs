using AutoMapper;
using Data.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.Submission;
using Service.Exeptions;
using Service.Interfaces;

namespace Service.Services;

public class SubmissionService : ISubmissionService
{
    private readonly IMapper mapper;
    private readonly IRepository<Submission> repository;

    public SubmissionService(IRepository<Submission> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<SubmissionResultDto> AddAsync(SubmissionCreationDto dto)
    {
        Submission existSubmission = await this.repository.GetAsync(x => x.SubmissionText.Equals(dto.SubmissionText));

        if (existSubmission is not null)
        {
            throw new AllReadyExistException($"This Submission  {dto.SubmissionText} allready exist");
        }

        var mappedSubmission = mapper.Map<Submission>(dto);
        await this.repository.CreateAsync(mappedSubmission);
        await this.repository.SaveAsync();

        var result = mapper.Map<SubmissionResultDto>(mappedSubmission);
        return result;
    }

    public async Task<SubmissionResultDto> ModifyAsync(SubmissionUpdateDto dto)
    {
        Submission existSubmission = await this.repository.GetAsync(x => x.Id.Equals(dto.Id));

        if (existSubmission is null)
        {
            throw new NotFoundException($"This Submission is not found with Id-{dto.Id}");
        }

        var mappedSubmission = mapper.Map<Submission>(dto);
        this.repository.Update(mappedSubmission);
        await this.repository.SaveAsync();

        var result = mapper.Map<SubmissionResultDto>(mappedSubmission);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        Submission existSubmission = await this.repository.GetAsync(x => x.Id.Equals(id));

        if (existSubmission is null)
        {
            throw new NotFoundException($"This Submission is not found with Id-{id}");
        }

        this.repository.Delete(existSubmission);
        await this.repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<SubmissionResultDto>> RetrieveAllAsync()
    {
        var Submissions = await this.repository.GetAll().ToListAsync();
        var result = mapper.Map<IEnumerable<SubmissionResultDto>>(Submissions);
        return result;
    }

    public async Task<SubmissionResultDto> RetrieveByIdAsync(long id)
    {
        Submission existSubmission = await this.repository.GetAsync(x => x.Id.Equals(id));

        if (existSubmission is null)
        {
            throw new NotFoundException($"This Submission is not found with Id-{id}");
        }
        return mapper.Map<SubmissionResultDto>(existSubmission);
    }
}
