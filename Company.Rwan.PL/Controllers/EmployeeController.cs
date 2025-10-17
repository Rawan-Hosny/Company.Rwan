using Company.Rwan.BLL.interfaces;
using Company.Rwan.DAL.Models;
using Company.Rwan.PL.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Company.Rwan.PL.Controllers
{
    public class EmployeeController : Controller
    {
        
            private readonly IEmployeeRepository _employeeRepository;

           private readonly IDepartmentRepository _departmentRepository;
        public EmployeeController(IEmployeeRepository employeeRepository,IDepartmentRepository departmentRepository)
            {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }
            [HttpGet]
            public IActionResult Index(string? SearchInput)
            
            {
           IEnumerable<Employee> employees;
            if (string.IsNullOrEmpty(SearchInput))
            {

                employees = _employeeRepository.GetAll();
            }
            else
            {
                employees = _employeeRepository.GetByName(SearchInput);
            }
                //ViewData["Message"] = "Hello From ViewData";
                //ViewBag.Message = "Hello from ViewBag";
                return View(employees);
               
        }
            [HttpGet]
            public IActionResult Create()
            {
            var departments=_departmentRepository.GetAll();
            ViewData["departments"] = departments;

            return View();
            }
            [HttpPost]
            public IActionResult Create(CreateEmployeeDto model)
            {
                if (ModelState.IsValid)
                {
                    var employee = new Employee()
                    {
                        Name = model.Name,
                        Age = model.Age,
                        Email = model.Email,
                        Address = model.Address,
                        Phone = model.Phone,
                        Salary = model.Salary,
                        IsActive = model.IsActive,
                        IsDeleted = model.IsDeleted,
                        HiringDate = model.HiringDate,
                        CreateAt = model.CreateAt,
                        DepartmentId = model.DepartmentId

                    };
                    var count = _employeeRepository.Add(employee);
                    if (count > 0)
                    {
                    TempData["Message"] = "Employee is Created !!";
                    return RedirectToAction(nameof(Index));
                    }
                }
                return View(model);
            }

            [HttpGet]
            public IActionResult Details(int? id)
            {
                if (id is null) return BadRequest("Invalid Id");
                var employee = _employeeRepository.Get(id.Value);
                if (employee is null) return NotFound(new { StatusCode = 404, message = $"Employee With Id:{id} is not found" });
                return View(employee);
            }
            [HttpGet]

            public IActionResult Edit(int? id)
            {
            var departments = _departmentRepository.GetAll();
            ViewData["departments"] = departments;
            if (id is null) return BadRequest("Invalid Id");
            var employee=_employeeRepository.Get(id.Value);
            if (employee is null) return NotFound(new { StatusCode = 404, message = $"Employee With Id:{id}is not found" });
            var employeedto= new CreateEmployeeDto()
            {
                
                Name = employee.Name,
                Age = employee.Age,
                Email = employee.Email,
                Address = employee.Address,
                Phone = employee.Phone,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                IsDeleted = employee.IsDeleted,
                HiringDate = employee.HiringDate,
                CreateAt = employee.CreateAt,
                DepartmentId = employee.DepartmentId

            };
            return View(employeedto);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Edit([FromRoute] int id, CreateEmployeeDto model)
            {


                if (ModelState.IsValid)
                {
                //if (id != employee.Id) return BadRequest();
                var employee = new Employee()
                {
                    Id = id,
                    Name = model.Name,
                    Age = model.Age,
                    Email = model.Email,
                    Address = model.Address,
                    Phone = model.Phone,
                    Salary = model.Salary,
                    IsActive = model.IsActive,
                    IsDeleted = model.IsDeleted,
                    HiringDate = model.HiringDate,
                    CreateAt = model.CreateAt,
                    DepartmentId = model.DepartmentId

                };
                var count = _employeeRepository.Update(employee);
                    if (count > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                return View(model);
            }

            [HttpGet]
            public IActionResult Delete(int? id)
            {

            if (id is null) return BadRequest("Invalid Id");
            var employee = _employeeRepository.Get(id.Value);
            if (employee is null) return NotFound(new { StatusCode = 404, message = $"Employee With Id:{id} is not found" });
            return View(employee);
        }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Delete([FromRoute] int id, Employee employee)
            {

                if (ModelState.IsValid)
                {
                    if (id != employee.Id) return BadRequest();

                    var count = _employeeRepository.Delete(employee);
                    if (count > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                return View(employee);
            }
        
    }
}
