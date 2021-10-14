using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EmployeeInfoService.Models;

namespace EmployeeInfoService.Contract
{
    [ServiceContract(SessionMode=SessionMode.Required)]
    public interface IEmployeeService 
    {
        [OperationContract]
        void InsertEmployee(Employee emp);

        [OperationContract]
        void DeleteEmployee(int id);

        [OperationContract]
        void UpdateEmployee(Employee emp);

        [OperationContract]
        Employee FindEmployee(int id);
    }
}
