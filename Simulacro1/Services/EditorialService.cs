using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Simulacro1.Interfaces;
using Simulacro1.Models;
using Simulacro1.Data;

namespace Simulacro1.Services
{
    public class EditorialService : IEditorialService
    {
        private readonly BaseContext _context;
        public EditorialService(BaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Editorial>> GetAllEditorials()
        {
            return await _context.Editorials.Where(a => !a.IsDeleted).ToListAsync();
        }
        public async Task<Editorial> GetEditorialById(int Id)
        {
            return await _context.Editorials.FindAsync(Id);
        }
        public async Task<Editorial> CreateEditorial(Editorial editorial)
        {
            await _context.Editorials.AddAsync(editorial);
            await _context.SaveChangesAsync();
            return editorial;
        }
        public async Task<Editorial> UpdateEditorial(int Id, Editorial editorial)
        {
            var existingEditorial = await _context.Editorials.FindAsync(Id);
            if (existingEditorial == null)
            {
                return null;
            }
            existingEditorial.Name = editorial.Name;
            await _context.SaveChangesAsync();
            return existingEditorial;
        }
        public async Task<bool> DeleteEditorial(int Id)
        {
            var editorial = await _context.Editorials.FindAsync(Id);
            if (editorial == null)
            {
                return false;
            }
            editorial.IsDeleted = true;
            _context.Entry(editorial).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Editorial>> GetDeletedEditorials()
        {
            return await _context.Editorials.Where(a => a.IsDeleted).ToListAsync();
        }
    }
}