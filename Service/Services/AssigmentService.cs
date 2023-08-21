using AutoMapper;
using Data.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.Assigment;
using Service.Exeptions;
using Service.Interfaces;

namespace Service.Services;

public class AssigmentService : IAssigmentService
{
    private readonly IMapper mapper;
    private readonly IRepository<Assigment> repository;

    public AssigmentService(IRepository<Assigment> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<AssigmentResultDto> AddAsync(AssigmentCreationDto dto)
    {
        Assigment existAssigment = await this.repository.GetAsync(x => x.Title.Equals(dto.Title));

        if (existAssigment is not null)
        {
            throw new AllReadyExistException($"This Assigment title {dto.Title} allready exist");
        }

        var mappedAssigment = mapper.Map<Assigment>(dto);
        await this.repository.CreateAsync(mappedAssigment);
        await this.repository.SaveAsync();

        var result = mapper.Map<AssigmentResultDto>(mappedAssigment);
        return result;
    }

    public async Task<AssigmentResultDto> ModifyAsync(AssigmentUpdateDto dto)
    {
        Assigment existAssigment = await this.repository.GetAsync(x => x.Id.Equals(dto.Id));

        if (existAssigment is null)
        {
            throw new NotFoundException($"This Assigment is not found with Id-{dto.Id}");
        }

        var mappedAssigment = mapper.Map<Assigment>(dto);
        this.repository.Update(mappedAssigment);
        await this.repository.SaveAsync();

        var result = mapper.Map<AssigmentResultDto>(mappedAssigment);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        Assigment existAssigment = await this.repository.GetAsync(x => x.Id.Equals(id));

        if (existAssigment is null)
        {
            throw new NotFoundException($"This Assigment is not found with Id-{id}");
        }

        this.repository.Delete(existAssigment);
        await this.repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<AssigmentResultDto>> RetrieveAllAsync()
    {
        var Assigments = await this.repository.GetAll().ToListAsync();
        var result = mapper.Map<IEnumerable<AssigmentResultDto>>(Assigments);
        return result;
    }

    public async Task<AssigmentResultDto> RetrieveByIdAsync(long id)
    {
        Assigment existAssigment = await this.repository.GetAsync(x => x.Id.Equals(id));

        if (existAssigment is null)
        {
            throw new NotFoundException($"This Assigment is not found with Id-{id}");
        }
        return mapper.Map<AssigmentResultDto>(existAssigment);
    }
}
