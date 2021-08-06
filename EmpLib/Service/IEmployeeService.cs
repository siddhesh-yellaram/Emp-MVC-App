using EmpLib.Model;
using System.Collections.Generic;

namespace EmpLib.Service
{
    public interface IEmployeeService
    {
        List<Dept> GetListOfDept();
        List<Employee> GetListOfEmployess(int deptNo);
    }
}