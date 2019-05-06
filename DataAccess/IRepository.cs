using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        T Create(T entity);
        void Update(T entity);
        void Delete(string id);
    }
}