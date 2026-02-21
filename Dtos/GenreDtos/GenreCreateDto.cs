using System.ComponentModel.DataAnnotations;

namespace BookReviewApp.Dtos.GenreDtos;

public class GenreCreateDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
}