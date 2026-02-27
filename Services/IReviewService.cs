using System;
using BookReviewApp.Dtos.ReviewDtos;

namespace BookReviewApp.Services;

public interface IReviewService
{
    Task<IEnumerable<ReviewResponseDto>> GetAllAsync();
    Task<ReviewResponseDto?> GetAsync(Guid id);
    Task<ReviewResponseDto> CreateAsync(ReviewCreateDto dto);
    Task<ReviewResponseDto?> UpdateAsync(Guid id, ReviewUpdateDto dto);
    Task DeleteAsync(Guid id);

    Task<IEnumerable<ReviewResponseDto>> GetByBookAsync(Guid bookId);
    Task<IEnumerable<ReviewResponseDto>> GetByUserAsync(Guid userId);
}
