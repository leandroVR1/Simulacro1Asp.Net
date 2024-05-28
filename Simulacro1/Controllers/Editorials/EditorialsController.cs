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
    public class EditorialsController : ControllerBase
    {
        private readonly IEditorialService _editorialService;
        public EditorialsController(IEditorialService editorialService)
        {
            _editorialService = editorialService;
        }
        [HttpGet]
        public async Task<IActionResult> GetEditorials()
        {
            return Ok(await _editorialService.GetAllEditorials());
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Editorial>> GetEditorial(int Id)
        {
            var editorial = await _editorialService.GetEditorialById(Id);
            if (editorial == null)
            {
                return NotFound();
            }
            return Ok(editorial);
        }
        [HttpPost]
        public async Task<ActionResult<Editorial>> CreateEditorial(Editorial editorial)
        {
            var createdEditorial = await _editorialService.CreateEditorial(editorial);
            return CreatedAtAction("GetEditorial", new {id=createdEditorial.Id},createdEditorial);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<Editorial>> UpdateEditorial(int Id, Editorial editorial)
        {
            var updatedEditorial = await _editorialService.UpdateEditorial(Id, editorial);
            if (updatedEditorial == null)
            {
                return NotFound();
            }
            return Ok(updatedEditorial);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteEditorial(int Id)
        {
            var result = await _editorialService.DeleteEditorial(Id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpGet("deleted")]
        public async Task<IActionResult> GetDeletedEditorials()
        {
            return Ok(await _editorialService.GetDeletedEditorials());
        }
        
    }
}