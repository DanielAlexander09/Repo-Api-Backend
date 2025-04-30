using System.Collections.Generic;
using System.Threading.Tasks;
using ApiBook.Core.Application.ViewModels;

namespace ApiBook.Core.Application.Interfaces
{
    
    public interface IBookInterface
    {
        Task<IEnumerable<BookViewModels>> GetBooksAsync();

        Task<BookViewModels> GetBookByIdAsync(int id);

        
        Task<BookViewModels> CreateBookAsync(BookViewModels bookView);

        
        Task<BookViewModels> UpdateBookAsync(int id, BookViewModels bookView);

        
        Task<bool> DeleteBookAsync(int id);
    }
}
