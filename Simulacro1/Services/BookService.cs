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
    public class BookService : IBookService
    {
        private readonly BaseContext _context;
        public BookService(BaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _context.Books.ToListAsync();
        }
        public async Task<Book> GetBookById(int Id)
        {
            return await _context.Books.FindAsync(Id);
        }
        public async Task<Book> CreateBook(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }
        public async Task<Book> UpdateBook(int Id, Book book)
        {
            var existingBook = await _context.Books.FindAsync(Id);
            if (existingBook == null)
            {
                return null;
            }
            existingBook.Title = book.Title;
            await _context.SaveChangesAsync();
            return existingBook;
        }
        public async Task<bool> DeleteBook(int Id)
        {
            var book = await _context.Books.FindAsync(Id);
            if (book == null)
            {
                return false;
            }
            book.IsDeleted = true;
           _context.Entry(book).State=EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Book>> GetDeletedBooks()
        {
            return await _context.Books.Where(b => b.IsDeleted).ToListAsync();
        }


    }
}