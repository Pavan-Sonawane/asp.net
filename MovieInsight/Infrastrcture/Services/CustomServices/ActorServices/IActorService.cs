using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcture.Services.General_Services
{
    public interface IActorService
    {
        Task<IEnumerable<ActorViewModel>> GetAllAsync();
        Task<ActorViewModel> GetByIdAsync(int id);
        Task AddAsync(ActorInsertModel entity);
        Task UpdateAsync(ActorInsertModel entity);
        Task DeleteAsync(int id); 
    }
}
