using Domain.Models;
using Domain.ViewModels;
using Infrastrcture.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcture.Services.CustomServices.GenereService
{
    public class GenereService : IGenere
    {
        private readonly IRepository<Genres> _repository;

        public GenereService(IRepository<Genres> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Genres>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Genres> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
