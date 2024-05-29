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
    public class AuthorService : IAuthorService
    {
        private readonly BaseContext _context;
        public AuthorService(BaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Author>> GetAllAuthors()
        {

            return await _context.Authors.Where(a => !a.IsDeleted).Include(a => a.Books).ToListAsync();
        }
        public async Task<Author> GetAuthorById(int Id)
        {
            return await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == Id);
        }
        public async Task<Author> CreateAuthor(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }
        public async Task<Author> UpdateAuthor(int Id, Author author)
        {
            var existingAuthor = await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == Id);
            if (existingAuthor == null)
            {
                return null;
            }

            // Actualiza solo los campos que no sean nulos o vacíos
            if (!string.IsNullOrEmpty(author.Name))
            {
                existingAuthor.Name = author.Name;
            }

            if (!string.IsNullOrEmpty(author.LastName))
            {
                existingAuthor.LastName = author.LastName;
            }

            if (!string.IsNullOrEmpty(author.Email))
            {
                existingAuthor.Email = author.Email;
            }

            if (!string.IsNullOrEmpty(author.Nationality))
            {
                existingAuthor.Nationality = author.Nationality;
            }

            // En este caso, manejamos el booleano de forma explícita
            existingAuthor.IsDeleted = author.IsDeleted;

            // Opcional: si quieres actualizar libros también, pero con cuidado de no reemplazar todo el listado inadvertidamente
            if (author.Books != null && author.Books.Any())
            {
                existingAuthor.Books = author.Books;
            }

            await _context.SaveChangesAsync();
            return existingAuthor;
        }




        public async Task<bool> DeleteAuthor(int Id)
        {
            var author = await _context.Authors.FindAsync(Id);
            if (author == null)
            {
                return false;
            }
            author.IsDeleted = true;
            _context.Entry(author).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Author>> GetDeletedAuthors()
        {
            return await _context.Authors.Where(a => a.IsDeleted).Include(a => a.Books).ToListAsync();
        }


    }
}