using System;
using System.ComponentModel.DataAnnotations;

namespace BookReviewApp.Models;

public class User
{
    public Guid Id { get; private set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Username { get; set; } = string.Empty;
    
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public List<Review> Reviews { get; set; } = new();
}
