using AutoMapper;
using Data.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.Quiz;
using Service.Exeptions;
using Service.Interfaces;

namespace Service.Services;

public class QuizService : IQuizService
{
    private readonly IMapper mapper;
    private readonly IRepository<Quiz> repository;

    public QuizService(IRepository<Quiz> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<QuizResultDto> AddAsync(QuizCreationDto dto)
    {
        Quiz existQuiz = await this.repository.GetAsync(x => x.Title.Equals(dto.Title));

        if (existQuiz is not null)
        {
            throw new AllReadyExistException($"This Quiz title {dto.Title} allready exist");
        }

        var mappedQuiz = mapper.Map<Quiz>(dto);
        await this.repository.CreateAsync(mappedQuiz);
        await this.repository.SaveAsync();

        var result = mapper.Map<QuizResultDto>(mappedQuiz);
        return result;
    }

    public async Task<QuizResultDto> ModifyAsync(QuizUpdateDto dto)
    {
        Quiz existQuiz = await this.repository.GetAsync(x => x.Id.Equals(dto.Id));

        if (existQuiz is null)
        {
            throw new NotFoundException($"This Quiz is not found with Id-{dto.Id}");
        }

        var mappedQuiz = mapper.Map<Quiz>(dto);
        this.repository.Update(mappedQuiz);
        await this.repository.SaveAsync();

        var result = mapper.Map<QuizResultDto>(mappedQuiz);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        Quiz existQuiz = await this.repository.GetAsync(x => x.Id.Equals(id));

        if (existQuiz is null)
        {
            throw new NotFoundException($"This Quiz is not found with Id-{id}");
        }

        this.repository.Delete(existQuiz);
        await this.repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<QuizResultDto>> RetrieveAllAsync()
    {
        var Quizs = await this.repository.GetAll().ToListAsync();
        var result = mapper.Map<IEnumerable<QuizResultDto>>(Quizs);
        return result;
    }

    public async Task<QuizResultDto> RetrieveByIdAsync(long id)
    {
        Quiz existQuiz = await this.repository.GetAsync(x => x.Id.Equals(id));

        if (existQuiz is null)
        {
            throw new NotFoundException($"This Quiz is not found with Id-{id}");
        }
        return mapper.Map<QuizResultDto>(existQuiz);
    }
}
