using System;
using BookReviewApp.Dtos.UserDtos;
using BookReviewApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewApp.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController: ControllerBase
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetAll()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponseDto>> Get(Guid id)
    {
        var user = await _userService.GetAsync(id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserResponseDto>> Create(UserCreateDto dto)
    {
        var createdUser = await _userService.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = createdUser.Id }, createdUser);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<UserResponseDto>> Update(Guid id, UserUpdateDto dto)
    {
        var updatedUser = await _userService.UpdateAsync(id, dto);

        if (updatedUser == null)
            return NotFound();

        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _userService.DeleteAsync(id);
        return NoContent();
    }
}
