using Company.Rwan.BLL.interfaces;
using Company.Rwan.DAL.Models;
using Company.Rwan.PL.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Company.Rwan.PL.Controllers
{
    public class EmployeeController : Controller
    {
        
            private readonly IEmployeeRepository _employeeRepository;
            public EmployeeController(IEmployeeRepository employeeRepository)
            {
            _employeeRepository = employeeRepository;
            }
            [HttpGet]
            public IActionResult Index()
            {
                var employees = _employeeRepository.GetAll();

                return View(employees);
            }
            [HttpGet]
            public IActionResult Create()
            {
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
                        CreateAt = model.CreateAt

                    };
                    var count = _employeeRepository.Add(employee);
                    if (count > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                return View(model);
            }

            [HttpGet]
            public IActionResult Details(int? id, string ViewName = "Details")
            {
                if (id is null) return BadRequest("Invalid Id");
                var employee = _employeeRepository.Get(id.Value);
                if (employee is null) return NotFound(new { StatusCode = 404, message = $"Employee With Id:{id} is not found" });
                return View(ViewName, employee);
            }
            [HttpGet]

            public IActionResult Edit(int? id)
            {
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
                CreateAt = employee.CreateAt

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
                    CreateAt = model.CreateAt

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
               
                return Details(id, "Delete");
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
