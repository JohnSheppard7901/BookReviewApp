using System;
using BookReviewApp.Dtos.GenreDtos;
using BookReviewApp.Models;
using BookReviewApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenreController: ControllerBase
{
    private readonly GenreService _genreService;

    public GenreController(GenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GenreResponseDto>>> GetAll()
    {
        var genres = await _genreService.GetAllAsync();
        return Ok(genres);
    }

    [HttpGet]
    public async Task<ActionResult<GenreResponseDto>> GetById()
    {
        return null;
    }

    [HttpPost]
    public async Task<ActionResult<GenreResponseDto>> Create([FromBody] GenreCreateDto dto)
    {
        var createdDto = _genreService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetAll), new {id = createdDto.Id}, createdDto);
    }

}
