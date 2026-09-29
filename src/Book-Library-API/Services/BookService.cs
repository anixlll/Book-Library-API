using Book_Library_API.Data;
using Book_Library_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_Library_API.Services;

public class BookService : IBookService
{
    private readonly AppDbContext _context;

    public BookService(AppDbContext context)
    {
        _context = context;
    }

    public List<Book> GetBooks()
    {
        return _context.Books.ToList();
    }

    public Book? GetBookById(int id)
    {
        return _context.Books.FirstOrDefault(b => b.Id == id);
    }

    public Book AddBook(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();

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

        _context.SaveChanges();

        return oldBook;
    }

    public bool DeleteBook(int id)
    {
        var book = GetBookById(id);

        if (book == null)
        {
            return false;
        }

        _context.Books.Remove(book);
        _context.SaveChanges();

        return true;
    }
}