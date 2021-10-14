using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EmployeeInfoService.Models;

namespace EmployeeInfoService.DAL
{
    public class Employee_DbContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public Employee_DbContext(): base("cs")
        {

        }
    }
}
