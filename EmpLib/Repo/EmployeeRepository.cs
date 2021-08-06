using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using EmpLib.Model;

namespace EmpLib.Repo
{
    public class EmployeeRepository : IEmployeeRepository
    {
        SqlConnection _sqlCon;
        public EmployeeRepository()
        {
            string conString = ConfigurationManager.ConnectionStrings["sqlserver"].ConnectionString;
            _sqlCon = new SqlConnection(conString);
            _sqlCon.Open();
        }

        public List<Dept> GetDepts()
        {
            List<Dept> dept = new List<Dept>();

            string queryString = "SELECT * FROM EMP_DEPT";
            var cmd = new SqlCommand(queryString,_sqlCon);
            var dataReader = cmd.ExecuteReader();

            string dname, loc;
            int dno;

            while (dataReader.Read())
            {
                dno = Convert.ToInt32(dataReader["DEPTNO"].ToString());
                dname = dataReader["DNAME"].ToString();
                loc = dataReader["LOC"].ToString();

                dept.Add(new Dept { DeptNo = dno, DName = dname, Location = loc });
            }

            dataReader.Close();
            return dept;
        }

        public List<Employee> GetEmployees(int deptNo)
        {
            List<Employee> emps = new List<Employee>();

            string queryString = "SELECT * FROM EMP WHERE DEPTNO = @deptNo";
            var cmd = new SqlCommand(queryString, _sqlCon);
            SqlParameter deptNoParam = new SqlParameter("@deptNo", deptNo);
            cmd.Parameters.Add(deptNoParam);
            var dataReader = cmd.ExecuteReader();

            string designation, ename, hiredate, commission, mgrNo;
            int eno, dno;
            double salary;

            while (dataReader.Read())
            {
                eno = Convert.ToInt32(dataReader["EMPNO"].ToString());
                ename = dataReader["ENAME"].ToString();
                designation = dataReader["JOB"].ToString();
                mgrNo = dataReader["MGR"].ToString();
                hiredate = dataReader["HIREDATE"].ToString();
                salary = Convert.ToDouble(dataReader["SAL"].ToString());
                commission = dataReader["COMM"].ToString();
                dno = Convert.ToInt32(dataReader["DEPTNO"].ToString());

                emps.Add(new Employee { EmpNo = eno, EName = ename, Job = designation, MgrNo = mgrNo, HireDate = hiredate,
                                          Salary = salary, Commission = commission, DeptNo = dno  });
            }

            dataReader.Close();
            return emps;
        }
    }
}
