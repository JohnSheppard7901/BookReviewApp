using System;
using System.ComponentModel.DataAnnotations;

namespace BookReviewApp.Dtos.ReviewDtos;

public class ReviewUpdateDto
{
    [Range(1,5)]
    public int? Rating { get; set; }

    public string? Comment { get; set; }
}
