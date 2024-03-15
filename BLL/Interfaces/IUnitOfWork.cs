using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IDepartmentRepository _departmentRepository { get; }
        public IEmployeeRepository _employeeRepository { get; }
        public int Complete();
    }
}
