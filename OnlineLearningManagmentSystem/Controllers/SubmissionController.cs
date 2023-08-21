using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Submission;
using Service.Interfaces;

namespace OnlineLearningManagmentSystem.Controllers;

public class SubmissionController : BaseController
{
    private readonly ISubmissionService submissionService;

    public SubmissionController(ISubmissionService submissionService)
    {
        this.submissionService = submissionService;
    }

    [HttpPost("crete")]
    public async Task<IActionResult> PostAsync(SubmissionCreationDto submissionCreationDto)
    {
        var result = await this.submissionService.AddAsync(submissionCreationDto);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(SubmissionUpdateDto submissionUpdateDto)
    {
        var result = await this.submissionService.ModifyAsync(submissionUpdateDto);
        return Ok(result);
    }
    [HttpPost("delete/{id:long}")]
    public async Task<IActionResult> PostAsync(long id)
    {
        var result = await this.submissionService.RemoveAsync(id);
        return Ok(result);
    }
    [HttpPost("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var result = await this.submissionService.RetrieveByIdAsync(id);
        return Ok(result);
    }
    [HttpPost("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await this.submissionService.RetrieveAllAsync();
        return Ok(result);
    }
}
