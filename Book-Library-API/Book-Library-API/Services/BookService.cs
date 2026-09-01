using Book_Library_API.Models;

namespace Book_Library_API.Services;

public class BookService : IBookService
{
    private readonly List<Book> _books = new();

    public BookService()
    {
        _books.Add(new Book
        {
            Id = 1,
            Title = "The Last Days of Socrates",
            Author = "Plato",
            Pages = 256,
            Year = 1954
        });
        
        _books.Add(new Book
        {
            Id = 2,
            Title = "Metamorphosis",
            Author = "Franz Kafka",
            Pages = 70,
            Year = 1915
        });
    }
    
    public List<Book> GetBooks()
    {
        return _books.ToList(); // Kopie der Liste
    }

    public Book? GetBookById(int id)
    {
        return _books.FirstOrDefault(b => b.Id == id);
    }

    public Book AddBook(Book book)
    {
        book.Id = _books.Count > 0 ? _books.Max(b => b.Id) + 1 : 1;

        _books.Add(book);
        return book;
    }
}