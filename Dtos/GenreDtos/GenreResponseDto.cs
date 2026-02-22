using System;

namespace BookReviewApp.Dtos.GenreDtos;

public class GenreResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
