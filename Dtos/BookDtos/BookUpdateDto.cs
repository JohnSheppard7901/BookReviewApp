using System;
using System.ComponentModel.DataAnnotations;

namespace BookReviewApp.Dtos.BookDtos;

public class BookUpdateDto
{
    [StringLength(200)]
    public string? Title { get; set; }

    [StringLength(200)]
    public string? Author { get; set; }

    public string? Description { get; set; }

    [Range(0, 2100)]
    public int? ReleaseYear { get; set; }

    public Guid? GenreId { get; set; }
}
