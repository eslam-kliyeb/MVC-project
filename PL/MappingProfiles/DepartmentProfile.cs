using AutoMapper;
using DAL.Entity;
using PL.ViewModels;
namespace PL.MappingProfiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentVM, Department>();
            CreateMap<Department, DepartmentVM>();
        }
    }
}
