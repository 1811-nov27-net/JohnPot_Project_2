using System;
using System.Collections.Generic;

namespace DataAccess.Repo
{
    public interface IRepo<T>
    {
        T GetById(int id);
        List<T> GetAll();
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
