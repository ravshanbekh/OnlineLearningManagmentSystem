using Microsoft.AspNetCore.Mvc;
using Service.DTOs.QuizQuestion;
using Service.Interfaces;

namespace OnlineLearningManagmentSystem.Controllers;

public class QuizQuestionController : BaseController
{
    private readonly IQuizQuestionService quizQuestionService;

    public QuizQuestionController(IQuizQuestionService quizQuestionService)
    {
        this.quizQuestionService = quizQuestionService;
    }

    [HttpPost("crete")]
    public async Task<IActionResult> PostAsync(QuizQuestionCreationDto quizQuestionCreationDto)
    {
        var result = await this.quizQuestionService.AddAsync(quizQuestionCreationDto);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(QuizQuestionUpdateDto quizQuestionUpdateDto)
    {
        var result = await this.quizQuestionService.ModifyAsync(quizQuestionUpdateDto);
        return Ok(result);
    }
    [HttpPost("delete/{id:long}")]
    public async Task<IActionResult> PostAsync(long id)
    {
        var result = await this.quizQuestionService.RemoveAsync(id);
        return Ok(result);
    }
    [HttpPost("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var result = await this.quizQuestionService.RetrieveByIdAsync(id);
        return Ok(result);
    }
    [HttpPost("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await this.quizQuestionService.RetrieveAllAsync();
        return Ok(result);
    }
}
