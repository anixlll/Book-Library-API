using Book_Library_API.Models;
using Microsoft.AspNetCore.Mvc;
using Book_Library_API.Services;

namespace Book_Library_API.Controller;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public List<Book> GetBooks()
    {
        return _bookService.GetBooks();
    }

    [HttpGet("{id}")]
    public ActionResult<Book> GetBookById(int id)
    {
        var book = _bookService.GetBookById(id);

        if (book == null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    public ActionResult<Book> AddBook(Book book)
    {
        var newBook = _bookService.AddBook(book);
        return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
    }

    [HttpPut("{id}")]
    public ActionResult<Book> UpdateBook(int id, Book book)
    {
        var updatedBook = _bookService.UpdateBook(id, book);

        if (updatedBook == null)
        {
            return NotFound();
        }

        return updatedBook;
    }

    [HttpDelete("{id}")]
    public ActionResult<Book> DeleteBook(int id)
    {
        var deletedBook = _bookService.DeleteBook(id);

        if (deletedBook == null)
        {
            return NotFound();
        }

        return deletedBook;
    }
}