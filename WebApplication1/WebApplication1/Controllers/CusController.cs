using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CusController : Controller
    {
        // GET: Cus
        //public ActionResult Index()
        //{
        //    Customer ct = new Customer();
        //    ct.CustomerName = "我是小鱼";
        //    ct.Address = "柳州职业技术学院";
        //    //ViewData["EmpKey"] = emp;
        //    ViewBag.EmpKey = ct;
        //    return View("CustomerView", ct);
        //}

        public ActionResult CustomerView()
        {

            Customer ct = new Customer();
            ct.CustomerName = "我是小鱼";
            ct.Address = "柳州职业技术学院";
            //ViewData["EmpKey"] = emp;
            ViewBag.EmpKey = ct;
            return View("CustomerView", ct);
        }

    }
}