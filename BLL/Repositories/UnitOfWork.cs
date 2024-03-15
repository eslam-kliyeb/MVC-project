using BLL.Interfaces;
using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork 
    {
        private Lazy<IDepartmentRepository> department;
        private Lazy<IEmployeeRepository> employee;
        private DataContext dataContext;
        public UnitOfWork(DataContext context)
        {
            department = new Lazy<IDepartmentRepository>(new DepartmentRepository(context));
            employee = new Lazy<IEmployeeRepository>(new EmployeeRepository(context));
            dataContext = context;
        }
        public IDepartmentRepository _departmentRepository => department.Value;
        public IEmployeeRepository _employeeRepository => employee.Value;

        public int Complete()
        {
            return dataContext.SaveChanges();
        }
        public void Dispose()
        {
            dataContext.Dispose();
        }
    }
}
