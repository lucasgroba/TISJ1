using DataAccessLayer;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLEmployees : IBLEmployees
    {
        private IDALEmployees _dal;
        public BLEmployees(IDALEmployees dal)
        {
            _dal = dal;
        }
        public void AddEmployee(Employee emp)
        {
            if (emp != null)
            {
                _dal.AddEmployee(emp);
            }

        }
        public void DeleteEmployee(int id)
        {
            if (id != 0)
            {                _dal.DeleteEmployee(id);
            }
        }

        public void UpdateEmployee(Employee emp)
        {
            if (emp != null)
            {
                _dal.UpdateEmployee(emp);
            }
        }

        public List<Employee> GetAllEmployees()
        {

            return _dal.GetAllEmployees();
        }

        public Employee GetEmployee(int id)
        {

            return _dal.GetEmployee(id);
        }

        public double CalcPartTimeEmployeeSalary(int idEmployee, int hours)
        {
            if (idEmployee != 0)
            {
                PartTimeEmployee emp = (PartTimeEmployee)_dal.GetEmployee(idEmployee);
                if (emp != null)
                {

                    return emp.SalXHora * hours;
                }
                else
                {
                    return 0;
                }

            }
            else
            {
                return 0;
            }
        }
    }
}
