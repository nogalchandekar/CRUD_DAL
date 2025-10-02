using CRUD_DAL.DAL;
using CRUD_DAL.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_DAL.Controllers
{
	public class HomeController : Controller
	{
        Employee_DAL emp = new Employee_DAL();

        public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddEmployee(VMEmployee vMEmployee)
		{ 
		 return Json(emp.AddEmployee(vMEmployee), JsonRequestBehavior.AllowGet);
        }

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}