using System.Collections.Generic;
using Business.Models;

namespace Business
{
    public interface IManager<T>
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        T Create(T model);
        void Update(T model);
        void Delete(string id);
    }
}