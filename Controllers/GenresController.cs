using System;
using BookReviewApp.Dtos.GenreDtos;
using BookReviewApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewApp.Controllers;

[ApiController]
[Route("[controller]")]
public class GenresController: ControllerBase
{
    private readonly GenreService _genreService;

    public GenresController(GenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GenreResponseDto>>> GetAll()
    {
        var genres = await _genreService.GetAllAsync();
        return Ok(genres);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GenreResponseDto>> GetById(Guid id)
    {
        var genre = await _genreService.GetAsync(id);
        if (genre == null)
            return NotFound();

        return Ok(genre);
    }

    [HttpPost]
    public async Task<ActionResult<GenreResponseDto>> Create([FromBody] GenreCreateDto dto)
    {
        var createdDto = await _genreService.CreateAsync(dto);
        // 201 Created
        return CreatedAtAction(nameof(GetById), new {id = createdDto.Id}, createdDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<GenreResponseDto>> Update(Guid id, [FromBody] GenreUpdateDto updateDto)
    {
        var genre = await _genreService.UpdateAsync(id, updateDto);
        if (genre == null)
            return NotFound();

        return Ok(genre);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<GenreResponseDto>> Delete(Guid id)
    {
        try
        {
            await _genreService.DeleteAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

}
