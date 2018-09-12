using BusinessLogicLayer;
using Shared.Entities;
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
            List<Employee> lista = blHandler.GetAllEmployees();
            return Ok(lista);
        }

        public IHttpActionResult Get(int id)
        {
            Employee lista = blHandler.GetEmployee(id);
            return Ok(lista);
        }

        public HttpResponseMessage Post(Employee emp)
        {
            blHandler.AddEmployee(emp);

            return new HttpResponseMessage()
            {
                Content = new StringContent("Employee Creado Correctamente ")
            };
        }

        public HttpResponseMessage Put(Employee emp)
        {
            blHandler.UpdateEmployee(emp);
            return new HttpResponseMessage()
            {
                Content = new StringContent("Employee Modificado Correctamente")
            };
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
