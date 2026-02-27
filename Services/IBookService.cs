using System;
using BookReviewApp.Dtos.BookDtos;

namespace BookReviewApp.Services;

public interface IBookService
{
    Task<IEnumerable<BookResponseDto>> GetAllAsync();
    Task<BookResponseDto?> GetAsync(Guid id);
    Task<BookResponseDto> CreateAsync(BookCreateDto dto);
    Task<BookResponseDto?> UpdateAsync(Guid id, BookUpdateDto dto);
    Task DeleteAsync(Guid id);
}
