using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcture.Services.General_Services.DirectorService
{
    public interface IDirectorService
    {
        Task<IEnumerable<DirectorViewModel>> GetAllAsync();
        Task<DirectorViewModel> GetByIdAsync(int id);
        Task AddAsync(DirectorInsertModel entity);
        Task UpdateAsync(DirectorInsertModel entity);
        Task DeleteAsync(int id);
    }
}
