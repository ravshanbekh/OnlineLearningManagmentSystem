using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Enrollment;
using Service.Interfaces;

namespace OnlineLearningManagmentSystem.Controllers;

public class EnrollmentController : BaseController
{
    private readonly IEnrollmentService enrollmentService;

    public EnrollmentController(IEnrollmentService enrollmentService)
    {
        this.enrollmentService = enrollmentService;
    }

    [HttpPost("crete")]
    public async Task<IActionResult> PostAsync(EnrollmentCreationDto enrollmentCreationDto)
    {
        var result = await this.enrollmentService.AddAsync(enrollmentCreationDto);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(EnrollmentUpdateDto enrollmentUpdateDto)
    {
        var result = await this.enrollmentService.ModifyAsync(enrollmentUpdateDto);
        return Ok(result);
    }
    [HttpPost("delete/{id:long}")]
    public async Task<IActionResult> PostAsync(long id)
    {
        var result = await this.enrollmentService.RemoveAsync(id);
        return Ok(result);
    }
    [HttpPost("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var result = await this.enrollmentService.RetrieveByIdAsync(id);
        return Ok(result);
    }
    [HttpPost("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await this.enrollmentService.RetrieveAllAsync();
        return Ok(result);
    }
}
