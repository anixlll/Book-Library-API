using System.ComponentModel.DataAnnotations;

namespace Book_Library_API.Models;

public class Book
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Author { get; set; }
    [Range(1, 10000)]
    public int Pages { get; set; }
    [Range(1, 2026)]
    public int Year { get; set; }
}