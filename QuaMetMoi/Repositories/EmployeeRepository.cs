using Microsoft.EntityFrameworkCore;
using QuaMetMoi.Interfaces;
using QuaMetMoi.Models;
using QuaMetMoi.Repositories;

namespace ManageEmployees.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(ManageEmployeesTestContext context) : base(context)
        {
        }
    }
}