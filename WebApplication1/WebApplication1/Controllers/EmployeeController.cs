using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeListViewModel empListModel = new EmployeeListViewModel();

            //实例化员工信息业务呈
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            //员工原始数据列表，获取来自业务层类的数据
            var listEmp = empBL.GetEmployeeList();
            //员工原始数据加工后的视图数据列表，当前状态是空的 
            var listEmpVm = new List<EmployeeViewModel>();
            //通过循环遍历员工原始数据数组，将数据一个一个的转化，并加入listEmpVm
            foreach (var item in listEmp)
            {
                EmployeeViewModel empVmObj = new EmployeeViewModel();
                empVmObj.EmployeeId = item.Id;
                empVmObj.EmployeeName = item.Name;
                empVmObj.EmployeeSalary = item.Salary.ToString("C");
                if (item.Salary > 10000)
                {
                    empVmObj.EmployeeCrade = "土豪";
                }
                else
                {
                    empVmObj.EmployeeCrade = "土鳖";
                }

                listEmpVm.Add(empVmObj);
            }
            //将处理过的数据列表送给强视图类型对象
            empListModel.EmloyeeViewList = listEmpVm;


            string greeting;
            DateTime dt = DateTime.Now;
            int hour = dt.Hour;

            if (hour < 12)
            {
                greeting = "早上好哦";
            }
            else
            {
                greeting = "下午好哦";
            }
            empListModel.Greeting = greeting;
            empListModel.UserName = "小鱼";

            return View(empListModel);
        }
        public ActionResult AddNew()
        {
            return View("CreateEmployee");
        }

        public ActionResult Save(Employee emp)
        {
            //将数据保存
            //实例化员工信息业务层
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            empBL.AddEmployee(emp);
            //抓取表单中的姓名与工资
            //return (emp.Name + "----" + emp.Salary.ToString());

            return new RedirectResult("index"); //跳转到index（RedirectResult:跳转）
        }
        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            empBL.Delete(id);
            return new RedirectResult("/Employee/Index");
        }
        //获取编辑的id
        public ActionResult Edit(int id)
        {
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            Employee emp = empBL.Query(id);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {

            //实例化员工信息业务呈
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            empBL.Edit(emp);
            return new RedirectResult("index"); //跳转到index（RedirectResult:跳转）
        }
        public ActionResult Search(string searchSrting)
        {
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            var queryResult = empBL.Search(searchSrting);
            return View(queryResult);
        }
    }
}
    
