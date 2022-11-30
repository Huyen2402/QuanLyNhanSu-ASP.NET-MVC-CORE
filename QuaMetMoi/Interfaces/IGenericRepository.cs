﻿using System.Linq.Expressions;

namespace QuaMetMoi.Interfaces
{
    public interface IGenericRepository<T> 
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        T FindOne(Expression<Func<T, bool>> expression);
       
    }
}
