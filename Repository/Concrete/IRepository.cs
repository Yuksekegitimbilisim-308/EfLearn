using EfLearn.Entities;
using System.Collections.Generic;

namespace EfLearn.Repository
{
    public interface IRepository<T> where T : class,IBaseEntity,new()
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
    }
}
