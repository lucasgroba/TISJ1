using BusinessLogicLayer;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{

    public class ServiceEmployees : IServiceEmployees
    {
        private static IBLEmployees blHandler;

        public ServiceEmployees()
        {
            blHandler = Program.blHandler;
        }

        public void AddEmployee(Employee emp)
        {
            blHandler.AddEmployee(emp);
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int id)
        {
            blHandler.DeleteEmployee(id);
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee emp)
        {
            blHandler.UpdateEmployee(emp);
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            return blHandler.GetAllEmployees();
            throw new NotImplementedException();
        }

        public Employee GetEmployee(int id)
        {
            return blHandler.GetEmployee(id);
            throw new NotImplementedException();
        }

        public double CalcPartTimeEmployeeSalary(int idEmployee, int hours)
        {
            return blHandler.CalcPartTimeEmployeeSalary(idEmployee, hours);
            throw new NotImplementedException();
        }
    }
}
