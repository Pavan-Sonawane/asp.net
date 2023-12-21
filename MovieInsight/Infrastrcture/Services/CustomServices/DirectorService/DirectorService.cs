using Domain.Models;
using Domain.ViewModels;
using Infrastrcture.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcture.Services.General_Services.DirectorService
{
    public class DirectorService : IDirectorService
    {
        private readonly IRepository<Directors> _actorepository;

        public DirectorService(IRepository<Directors> actorepository)
        {
            _actorepository = actorepository;
        }

        public Task AddAsync(DirectorInsertModel entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DirectorViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DirectorViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DirectorInsertModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
