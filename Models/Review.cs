using System;
using System.ComponentModel.DataAnnotations;

namespace BookReviewApp.Models;

public class Review
{
    public Guid Id { get; private set; }

    [Range(1, 5)]
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    public Guid BookId { get; set; }
    [Required]
    public Book Book { get; set; } = null!;

    [Required]
    public Guid UserId { get; set; }
    [Required]
    public User User { get; set; } = null!;
}
