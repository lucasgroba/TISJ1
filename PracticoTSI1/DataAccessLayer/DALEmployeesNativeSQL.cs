using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALEmployeesNativeSQL : IDALEmployees
    {
        


        public void AddEmployee(Employee emp)
        {
            using (var ctx = new Model.TESTEntitiesFinal())
            {
                
                if (emp is PartTimeEmployee) {
                    PartTimeEmployee Temp = (PartTimeEmployee)emp;
                    int rows = ctx.Database.ExecuteSqlCommand("INSERT INTO Employee (Emp_Id, Name, Start_date,Rate, Type_Emp) values (" +
                    Temp.Id.ToString() + " ," +
                    Temp.Name.ToString() + " ," +
                    Temp.StartDate.ToString() + " ," +
                    Temp.HourlyRate.ToString() + " ," + " 1 "
                    + ")");
                }
                else
                {
                    FullTimeEmployee Temp = (FullTimeEmployee)emp;
                    int rows = ctx.Database.ExecuteSqlCommand("INSERT INTO Employee (Emp_Id, Name, Start_date,Salary, Type_Emp) values (" +
                    Temp.Id.ToString() + " ," +
                    Temp.Name.ToString() + " ," +
                    Temp.StartDate.ToString() + " ," +
                    Temp.Salary.ToString() + " ," + " 0 "
                    + ")");
                }
            }

        }

        public void DeleteEmployee(int id)
        {
            using (var ctx = new Model.TESTEntitiesFinal()) {
                int rows = ctx.Database.ExecuteSqlCommand("DELETE FROM Employee WHERE Emp_Id = " + id.ToString());
            }



        }

        public void UpdateEmployee(Employee emp)
        {
            using (var ctx = new Model.TESTEntitiesFinal()) {
                if (emp is PartTimeEmployee)
                {
                    PartTimeEmployee Temp = (PartTimeEmployee)emp;
                    int rows = ctx.Database.ExecuteSqlCommand("UPDATE Employee SET Name = "+
                        Temp.Name.ToString() + " ," +
                        "Start_date = "+ Temp.StartDate.ToString() + " ," +
                        "Rate = "+ Temp.HourlyRate.ToString() +" Type_Emp = 1");

                }
                else {
                    FullTimeEmployee Temp = (FullTimeEmployee)emp;
                    int rows = ctx.Database.ExecuteSqlCommand("UPDATE Employee SET Name = " +
                        Temp.Name.ToString() + " ," +
                        " Start_date = " + Temp.StartDate.ToString() + " ," +
                        " Salary = " + Temp.Salary.ToString() + " Type_Emp = 0");

                }

            }
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> listaEmp = new List<Employee>();
            using (var ctx = new Model.TESTEntitiesFinal())
            {
                var EmployeeList = ctx.Employees.SqlQuery("SELECT * FROM Employee ").ToList();
                foreach (var empDB in EmployeeList) {
                    if (empDB is Model.PartTimeEmployee)
                    {
                        Model.PartTimeEmployee emp = (Model.PartTimeEmployee)empDB;
                        PartTimeEmployee nuevo = new PartTimeEmployee();
                        nuevo.Id = emp.EmployeeId;
                        nuevo.Name = emp.Name;
                        nuevo.StartDate = emp.StartDate;
                        nuevo.HourlyRate = (Double)emp.HourlyRate;
                        listaEmp.Add(nuevo);
                    }
                    else {
                        Model.FullTimeEmployee emp = (Model.FullTimeEmployee)empDB;
                        FullTimeEmployee nuevo = new FullTimeEmployee();
                        nuevo.Id = emp.EmployeeId;
                        nuevo.Name = emp.Name;
                        nuevo.StartDate = emp.StartDate;
                        nuevo.Salary =(int)emp.Salary;
                        listaEmp.Add(nuevo);
                    }

                }

                return listaEmp;
            }
        }

        public Employee GetEmployee(int id)
        {
            using (var ctx = new Model.TESTEntitiesFinal())
            {
                var empleado = ctx.Employees.SqlQuery("SELECT * FROM Employee WHERE Emp_id = @id ", new SqlParameter("@id", id)).FirstOrDefault();
                if (empleado is Model.PartTimeEmployee)
                {
                    Model.PartTimeEmployee emp = (Model.PartTimeEmployee)empleado;
                    PartTimeEmployee nuevo = new PartTimeEmployee();
                    nuevo.Id = emp.EmployeeId;
                    nuevo.Name = emp.Name;
                    nuevo.StartDate = emp.StartDate;
                    nuevo.HourlyRate = (Double)emp.HourlyRate;
                    return nuevo;
                }
                else
                {
                    Model.FullTimeEmployee emp = (Model.FullTimeEmployee)empleado;
                    FullTimeEmployee nuevo = new FullTimeEmployee();
                    nuevo.Id = emp.EmployeeId;
                    nuevo.Name = emp.Name;
                    nuevo.StartDate = emp.StartDate;
                    nuevo.Salary = (int)emp.Salary;
                    return nuevo;
                }
            }
        }
    }
}
