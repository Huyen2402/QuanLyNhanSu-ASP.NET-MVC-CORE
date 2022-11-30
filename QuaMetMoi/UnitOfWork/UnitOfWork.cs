using QuaMetMoi.Models;
using QuaMetMoi.Interfaces;
using QuaMetMoi.Repositories;
using ManageEmployees.Repositories;

namespace QuaMetMoi.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ManageEmployeesTestContext _context;
        public UnitOfWork(ManageEmployeesTestContext context)
        {
            _context = context;
            Employee = new EmployeeRepository(_context);
        }
        public IEmployeeRepository Employee { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}