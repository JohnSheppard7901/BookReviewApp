using System;
using System.ComponentModel.DataAnnotations;

namespace BookReviewApp.Models;

public class Genre
{
    public Guid Id { get; set; } = Guid.NewGuid();  

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    public List<Book> Books { get; set; } = new();
}
