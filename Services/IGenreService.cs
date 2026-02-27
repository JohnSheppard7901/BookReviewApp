using System;
using BookReviewApp.Dtos.GenreDtos;

namespace BookReviewApp.Services;

public interface IGenreService
{
    Task<IEnumerable<GenreResponseDto>> GetAllAsync();
    Task<GenreResponseDto?> GetAsync(Guid id);
    Task<GenreResponseDto> CreateAsync(GenreCreateDto dto);
    Task<GenreResponseDto?> UpdateAsync(Guid id, GenreUpdateDto dto);
    Task DeleteAsync(Guid id);
}
