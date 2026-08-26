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
}