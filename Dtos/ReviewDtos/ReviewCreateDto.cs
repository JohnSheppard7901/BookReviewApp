using System;
using System.ComponentModel.DataAnnotations;

namespace BookReviewApp.Dtos.ReviewDtos;

public class ReviewCreateDto
{
    [Required]
    public Guid UserId { get; set; }

    [Required]
    public Guid BookId { get; set; }

    [Range(1,5)]
    public int Rating { get; set; }

    public string? Comment { get; set; }
}
