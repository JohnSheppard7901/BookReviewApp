using BookReviewApp.Dtos.BookDtos;
using BookReviewApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewApp.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;


     public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookResponseDto>>> GetAll()
    {
        var books = await _bookService.GetAllAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookResponseDto>> GetById(Guid id)
    {
        var book = await _bookService.GetAsync(id);
        if (book == null)
            return NotFound();

        return Ok(book);
    }

    [HttpPost]
    public async Task<ActionResult<BookResponseDto>> Create([FromBody] BookCreateDto dto)
    {
        var createdBook = await _bookService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = createdBook.Id }, createdBook);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BookResponseDto>> Update(Guid id, [FromBody] BookUpdateDto dto)
    {
        var updatedBook = await _bookService.UpdateAsync(id, dto);
        if (updatedBook == null)
            return NotFound();

        return Ok(updatedBook);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _bookService.DeleteAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

}
