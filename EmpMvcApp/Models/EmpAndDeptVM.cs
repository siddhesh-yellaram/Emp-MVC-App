using EmpLib.Model;
using System.Collections.Generic;

namespace EmpMvcApp.Models
{
    public class EmpAndDeptVM
    {
        public List<Dept> Dept { get; set; }
        public List<Employee> Emps { get; set; }

    }
}