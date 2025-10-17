using Company.Rwan.BLL.interfaces;
using Company.Rwan.DAL.Data.Contexts;
using Company.Rwan.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Rwan.BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly CompanyDBContext _context;
        public EmployeeRepository(CompanyDBContext context) : base(context)
        {
            _context = context;
        }

        public CompanyDBContext Context { get; }

        public List<Employee> GetByName(string name)
        {
            return _context.Employees.Include(E =>E .Department).Where(E => E.Name.ToLower().Contains(name.ToLower())).ToList();
        }
        //    private readonly CompanyDBContext _context;
        //    public EmployeeRepository(CompanyDBContext context)
        //    { 
        //        _context = context;
        //    }

        //    public IEnumerable<Employee> GetAll()
        //    {
        //        return _context.Employees.ToList();
        //    }
        //    public Employee? Get(int id)
        //    {
        //        return _context.Employees.Find(id);
        //    }
        //    public int Add(Employee model)
        //    {
        //        _context.Employees.Add(model);
        //        return _context.SaveChanges();
        //    }
        //    public int Update(Employee model)
        //    {
        //        _context.Employees.Update(model);
        //        return _context.SaveChanges();
        //    }

        //    public int Delete(Employee model)
        //    {
        //        _context.Employees.Remove(model);
        //        return _context.SaveChanges();
        //    }
    }
}
