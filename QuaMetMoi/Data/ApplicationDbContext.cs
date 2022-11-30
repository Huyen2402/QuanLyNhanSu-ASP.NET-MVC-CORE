

using Microsoft.EntityFrameworkCore;
using QuaMetMoi.Models;

namespace ManageEmployees.Data
{
    public class ApplicationDbContext : ManageEmployeesTestContext
    {


        public ApplicationDbContext(DbContextOptions<ManageEmployeesTestContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employee { get; set; }
    }
}