using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALEmployeesEF : IDALEmployees
    {
        public void AddEmployee(Employee emp)
        {
            using (Model.TESTEntitiesFinal DB = new Model.TESTEntitiesFinal())
            {
                if (emp is PartTimeEmployee)
                {
                    PartTimeEmployee empLP = new PartTimeEmployee();
                    Model.PartTimeEmployee nuevo = new Model.PartTimeEmployee();
                    nuevo.EmployeeId = empLP.Id;
                    nuevo.Name = empLP.Name;
                    nuevo.StartDate = empLP.StartDate;
                    nuevo.HourlyRate = empLP.HourlyRate;
                    DB.Employees.Add(nuevo);

                }
                else {
                    FullTimeEmployee empLP = new FullTimeEmployee();
                    Model.FullTimeEmployee nuevo = new Model.FullTimeEmployee();
                    nuevo.EmployeeId = empLP.Id;
                    nuevo.Name = empLP.Name;
                    nuevo.StartDate = empLP.StartDate;
                    nuevo.Salary = empLP.Salary;
                    DB.Employees.Add(nuevo);
                }
                DB.SaveChanges();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (Model.TESTEntitiesFinal DB = new Model.TESTEntitiesFinal())
            {
                DB.Employees.Remove(DB.Employees.Find(id));
                DB.SaveChanges();

            }
        }

        public void UpdateEmployee(Employee emp)
        {
            using (Model.TESTEntitiesFinal DB = new Model.TESTEntitiesFinal()) {
                if(emp != null)
                {
                    if (emp != null) {
                            Model.Employee EmpDB =DB.Employees.Find(emp.Id);
                        if (EmpDB is Model.PartTimeEmployee) {
                            PartTimeEmployee empLP = (PartTimeEmployee)emp;
                            Model.PartTimeEmployee nuevo = (Model.PartTimeEmployee)EmpDB;
                            nuevo.Name = empLP.Name;
                            nuevo.StartDate = empLP.StartDate;
                            nuevo.HourlyRate = empLP.HourlyRate;
                            DB.Employees.Attach(nuevo);

                        }
                        else
                        {
                            FullTimeEmployee empLP = (FullTimeEmployee)emp;
                            Model.FullTimeEmployee nuevo = (Model.FullTimeEmployee)EmpDB;
                            nuevo.Name = empLP.Name;
                            nuevo.StartDate = empLP.StartDate;
                            nuevo.Salary = empLP.Salary;
                            DB.Employees.Attach(nuevo);
                        }
                        DB.SaveChanges();

                    }

                }
            }
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> lista = new List<Employee>();
            using (Model.TESTEntitiesFinal DB = new Model.TESTEntitiesFinal())
            {
                var ListEmp = (from e in DB.Employees select e).ToList() ;
                foreach (Model.Employee emp in ListEmp) {
                    if (emp is Model.PartTimeEmployee)
                    {
                        Model.PartTimeEmployee empDB = (Model.PartTimeEmployee)emp;
                        PartTimeEmployee nuevo = new PartTimeEmployee();
                        nuevo.Id = empDB.EmployeeId;
                        nuevo.Name = empDB.Name;
                        nuevo.StartDate = empDB.StartDate;
                        nuevo.HourlyRate = (Double)empDB.HourlyRate;
                        lista.Add(nuevo);


                    }
                    else {
                        Model.FullTimeEmployee empDB = (Model.FullTimeEmployee)emp;
                        FullTimeEmployee nuevo = new FullTimeEmployee();
                        nuevo.Id = empDB.EmployeeId;
                        nuevo.Name = empDB.Name;
                        nuevo.StartDate = empDB.StartDate;
                        nuevo.Salary = (int)empDB.Salary;
                        lista.Add(nuevo);
                    }
                }
            }
            return lista;

            
        }

        public Employee GetEmployee(int id)
        {
            using (Model.TESTEntitiesFinal DB = new Model.TESTEntitiesFinal())
            {
                var ListEmp = (from e in DB.Employees where e.EmployeeId == id select e).ToList();
                foreach (Model.Employee emp in ListEmp){
                    if (emp is Model.PartTimeEmployee){

                        Model.PartTimeEmployee empDB = (Model.PartTimeEmployee)emp;
                        PartTimeEmployee nuevo = new PartTimeEmployee();
                        nuevo.Id = empDB.EmployeeId;
                        nuevo.Name = empDB.Name;
                        nuevo.StartDate = empDB.StartDate;
                        nuevo.HourlyRate = (Double)empDB.HourlyRate;
                        return nuevo;


                    }
                    else
                    {
                        Model.FullTimeEmployee empDB = (Model.FullTimeEmployee)emp;
                        FullTimeEmployee nuevo = new FullTimeEmployee();
                        nuevo.Id = empDB.EmployeeId;
                        nuevo.Name = empDB.Name;
                        nuevo.StartDate = empDB.StartDate;
                        nuevo.Salary = (int)empDB.Salary;
                        return nuevo;
                    }
                }
                return null;
            }
        }
    }
}
