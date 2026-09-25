namespace Book_Library_API.DTOs;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }
    public int Year { get; set; }
}