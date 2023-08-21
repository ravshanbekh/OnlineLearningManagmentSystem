using AutoMapper;
using Data.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.QuizQuestion;
using Service.Exeptions;
using Service.Interfaces;

namespace Service.Services;

public class QuizQuestionService : IQuizQuestionService
{
    private readonly IMapper mapper;
    private readonly IRepository<QuizQuestion> repository;

    public QuizQuestionService(IRepository<QuizQuestion> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<QuizQuestionResultDto> AddAsync(QuizQuestionCreationDto dto)
    {
        QuizQuestion existQuizQuestion = await this.repository.GetAsync(x => x.Question.Equals(dto.Question));

        if (existQuizQuestion is not null)
        {
            throw new AllReadyExistException($"This QuizQuestion  {dto.Question} allready exist");
        }

        var mappedQuizQuestion = mapper.Map<QuizQuestion>(dto);
        await this.repository.CreateAsync(mappedQuizQuestion);
        await this.repository.SaveAsync();

        var result = mapper.Map<QuizQuestionResultDto>(mappedQuizQuestion);
        return result;
    }

    public async Task<QuizQuestionResultDto> ModifyAsync(QuizQuestionUpdateDto dto)
    {
        QuizQuestion existQuizQuestion = await this.repository.GetAsync(x => x.Id.Equals(dto.Id));

        if (existQuizQuestion is null)
        {
            throw new NotFoundException($"This QuizQuestion is not found with Id-{dto.Id}");
        }

        var mappedQuizQuestion = mapper.Map<QuizQuestion>(dto);
        this.repository.Update(mappedQuizQuestion);
        await this.repository.SaveAsync();

        var result = mapper.Map<QuizQuestionResultDto>(mappedQuizQuestion);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        QuizQuestion existQuizQuestion = await this.repository.GetAsync(x => x.Id.Equals(id));

        if (existQuizQuestion is null)
        {
            throw new NotFoundException($"This QuizQuestion is not found with Id-{id}");
        }

        this.repository.Delete(existQuizQuestion);
        await this.repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<QuizQuestionResultDto>> RetrieveAllAsync()
    {
        var QuizQuestions = await this.repository.GetAll().ToListAsync();
        var result = mapper.Map<IEnumerable<QuizQuestionResultDto>>(QuizQuestions);
        return result;
    }

    public async Task<QuizQuestionResultDto> RetrieveByIdAsync(long id)
    {
        QuizQuestion existQuizQuestion = await this.repository.GetAsync(x => x.Id.Equals(id));

        if (existQuizQuestion is null)
        {
            throw new NotFoundException($"This QuizQuestion is not found with Id-{id}");
        }
        return mapper.Map<QuizQuestionResultDto>(existQuizQuestion);
    }
}
