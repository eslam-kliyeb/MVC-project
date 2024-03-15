using AutoMapper;
using BLL.Interfaces;
using BLL.Repositories;
using DAL.Entity;
using Microsoft.AspNetCore.Mvc;
using PL.ViewModels;

namespace PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Index
        public IActionResult Index(string searchValue)
        {
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                var employee = _unitOfWork._employeeRepository.GetAll();
                return View(_mapper.Map<IEnumerable<EmployeeVM>>(employee));
            }
            else
            {
                var employee = _unitOfWork._employeeRepository.GetAllByName(searchValue);
                return View(_mapper.Map<IEnumerable<EmployeeVM>>(employee));
            }
        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = _unitOfWork._departmentRepository.GetAll();
            return View(new EmployeeVM());
        }

        [HttpPost]
        public IActionResult Create(EmployeeVM employeeVm)
        {
            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<EmployeeVM, Employee>(employeeVm);
                _unitOfWork._employeeRepository.Add(employee);
                if (_unitOfWork.Complete() > 0)
                {
                    TempData["MessageCreate"] = "Employee Created Successfully";
                }
                return RedirectToAction(nameof(Index));
            }
            else return View(employeeVm);
        }
        #endregion

        #region Details
        public IActionResult Details(int? id) => ReturnViewWithEmployee(id, nameof(Details));
        #endregion

        #region Update
        [HttpGet]
        public IActionResult Update(int? id) => ReturnViewWithEmployee(id, nameof(Update));
        [HttpPost]
        public IActionResult Update(EmployeeVM employeeVm, [FromRoute] int id)
        {
            if (id != employeeVm.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<EmployeeVM, Employee>(employeeVm);
                _unitOfWork._employeeRepository.Update(employee);
                if (_unitOfWork.Complete() > 0)
                {
                    TempData["MessageUpdate"] = "Employee Update Successfully";
                }
                return RedirectToAction(nameof(Index));
            }
            else return View(employeeVm);
        }
        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(int? id) => ReturnViewWithEmployee(id, nameof(Delete));
        [HttpPost]
        public IActionResult Delete(EmployeeVM employeeVm, [FromRoute] int id)
        {
            if (id != employeeVm.Id) return BadRequest();

            var employee = _mapper.Map<EmployeeVM, Employee>(employeeVm);
            employee.Department = null;
            _unitOfWork._employeeRepository.Delete(employee);
            if (_unitOfWork.Complete() > 0)
            {
                TempData["MessageDelete"] = "Employee Delete Successfully";
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion

        private IActionResult ReturnViewWithEmployee(int? id, string viewName)
        {
            if (!id.HasValue) return BadRequest();
            var employee = _unitOfWork._employeeRepository.GetById(id.Value);
            if (employee is null) return NotFound();

            ViewBag.Departments = _unitOfWork._departmentRepository.GetAll();
            return View(viewName, _mapper.Map<EmployeeVM>(employee));
        }
    }
}
