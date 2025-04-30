using System.Collections.Generic;
using System.Threading.Tasks;
using ApiBook.Core.Application.ViewModels;

namespace ApiBook.Core.Application.Interfaces
{
    
       public interface IAutorInterface
       {
        
        Task<IEnumerable<AutorViewModels>> GetAuthorsAsync();

        
        Task<AutorViewModels> GetAuthorByIdAsync(int id);

    
        Task<AutorViewModels> CreateAuthorAsync(AutorViewModels autorView);

        
        Task<AutorViewModels> UpdateAuthorAsync(int id, AutorViewModels autorView);

       
        Task<bool> DeleteAuthorAsync(int id);
    }
}

