using System;
using BookReviewApp.Dtos.ReviewDtos;
using BookReviewApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewApp.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewsController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReviewResponseDto>>> GetAll()
    {
        var reviews = await _reviewService.GetAllAsync();
        return Ok(reviews);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReviewResponseDto>> GetById(Guid id)
    {
        var review = await _reviewService.GetAsync(id);
        if (review == null)
            return NotFound();

        return Ok(review);
    }

    [HttpPost]
    public async Task<ActionResult<ReviewResponseDto>> Create([FromBody] ReviewCreateDto dto)
    {
        var createdReview = await _reviewService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = createdReview.Id }, createdReview);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ReviewResponseDto>> Update(Guid id, [FromBody] ReviewUpdateDto dto)
    {
        var updatedReview = await _reviewService.UpdateAsync(id, dto);
        if (updatedReview == null)
            return NotFound();

        return Ok(updatedReview);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _reviewService.DeleteAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }


    [HttpGet("ByBook/{bookId}")]
    public async Task<ActionResult<IEnumerable<ReviewResponseDto>>> GetByBook(Guid bookId)
    {
        var reviews = await _reviewService.GetByBookAsync(bookId);
        return Ok(reviews);
    }

    [HttpGet("ByUser/{userId}")]
    public async Task<ActionResult<IEnumerable<ReviewResponseDto>>> GetByUser(Guid userId)
    {
        var reviews = await _reviewService.GetByUserAsync(userId);
        return Ok(reviews);
    }
}