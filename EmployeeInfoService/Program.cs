using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EmployeeInfoService.Services;

namespace EmployeeInfoService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(EmployeeService));

            host.Open();
            Console.WriteLine("Employee service is running");
            Console.WriteLine("press any key to stop");
            Console.ReadKey();
            host.Close();
        }
    }
}
