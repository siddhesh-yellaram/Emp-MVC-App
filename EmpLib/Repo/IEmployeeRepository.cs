using EmpLib.Model;
using System.Collections.Generic;

namespace EmpLib.Repo
{
    public interface IEmployeeRepository
    {
        List<Dept> GetDepts();
        List<Employee> GetEmployees(int deptNo);
    }
}