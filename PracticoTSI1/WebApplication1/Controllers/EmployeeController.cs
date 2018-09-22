using BusinessLogicLayer;
using Shared.Entities;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;

namespace WebServicesREST.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        IBLEmployees blHandler = new BLEmployees(new DataAccessLayer.DALEmployeesEF());

        public IHttpActionResult Get()
        {

            List<Employee> lisEmp = blHandler.GetAllEmployees();
            List<DTOEmployee> DTOlist = new List<DTOEmployee>();
            for(int i =0; i<lisEmp.Count(); i++)
            {
                DTOEmployee emp = new DTOEmployee();

                if (lisEmp[i] is FullTimeEmployee)
                {
                    FullTimeEmployee lista = (FullTimeEmployee)lisEmp[i];
                    emp.full = true;
                    emp.id = lista.Id;
                    emp.name = lista.Name;
                    emp.Salary = lista.Salary;
                    emp.StartDate = lista.StartDate;
                    DTOlist.Add(emp);

                }
                else
                {
                    PartTimeEmployee lista = (PartTimeEmployee)lisEmp[i];
                    emp.full = true;
                    emp.id = lista.Id;
                    emp.name = lista.Name;
                    emp.HourlyRate = lista.HourlyRate;
                    emp.StartDate = lista.StartDate;
                    DTOlist.Add(emp);
                }
            }
            return Ok(DTOlist);
        }

        public IHttpActionResult Get(int id)
        {
            Employee lisEmp = blHandler.GetEmployee(id);
            DTOEmployee emp = new DTOEmployee();

            if (lisEmp is FullTimeEmployee)
            {
                FullTimeEmployee lista = (FullTimeEmployee)lisEmp;
                emp.full = true;
                emp.id = lista.Id;
                emp.name = lista.Name;
                emp.Salary = lista.Salary;
                emp.StartDate = lista.StartDate;

            }
            else {
                PartTimeEmployee lista = (PartTimeEmployee)lisEmp;
                emp.full = true;
                emp.id = lista.Id;
                emp.name = lista.Name;
                emp.HourlyRate = lista.HourlyRate;
                emp.StartDate = lista.StartDate;
            }
            
            return Ok(emp);
        }

        public HttpResponseMessage Post([FromBody]DTOEmployee emp)
        {
            if (emp != null)
            {
                if (emp.full)
                {
                    FullTimeEmployee full = new FullTimeEmployee();
                    full.Id = emp.id;
                    full.Name = emp.name;
                    full.Salary = emp.Salary;
                    full.StartDate = emp.StartDate;
                    blHandler.AddEmployee(full);
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent("200")
                    };
                }
                else
                {
                    PartTimeEmployee full = new PartTimeEmployee();
                    full.Id = emp.id;
                    full.Name = emp.name;
                    full.HourlyRate = emp.HourlyRate;
                    full.StartDate = emp.StartDate;
                    blHandler.AddEmployee(full);
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent("200")
                    };
                }
            }
            else {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("400")
                };
            }

        }

        public HttpResponseMessage Put([FromBody]DTOEmployee emp)
        {
            if (emp != null) { 
                if (emp.full)
                {
                    FullTimeEmployee full = new FullTimeEmployee();
                    full.Id = emp.id;
                    full.Name = emp.name;
                    full.Salary = emp.Salary;
                    full.StartDate = emp.StartDate;
                    blHandler.UpdateEmployee(full);
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent("200")
                    };
                }
                else
                {
                    PartTimeEmployee full = new PartTimeEmployee();
                    full.Id = emp.id;
                    full.Name = emp.name;
                    full.HourlyRate = emp.HourlyRate;
                    full.StartDate = emp.StartDate;
                    blHandler.UpdateEmployee(full);
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent("200")
                    };
                }
            }
            else
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("400")
                };
            }
        }
        public HttpResponseMessage Delete(int id )
        {
            blHandler.DeleteEmployee(id);
            return new HttpResponseMessage()
            {
                Content = new StringContent("Employee Eliminado Correctamente")
            };
        }
    }
}
