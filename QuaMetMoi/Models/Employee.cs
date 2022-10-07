using System;
using System.Collections.Generic;

namespace QuaMetMoi.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
