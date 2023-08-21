using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Course;
using Service.DTOs.User;
using Service.Interfaces;

namespace OnlineLearningManagmentSystem.Controllers;

public class CourseController:BaseController
{
    private readonly ICourseService courseService;

    public CourseController(ICourseService courseService)
    {
        this.courseService = courseService;
    }

    [HttpPost("crete")]
    public async Task<IActionResult> PostAsync(CourseCreationDto courseCreationDto)
    {
        var result = await this.courseService.AddAsync(courseCreationDto);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(CourseUpdateDto courseUpdateDto)
    {
        var result = await this.courseService.ModifyAsync(courseUpdateDto);
        return Ok(result);
    }
    [HttpPost("delete/{id:long}")]
    public async Task<IActionResult> PostAsync(long id)
    {
        var result = await this.courseService.RemoveAsync(id);
        return Ok(result);
    }
    [HttpPost("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var result = await this.courseService.RetrieveByIdAsync(id);
        return Ok(result);
    }
    [HttpPost("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await this.courseService.RetrieveAllAsync();
        return Ok(result);
    }
}
