using System;
using System.ComponentModel.DataAnnotations;

namespace BookReviewApp.Dtos.BookDtos;

public class BookUpdateDto
{
    public string? Title { get; set; }

    public string? Author { get; set; }

    public string? Description { get; set; }

    [Range(0, 2100)]
    public int? ReleaseYear { get; set; }

    public Guid? GenreId { get; set; }
}
