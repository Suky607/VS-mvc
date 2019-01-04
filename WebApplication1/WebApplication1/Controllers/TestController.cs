using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public string GetString()
        {
            return "hello world! MVC!";
        }
        public Customer getCustomer()
        {
            Customer ct = new Customer();
            ct.CustomerName = "abc";
            ct.Address = "det";
            return ct;
        }

        //    public ActionResult GetView()
        //    {





        //        Employee emp = new Employee();
        //        emp.Name = "小鱼";
        //        emp.Salary = 20000;

        //        EmployeeViewModel vmEmp = new EmployeeViewModel();
        //        vmEmp.EmployeeName = emp.Name;
        //        vmEmp.EmployeeSalary = emp.Salary.ToString("C");

        //        if(emp.Salary>10000)
        //        {
        //            vmEmp.EmployeeCrade = "土豪";
        //        }
        //        else
        //        {
        //            vmEmp.EmployeeCrade = "土鳖";
        //        }

        //        //vmEmp.UserName = "Suky";


        //        string greeting;
        //        DateTime dt = DateTime.Now;
        //        int hour = dt.Hour;

        //        if (hour < 12)
        //        {
        //            greeting = "早上好哦";
        //        }
        //        else
        //        {
        //            greeting = "下午好哦";
        //        }

        //         //vmEmp.Greeting = greeting;
        //        return View("MyView",vmEmp);
        //    }

        //}
    }
}