using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Repository.EmployeeDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly EmployeeDb _context;
        private readonly DbSet<T> entities;

        public Repository(EmployeeDb context) 
        {
            _context = context;
            entities = _context.Set<T>();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _context.SaveChanges();
        }
        public T Get(int id)
        {
            return entities.SingleOrDefault(e => e.Id == id);
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _context.SaveChanges();
        }
        public void Update(T entity) 
        { 
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            } 
            entities.Update(entity);    
            _context.SaveChanges();
        }
        public void Remove(T entity) 
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");

            }
            entities.Remove(entity);
           
        }
        public void Savechanges()
        {
            _context.SaveChanges();
        }

    }   
}
