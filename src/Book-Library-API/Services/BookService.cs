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

    public async Task<List<Book>> GetBooks()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book?> GetBookById(int id)
    {
        return await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<Book> AddBook(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return book;
    }

    public async Task<Book?> UpdateBook(int id, Book book)
    {
        var oldBook = await GetBookById(id);

        if (oldBook == null)
        {
            return null;
        }

        oldBook.Title = book.Title;
        oldBook.Author = book.Author;
        oldBook.Pages = book.Pages;
        oldBook.Year = book.Year;

        await _context.SaveChangesAsync();

        return oldBook;
    }

    public async Task<bool> DeleteBook(int id)
    {
        var book = await GetBookById(id);

        if (book == null)
        {
            return false;
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return true;
    }
}