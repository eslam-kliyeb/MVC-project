using BLL.Interfaces;
using DAL.Context;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee> , IEmployeeRepository
    {
        public EmployeeRepository(DataContext context):base(context) {}

        public IEnumerable<Employee> GetAllByName(string Name)
        {
           return _context.Employees.Include(d=>d.Department).Where(x => x.Name.ToLower().Contains(Name.ToLower()));
        }
    }
}
