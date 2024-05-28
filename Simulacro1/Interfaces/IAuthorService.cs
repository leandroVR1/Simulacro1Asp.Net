using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro1.Models;

namespace Simulacro1.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<Author> GetAuthorById(int Id);
        Task<Author> CreateAuthor(Author author);
        Task<Author> UpdateAuthor(int Id ,Author author);
        Task<bool> DeleteAuthor(int Id);
        Task <IEnumerable <Author>> GetDeletedAuthors();

        
    }
}