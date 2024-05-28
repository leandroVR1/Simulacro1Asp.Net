using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro1.Models;

namespace Simulacro1.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(int Id);
        Task<Book> CreateBook(Book book);
        Task<Book> UpdateBook(int Id ,Book book);
        Task<bool> DeleteBook(int Id);
        Task <IEnumerable <Book>> GetDeletedBooks();


    }
}