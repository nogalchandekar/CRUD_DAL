using CRUD_DAL.DAL;
using CRUD_DAL.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
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
        public ActionResult List()
        {
            return View();
        }
        public ActionResult UpdateEmployee(int Emp_Id)
        {
			DAL.Employee_DAL emp = new DAL.Employee_DAL();
			VMEmployee vMEmployee = emp.getDataById(Emp_Id);
            vMEmployee = emp.getDataById(Emp_Id);
            return View(vMEmployee);
        }

        [HttpPost]
		public ActionResult AddEmployee(VMEmployee vMEmployee)
		{ 
		 return Json(emp.AddEmployee(vMEmployee), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteEmployee(int Emp_Id)
		{
			return Json(emp.DeleteById(Emp_Id), JsonRequestBehavior.AllowGet);
        }	


        public ActionResult getList()
		{
			return Json(emp.getList(), JsonRequestBehavior.AllowGet);
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