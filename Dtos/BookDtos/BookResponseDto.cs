using System;
using BookReviewApp.Dtos.GenreDtos;

namespace BookReviewApp.Dtos.BookDtos;

public class BookResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Description { get; set; }  = string.Empty;
    public int ReleaseYear { get; set; }
    public GenreResponseDto GenreDto { get; set; } = new();
}
