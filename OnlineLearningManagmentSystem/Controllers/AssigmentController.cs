using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Assigment;
using Service.DTOs.User;
using Service.Interfaces;

namespace OnlineLearningManagmentSystem.Controllers;

public class AssigmentController:BaseController
{
    private readonly IAssigmentService assigmentService;

    public AssigmentController(IAssigmentService assigmentService)
    {
        this.assigmentService = assigmentService;
    }

    [HttpPost("crete")]
    public async Task<IActionResult> PostAsync(AssigmentCreationDto assigmentCreationDto)
    {
        var result = await this.assigmentService.AddAsync(assigmentCreationDto);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(AssigmentUpdateDto assigmentUpdateDto)
    {
        var result = await this.assigmentService.ModifyAsync(assigmentUpdateDto);
        return Ok(result);
    }
    [HttpPost("delete/{id:long}")]
    public async Task<IActionResult> PostAsync(long id)
    {
        var result = await this.assigmentService.RemoveAsync(id);
        return Ok(result);
    }
    [HttpPost("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var result = await this.assigmentService.RetrieveByIdAsync(id);
        return Ok(result);
    }
    [HttpPost("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await this.assigmentService.RetrieveAllAsync();
        return Ok(result);
    }
}
