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
    public class AuthorsController : ControllerBase

    {
        private readonly IAuthorService _authorService;
        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            return Ok(await _authorService.GetAllAuthors());
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Author>> GetAuthor(int Id)
        {
            var author = await _authorService.GetAuthorById(Id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }
        [HttpPost]
        public async Task<ActionResult<Author>> CreateAuthor(Author author)
        {
           var createdAuthor = await _authorService.CreateAuthor(author);
           return CreatedAtAction("GetAuthor", new {id=createdAuthor.Id},createdAuthor);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<Author>> UpdateAuthor(int Id, Author author)
        {
            var updatedAuthor = await _authorService.UpdateAuthor(Id, author);
            if (updatedAuthor == null)
            {
                return NotFound();
            }
            return Ok(updatedAuthor);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAuthor(int Id)
        {
            var result = await _authorService.DeleteAuthor(Id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpGet("deleted")]
        public async Task<IActionResult> GetDeletedAuthors()
        {
            return Ok(await _authorService.GetDeletedAuthors());
        }


     
        
    }
}