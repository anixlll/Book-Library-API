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

    public Book? UpdateBook(int id, Book book)
    {
        var oldBook = GetBookById(id);

        if (oldBook == null)
        {
            return null;
        }

        oldBook.Title = book.Title;
        oldBook.Author = book.Author;
        oldBook.Pages = book.Pages;
        oldBook.Year = book.Year;

        return oldBook;
    }

    public Book? DeleteBook(int id)
    {
        var book = GetBookById(id);

        if (book == null)
        {
            return null;
        }

        _books.Remove(book);

        return book;
    }
}