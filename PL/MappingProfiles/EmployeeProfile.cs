using AutoMapper;
using DAL.Entity;
using PL.ViewModels;

namespace PL.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeVM,Employee>();
            CreateMap<Employee,EmployeeVM>();
        }
    }
}
