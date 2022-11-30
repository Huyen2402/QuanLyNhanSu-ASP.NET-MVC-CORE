using QuaMetMoi.Interfaces;
using QuaMetMoi.Models;
using System.Linq.Expressions;

namespace QuaMetMoi.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ManageEmployeesTestContext _context;
        public GenericRepository(ManageEmployeesTestContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        //public T Login(string tk, string pass)
        //{
        //    return _context.Set<T>().Find(tk, pass);
        //}
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public T FindOne(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().SingleOrDefault(expression);
        }
    }
}
