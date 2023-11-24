using Domain.Models;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public  class Service<T>:IService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;
        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            T entity = Get(id);
            _repository.Remove(entity);
            _repository.Delete(entity);
        }

        public T Get(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public void Insert(T entity)
        {
            _repository.Insert(entity);
        }
        public void Update(T entity)
        {
            _repository.Update(entity);
        }
    }
    
}
