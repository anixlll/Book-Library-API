using Book_Library_API.Models;

namespace Book_Library_API.Services;

public class BookService : IBookService
{
    private readonly List<Book> _books = new();

    public List<Book> GetBooks()
    {
        return _books.ToList(); // Kopie der Liste
    }
}