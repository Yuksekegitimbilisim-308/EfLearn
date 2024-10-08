using EfLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EfLearn.Repository
{
    public class Repository<T> : IRepository<T> where T : class,IBaseEntity,new()
    {
        AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Add(T entity)
        {
           _context.Set<T>().Add(entity);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

       

        public void Update(T entity)
        {
            var oldEntity = GetById(entity.Id);
            _context.Set<T>().Remove(oldEntity);
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
    }
}
