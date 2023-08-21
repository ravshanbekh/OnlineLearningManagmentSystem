using Microsoft.AspNetCore.Mvc;
using Service.DTOs.User;
using OnlineLearningManagmentSystem.Models;
using Service.Interfaces;

namespace OnlineLearningManagmentSystem.Controllers;

public class UserController : BaseController
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost("crete")]
    public async Task<IActionResult> PostAsync(UserCreationDto userCreationDto)
    {
        var result= await this.userService.AddAsync(userCreationDto);
        return Ok(new Response 
        { 
            Data=result,
            Message="ok",
            StatusCode=200}
        );
    }

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(UserUpdateDto userUpdateDto)
    {
        var result= await this.userService.ModifyAsync(userUpdateDto);
        return Ok(result);
    }
    [HttpPost("delete/{id:long}")]
    public async Task<IActionResult> PostAsync(long id)
    {
        var result = await this.userService.RemoveAsync(id);
        return Ok(result);
    }
    [HttpPost("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var result = await this.userService.RetrieveByIdAsync(id);  
        return Ok(result);
    }
    [HttpPost("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await this.userService.RetrieveAllAsync();
        return Ok(result);
    }
}
