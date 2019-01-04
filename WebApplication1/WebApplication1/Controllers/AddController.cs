using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;


namespace WebApplication1.Controllers
{
    public class AddController : Controller
    {
        // GET: Add
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult AddView()
        {

            AddViewModel a = new AddViewModel();
            a.CustomerName = "小鱼";
            a.Address = "作家";
            a.Name = "林妹妹";
            a.Salary = 2000;
            ViewBag.Employee =a;
            return View("AddView", a);

        }

    }
}