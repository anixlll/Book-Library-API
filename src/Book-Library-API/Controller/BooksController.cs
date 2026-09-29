using Book_Library_API.Models;
using Microsoft.AspNetCore.Mvc;
using Book_Library_API.Services;
using Book_Library_API.DTOs;

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
    public async Task<List<BookDto>> GetBooks()
    {
        var books = await _bookService.GetBooks();

        return books.Select(book => new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Pages = book.Pages,
            Year = book.Year
        }).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> GetBookById(int id)
    {
        var book = await _bookService.GetBookById(id);

        if (book == null)
        {
            return NotFound();
        }

        var bookDto = new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Pages = book.Pages,
            Year = book.Year
        };

        return bookDto;
    }

    [HttpPost]
    public async Task<ActionResult<BookDto>> AddBook(CreateBookDto dto)
    {
        var book = new Book
        {
            Title = dto.Title,
            Author = dto.Author,
            Pages = dto.Pages,
            Year = dto.Year
        };
        
        var newBook = await _bookService.AddBook(book);
        
        var bookDto = new BookDto
        {
            Id = newBook.Id,
            Title = newBook.Title,
            Author = newBook.Author,
            Pages = newBook.Pages,
            Year = newBook.Year
        };
        
        return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, bookDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BookDto>> UpdateBook(int id, UpdateBookDto dto)
    {
        var book = new Book
        {
            Title = dto.Title,
            Author = dto.Author,
            Pages = dto.Pages,
            Year = dto.Year
        };
        
        var updatedBook = await _bookService.UpdateBook(id, book);

        if (updatedBook == null)
        {
            return NotFound();
        }

        var bookDto = new BookDto
        {
            Id = updatedBook.Id,
            Title = updatedBook.Title,
            Author = updatedBook.Author,
            Pages = updatedBook.Pages,
            Year = updatedBook.Year
        };

        return bookDto;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var deleted = await _bookService.DeleteBook(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}