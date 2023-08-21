using AutoMapper;
using Data.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.Course;
using Service.Exeptions;
using Service.Interfaces;

namespace Service.Services;

public class CourseService : ICourseService
{
    private readonly IMapper mapper;
    private readonly IRepository<Course> repository;

    public CourseService(IRepository<Course> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<CourseResultDto> AddAsync(CourseCreationDto dto)
    {
        Course existCourse = await this.repository.GetAsync(x => x.Title.Equals(dto.Title));

        if (existCourse is not null)
        {
            throw new AllReadyExistException($"This Course title {dto.Title} allready exist");
        }

        var mappedCourse = mapper.Map<Course>(dto);
        await this.repository.CreateAsync(mappedCourse);
        await this.repository.SaveAsync();

        var result = mapper.Map<CourseResultDto>(mappedCourse);
        return result;
    }

    public async Task<CourseResultDto> ModifyAsync(CourseUpdateDto dto)
    {
        Course existCourse = await this.repository.GetAsync(x => x.Id.Equals(dto.Id));

        if (existCourse is null)
        {
            throw new NotFoundException($"This Course is not found with Id-{dto.Id}");
        }

        var mappedCourse = mapper.Map<Course>(dto);
        this.repository.Update(mappedCourse);
        await this.repository.SaveAsync();

        var result = mapper.Map<CourseResultDto>(mappedCourse);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        Course existCourse = await this.repository.GetAsync(x => x.Id.Equals(id));

        if (existCourse is null)
        {
            throw new NotFoundException($"This Course is not found with Id-{id}");
        }

        this.repository.Delete(existCourse);
        await this.repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<CourseResultDto>> RetrieveAllAsync()
    {
        var Courses = await this.repository.GetAll().ToListAsync();
        var result = mapper.Map<IEnumerable<CourseResultDto>>(Courses);
        return result;
    }

    public async Task<CourseResultDto> RetrieveByIdAsync(long id)
    {
        Course existCourse = await this.repository.GetAsync(x => x.Id.Equals(id));

        if (existCourse is null)
        {
            throw new NotFoundException($"This Course is not found with Id-{id}");
        }
        return mapper.Map<CourseResultDto>(existCourse);
    }
}
