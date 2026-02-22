using BookReviewApp.Dtos.ReviewDtos;

namespace BookReviewApp.Dtos.UserDtos;

public class UserResponseDto
{
    public Guid Id { get; private set; }

    public string Username { get; set; } = string.Empty;
 
    public string Email { get; set; } = string.Empty;

    public List<ReviewResponseDto> ReviewsDtos { get; set; } = new();
}
