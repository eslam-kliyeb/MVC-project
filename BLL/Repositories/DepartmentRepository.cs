using BLL.Interfaces;
using DAL.Entity;
using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repositories
{
    public class DepartmentRepository : GenericRepository<Department> , IDepartmentRepository
    {
        public DepartmentRepository(DataContext context) : base(context) {}

        public IEnumerable<Department> GetAllByName(string Name)
        {
            return _context.Departments.Where(x => x.Name.ToLower().Contains(Name.ToLower()));
        }
    }
}
