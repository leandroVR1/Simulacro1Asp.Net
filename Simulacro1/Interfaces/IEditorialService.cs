using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro1.Models;

namespace Simulacro1.Interfaces
{
    public interface IEditorialService
    {
        Task<IEnumerable<Editorial>> GetAllEditorials();
        Task<Editorial> GetEditorialById(int Id);
        Task<Editorial> CreateEditorial(Editorial editorial);
        Task<Editorial> UpdateEditorial(int Id ,Editorial editorial);
        Task<bool> DeleteEditorial(int Id);
        Task <IEnumerable <Editorial>> GetDeletedEditorials();
        
    }
}