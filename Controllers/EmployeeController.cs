using PayRollApplication.Files.Employee;
using PayRollApplication.Files.Shared;
using PayRollApplication.Models;
using PayRollApplication.ViewModels.Employee;
using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace PayRollApplication.Controllers {
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CurrentWeek()
        {
            Session["contextDate"] = DateTime.Now;
            return RedirectToAction("TimeSheet", new
            {
                contextId = EmployeeFunctions.returnWeekofYear(DateTime.Now),
                contextDate = DateTime.Now
            });
        }

        public ActionResult TimeSheet(int contextId, DateTime contextDate)
        {
            WeekViewModel WeekModel = new WeekViewModel();
            Debug.WriteLine(contextDate);
            //Get WeekObject
            WeekModel.theWeek = GetWeek.ReturnObject(((UserProfile)Session["User"]).UserId, contextId);
            WeekModel.MyDate = contextDate;
            return View(WeekModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeDate(WeekViewModel contextWeekModel)
        {

            Session["contextDate"] = contextWeekModel.MyDate;
            return RedirectToAction("TimeSheet", new
            {
                contextId = EmployeeFunctions.returnWeekofYear(contextWeekModel.MyDate),
                contextDate = contextWeekModel.MyDate
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTimesheet(WeekViewModel contextWeekModel)
        {
            //Add UserId to current Week object
            contextWeekModel.theWeek.UserId = ((UserProfile)Session["User"]).UserId;
            //contextWeek.WeekId = contextWeek.weekNum;
            EmployeeFunctions.addWeek(contextWeekModel.theWeek);
            return RedirectToAction("TimeSheet", new
            {
                contextId = contextWeekModel.theWeek.WeekId,
                //context session because no other way to preserve date input
                //from week view when submitting a form via partial
                contextDate = Session["contextDate"]
            });
        }

        public ActionResult EmployeeDashboard()
        {
            return View();
        }
    }
}