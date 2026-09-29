using Book_Library_API.Models;

namespace Book_Library_API.Services;

public interface IBookService
{
    Task<List<Book>> GetBooks();
    Task<Book?> GetBookById(int id);
    Task<Book> AddBook(Book book);
    Task<Book?> UpdateBook(int id, Book book);
    Task<bool> DeleteBook(int id);
}