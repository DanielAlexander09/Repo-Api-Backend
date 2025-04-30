using Microsoft.AspNetCore.Mvc;
using ApiBook.Core.Application.Interfaces;
using ApiBook.Core.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBook.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookInterface _bookService;

        public BooksController(IBookInterface bookService)
        {
            _bookService = bookService;
        }

        // GET api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookViewModels>>> GetBooks()
        {
            try
            {
                var books = await _bookService.GetBooksAsync();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error getting books: {ex.Message}");
            }
        }

        // GET api/books/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BookViewModels>> GetBook(int id)
        {
            try
            {
                var book = await _bookService.GetBookByIdAsync(id);
                if (book == null)
                    return NotFound($"Book with ID {id} not found");
                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error getting book: {ex.Message}");
            }
        }

        // POST api/books
        [HttpPost]
        public async Task<ActionResult<BookViewModels>> CreateBook([FromBody] BookViewModels book)
        {
            try
            {
                var created = await _bookService.CreateBookAsync(book);
                return CreatedAtAction(nameof(GetBook), new { id = created.id }, created);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating book: {ex.Message}");
            }
        }

        // PUT api/books/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookViewModels book)
        {
            try
            {
                var existing = await _bookService.GetBookByIdAsync(id);
                if (existing == null)
                    return NotFound($"Book with ID {id} not found");

                await _bookService.UpdateBookAsync(id, book);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating book: {ex.Message}");
            }
        }

        // DELETE api/books/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                var existing = await _bookService.GetBookByIdAsync(id);
                if (existing == null)
                    return NotFound($"Book with ID {id} not found");

                await _bookService.DeleteBookAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting book: {ex.Message}");
            }
        }
    }
}

