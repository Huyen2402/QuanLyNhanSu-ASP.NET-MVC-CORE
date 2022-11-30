using QuaMetMoi.Interfaces;

namespace QuaMetMoi.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employee { get; }
        int Complete();
    }
}