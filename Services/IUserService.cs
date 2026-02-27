using System;
using BookReviewApp.Dtos.UserDtos;

namespace BookReviewApp.Services;

public interface IUserService
{
    Task<IEnumerable<UserResponseDto>> GetAllAsync();
    Task<UserResponseDto?> GetAsync(Guid id);
    Task<UserResponseDto> CreateAsync(UserCreateDto dto);
    Task<UserResponseDto?> UpdateAsync(Guid id, UserUpdateDto dto);
    Task DeleteAsync(Guid id);
}
