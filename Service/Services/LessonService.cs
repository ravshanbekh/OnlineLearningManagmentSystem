using AutoMapper;
using Data.IRepositories;
using Domain.Entitiesl;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.Lesson;
using Service.Exeptions;
using Service.Interfaces;

namespace Service.Services;

public class LessonService : ILessonService
{
    private readonly IMapper mapper;
    private readonly IRepository<Lesson> repository;

    public LessonService(IRepository<Lesson> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<LessonResultDto> AddAsync(LessonCreationDto dto)
    {
        Lesson existLesson = await this.repository.GetAsync(x => x.Title.Equals(dto.Title));

        if (existLesson is not null)
        {
            throw new AllReadyExistException($"This Lesson title {dto.Title} allready exist");
        }

        var mappedLesson = mapper.Map<Lesson>(dto);
        await this.repository.CreateAsync(mappedLesson);
        await this.repository.SaveAsync();

        var result = mapper.Map<LessonResultDto>(mappedLesson);
        return result;
    }

    public async Task<LessonResultDto> ModifyAsync(LessonUpdateDto dto)
    {
        Lesson existLesson = await this.repository.GetAsync(x => x.Id.Equals(dto.Id));

        if (existLesson is null)
        {
            throw new NotFoundException($"This Lesson is not found with Id-{dto.Id}");
        }

        var mappedLesson = mapper.Map<Lesson>(dto);
        this.repository.Update(mappedLesson);
        await this.repository.SaveAsync();

        var result = mapper.Map<LessonResultDto>(mappedLesson);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        Lesson existLesson = await this.repository.GetAsync(x => x.Id.Equals(id));

        if (existLesson is null)
        {
            throw new NotFoundException($"This Lesson is not found with Id-{id}");
        }

        this.repository.Delete(existLesson);
        await this.repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<LessonResultDto>> RetrieveAllAsync()
    {
        var Lessons = await this.repository.GetAll().ToListAsync();
        var result = mapper.Map<IEnumerable<LessonResultDto>>(Lessons);
        return result;
    }

    public async Task<LessonResultDto> RetrieveByIdAsync(long id)
    {
        Lesson existLesson = await this.repository.GetAsync(x => x.Id.Equals(id));

        if (existLesson is null)
        {
            throw new NotFoundException($"This Lesson is not found with Id-{id}");
        }
        return mapper.Map<LessonResultDto>(existLesson);
    }
}
