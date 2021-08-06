using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpLib.Service;
using EmpLib.Model;
using EmpMvcApp.Models;

namespace EmpMvcApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            EmpAndDeptVM vm = new EmpAndDeptVM();
            vm.Dept = _service.GetListOfDept();
            Session["dept"] = new SelectList(_service.GetListOfDept(), "DEPTNO", "DNAME");
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(EmpAndDeptVM vm)
        {
            int deptNo = Convert.ToInt32(Request.Form["Department"]);
            vm.Dept = _service.GetListOfDept();
            vm.Emps = _service.GetListOfEmployess(deptNo);
            return View(vm);
        }
    }
}