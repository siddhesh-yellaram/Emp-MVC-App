using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmpLib.Repo;
using EmpLib.Model;

namespace EmpLib.Service
{
    public class EmployeeService : IEmployeeService
    {
        public IEmployeeRepository _repo;

        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public List<Dept> GetListOfDept()
        {
            return _repo.GetDepts();
        }

        public List<Employee> GetListOfEmployess(int deptNo)
        {
            return _repo.GetEmployees(deptNo);
        }
    }
}
