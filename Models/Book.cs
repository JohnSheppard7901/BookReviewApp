using System;
using System.ComponentModel.DataAnnotations;

namespace BookReviewApp.Models;

public class Book
{
    public Guid Id { get; private set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string Author { get; set; } = string.Empty;

    [Range(0, 2100)]
    public int ReleaseYear { get; set; }

    [Required]
    public Guid GenreId { get; set; }
    [Required]
    public Genre Genre { get; set; } = null!;

    public List<Review> Reviews { get; set; } = new();
}
