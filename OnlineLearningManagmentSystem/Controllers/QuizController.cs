using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Quiz;
using Service.Interfaces;

namespace OnlineLearningManagmentSystem.Controllers;

public class QuizController : BaseController
{
    private readonly IQuizService quizService;

    public QuizController(IQuizService quizService)
    {
        this.quizService = quizService;
    }

    [HttpPost("crete")]
    public async Task<IActionResult> PostAsync(QuizCreationDto quizCreationDto)
    {
        var result = await this.quizService.AddAsync(quizCreationDto);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(QuizUpdateDto quizUpdateDto)
    {
        var result = await this.quizService.ModifyAsync(quizUpdateDto);
        return Ok(result);
    }
    [HttpPost("delete/{id:long}")]
    public async Task<IActionResult> PostAsync(long id)
    {
        var result = await this.quizService.RemoveAsync(id);
        return Ok(result);
    }
    [HttpPost("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var result = await this.quizService.RetrieveByIdAsync(id);
        return Ok(result);
    }
    [HttpPost("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await this.quizService.RetrieveAllAsync();
        return Ok(result);
    }
}
