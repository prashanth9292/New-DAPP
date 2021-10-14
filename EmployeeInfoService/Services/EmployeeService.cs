using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeInfoService.Contract;
using EmployeeInfoService.Models;
using System.ServiceModel;
using System.Data.Entity;
using EmployeeInfoService.DAL;


namespace EmployeeInfoService.Services
{
    [ServiceBehavior(InstanceContextMode =InstanceContextMode.Single)]
    public class EmployeeService : IEmployeeService
    { 
        private readonly Employee_DbContext dalEmp = new Employee_DbContext();
        public void DeleteEmployee(int id)
        {
            try
            {
                Employee emp = dalEmp.Employees.SingleOrDefault(em => em.EmployeeId == id);
                dalEmp.Employees.Remove(emp);
                Console.WriteLine("Record deleted!");
                dalEmp.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString()); //Throw a fault exception
            }
        }

        public Employee FindEmployee(int id)
        {
            try
            {
                Employee emp = dalEmp.Employees.SingleOrDefault(em => em.EmployeeId == id);
                return emp;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }

        public void InsertEmployee(Employee emp)
        {
            try
            {
                dalEmp.Employees.Add(emp);
                dalEmp.SaveChanges();
                Console.WriteLine("Record inserted!");
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }

        public void UpdateEmployee(Employee emp)
        {
            try
            {
                Employee res = dalEmp.Employees.SingleOrDefault(em => em.EmployeeId == emp.EmployeeId);
                res.EmployeeName = emp.EmployeeName;
                res.DateOfBirth = emp.DateOfBirth;
                res.CurrentAddress = emp.CurrentAddress;
                res.ContactNo = emp.ContactNo;
                res.ManagerId = emp.ManagerId;
                res.PermanentAddress = emp.PermanentAddress;
                dalEmp.SaveChanges();
                Console.WriteLine("Record updated!");
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
    }
}
