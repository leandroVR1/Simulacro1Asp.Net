using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Simulacro1.Interfaces;
using Simulacro1.Models;

namespace Simulacro1.Controllers
{
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
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _bookService.GetAllBooks());
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Book>> GetBook(int Id)
        {
            var book = await _bookService.GetBookById(Id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            var createdBook = await _bookService.CreateBook(book);
            return CreatedAtAction("GetBook", new {id=createdBook.Id},createdBook);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<Book>> UpdateBook(int Id, Book book)
        {
            var updatedBook = await _bookService.UpdateBook(Id, book);
            if (updatedBook == null)
            {
                return NotFound();
            }
            return Ok(updatedBook);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteBook(int Id)
        {
            var result = await _bookService.DeleteBook(Id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpGet("deleted")]
        public async Task<IActionResult> GetDeletedBooks()
        {
            return Ok(await _bookService.GetDeletedBooks());
        }
    }
    
}