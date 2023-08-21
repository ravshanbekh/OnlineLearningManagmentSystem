using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Lesson;
using Service.Interfaces;

namespace OnlineLearningManagmentSystem.Controllers;

public class LessonController : BaseController
{
    private readonly ILessonService lessonService;

    public LessonController(ILessonService lessonService)
    {
        this.lessonService = lessonService;
    }

    [HttpPost("crete")]
    public async Task<IActionResult> PostAsync(LessonCreationDto lessonCreationDto)
    {
        var result = await this.lessonService.AddAsync(lessonCreationDto);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(LessonUpdateDto lessonUpdateDto)
    {
        var result = await this.lessonService.ModifyAsync(lessonUpdateDto);
        return Ok(result);
    }
    [HttpPost("delete/{id:long}")]
    public async Task<IActionResult> PostAsync(long id)
    {
        var result = await this.lessonService.RemoveAsync(id);
        return Ok(result);
    }
    [HttpPost("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var result = await this.lessonService.RetrieveByIdAsync(id);
        return Ok(result);
    }
    [HttpPost("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await this.lessonService.RetrieveAllAsync();
        return Ok(result);
    }
}
