using System;
using System.ComponentModel.DataAnnotations;

namespace BookReviewApp.Dtos.BookDtos;

public class BookCreateDto
{
    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string Author { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [Range(0, 2100)]
    public int ReleaseYear { get; set; }

    [Required]
    public Guid GenreId { get; set; }
}
