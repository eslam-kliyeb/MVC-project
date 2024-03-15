using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DAL.Entity;
using AutoMapper;
using DAL.Migrations;
using PL.ViewModels;
using DAL.Entity;
using Department = DAL.Entity.Department;
namespace PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentController(IUnitOfWork unitOfWork,IMapper mapper){
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Index
        public IActionResult Index(string searchValue)
        {
            if (string.IsNullOrEmpty(searchValue))
            {
                var departments = _unitOfWork._departmentRepository.GetAll();
                return View(_mapper.Map<IEnumerable<DepartmentVM>>(departments));
            }
            else
            {
                var departments = _unitOfWork._departmentRepository.GetAllByName(searchValue);
                return View(_mapper.Map<IEnumerable<DepartmentVM>>(departments));
            }
        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create(){return View(new DepartmentVM());}

        [HttpPost]
        public IActionResult Create(DepartmentVM departmentVm)
        {
            if (ModelState.IsValid)
            {
                var department = _mapper.Map<DepartmentVM,Department>(departmentVm);
                _unitOfWork._departmentRepository.Add(department);
                if (_unitOfWork.Complete() > 0)
                {
                    TempData["MessageCreate"] = "Department Created Successfully";
                }
                return RedirectToAction(nameof(Index));
            }
            else return View(departmentVm);
        }
        #endregion

        #region Details
        public IActionResult Details(int? id) => ReturnViewWithDepartment(id, nameof(Details));
        #endregion

        #region Update
        [HttpGet]
        public IActionResult Update(int? id) => ReturnViewWithDepartment(id, nameof(Update));
        [HttpPost]
        public IActionResult Update(DepartmentVM departmentVm , [FromRoute] int id)
        {
            if(id!= departmentVm.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                var department = _mapper.Map<DepartmentVM, Department>(departmentVm);
                _unitOfWork._departmentRepository.Update(department);
                if (_unitOfWork.Complete() > 0)
                {
                    TempData["MessageUpdate"] = "Department Update Successfully";
                }
                ;
                return RedirectToAction(nameof(Index));
            }
            else return View(departmentVm);
        }
        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(int? id) => ReturnViewWithDepartment(id, nameof(Delete));
        [HttpPost]
        public IActionResult Delete(DepartmentVM departmentVm , [FromRoute] int id)
        {
            if (id != departmentVm.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                var department = _mapper.Map<DepartmentVM, Department>(departmentVm);
                _unitOfWork._departmentRepository.Delete(department);
                if (_unitOfWork.Complete() > 0)
                {
                    TempData["MessageDelete"] = "Department Delete Successfully";
                }
                return RedirectToAction(nameof(Index));
            }
            else return View(departmentVm);
        }
        #endregion

        private IActionResult ReturnViewWithDepartment(int? id,string viewName)
        {
            if (!id.HasValue) return BadRequest();
            var department = _unitOfWork._departmentRepository.GetById(id.Value);
            if (department is null) return NotFound();

            return View(viewName, _mapper.Map<DepartmentVM>(department));
        }
    }
}
