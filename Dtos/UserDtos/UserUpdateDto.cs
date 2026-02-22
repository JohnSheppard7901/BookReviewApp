using System.ComponentModel.DataAnnotations;

namespace BookReviewApp.Dtos.UserDtos;

public class UserUpdateDto
{
    public string? Username { get; set; }
    
    [EmailAddress]
    public string? Email { get; set; }
}
