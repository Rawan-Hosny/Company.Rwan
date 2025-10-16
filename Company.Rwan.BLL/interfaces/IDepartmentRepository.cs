using Company.Rwan.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Rwan.BLL.interfaces
{
    public interface IDepartmentRepository: IGenericRepository<Department>
    {
        //IEnumerable <Department> GetAll();
        //Department ? Get (int id);
        //int Add(Department model);
        //int Update(Department model);  
        //int Delete(Department model);
    }
}
