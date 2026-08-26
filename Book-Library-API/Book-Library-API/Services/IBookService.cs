using Book_Library_API.Models;

namespace Book_Library_API.Services;

public interface IBookService
{
    List<Book> GetBooks();
}