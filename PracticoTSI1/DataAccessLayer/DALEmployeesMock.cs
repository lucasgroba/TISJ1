using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALEmployeesMock : IDALEmployees
    {
        private List<Employee> employeesRepository = new List<Employee>()
        {
            new PartTimeEmployee(){Id = 1,Name="lucas1",StartDate = new DateTime(),HourlyRate = 100,SalXHora=200,},
            new PartTimeEmployee(){Id = 2,Name="lucas2",StartDate = new DateTime(),HourlyRate = 150,SalXHora=200},
            new PartTimeEmployee(){Id = 3,Name="lucas3",StartDate = new DateTime(),HourlyRate = 200,SalXHora=200},
            new PartTimeEmployee(){Id = 4,Name="lucas4",StartDate = new DateTime(),HourlyRate = 250,SalXHora=200},
            new PartTimeEmployee(){Id = 5,Name="lucas5",StartDate = new DateTime(),HourlyRate = 300,SalXHora=200},
            new FullTimeEmployee(){Id = 6,Name="lucas6",StartDate = new DateTime(),Salary=30000},
            new FullTimeEmployee(){Id = 7,Name="lucas7",StartDate = new DateTime(),Salary=30000},
            new FullTimeEmployee(){Id = 8,Name="lucas8",StartDate = new DateTime(),Salary=30000},
            new FullTimeEmployee(){Id = 9,Name="lucas9",StartDate = new DateTime(),Salary=30000},
            new FullTimeEmployee(){Id = 10,Name="lucas10",StartDate = new DateTime(),Salary=30000},
        };

        public void AddEmployee(Employee emp)
        {
            employeesRepository.Add(emp);
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int id)
        {
            foreach (var empleado in employeesRepository) {
                if (empleado.Id.Equals(id)) {
                    employeesRepository.Remove(empleado);
                    return;
                }
            }
            
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee emp)
        {
            this.DeleteEmployee(emp.Id);
            this.AddEmployee(emp);
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            return employeesRepository;
        }

        public Employee GetEmployee(int id)
        {
            foreach (var empleado in employeesRepository)
            {
                if (empleado.Id.Equals(id))
                {
                    return empleado;
                }
            }
            throw new NotImplementedException();
        }
    }
}
