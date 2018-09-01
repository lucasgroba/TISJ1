using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    [ServiceContract]
    public interface IServiceEmployees
    {
        [OperationContract]
        [WebInvoke]
        void AddEmployee(Employee emp);
        [OperationContract]
        [WebInvoke]
        void DeleteEmployee(int id);
        [OperationContract]
        [WebInvoke]
        void UpdateEmployee(Employee emp);
        [OperationContract]
        [WebGet]
        List<Employee> GetAllEmployees();
        [OperationContract]
        [WebGet]
        Employee GetEmployee(int id);
        [OperationContract]
        [WebGet]
        double CalcPartTimeEmployeeSalary(int idEmployee, int hours);
    }
}
