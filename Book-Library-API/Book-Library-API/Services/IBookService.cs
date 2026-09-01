using Book_Library_API.Models;

namespace Book_Library_API.Services;

public interface IBookService
{
    List<Book> GetBooks();
    Book? GetBookById(int id);
    Book AddBook(Book book);
    Book UpdateBook(int id, Book book);
    Book DeleteBook(int id);
}