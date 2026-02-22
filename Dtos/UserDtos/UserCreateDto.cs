using System.ComponentModel.DataAnnotations;

namespace BookReviewApp.Dtos.UserDtos;

public class UserCreateDto
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}