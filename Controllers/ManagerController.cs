using System.Diagnostics;
using System.Web.Mvc;
using PayRollApplication.Files.Manager;
using PayRollApplication.ViewModels.Manager;

namespace PayRollApplication.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ManagerDashboard()
        {
            return View();
        }

        public ActionResult ManPendingTimesheet()
        {
            ManagerViewModel theManager = new ManagerViewModel();
            theManager.desiredStatus = "pending";
            theManager.pendingTimesheets = ManagerFunctions.weeksFromstatus("pending");
            theManager.names = ManagerFunctions.getEmployeeNames(theManager.pendingTimesheets);
            return View("ManTimesheet",theManager);
        }

        public ActionResult ManApprovedTimesheet() {
            ManagerViewModel theManager = new ManagerViewModel();
            theManager.desiredStatus = "approved";
            theManager.pendingTimesheets = ManagerFunctions.weeksFromstatus("approved");
            theManager.names = ManagerFunctions.getEmployeeNames(theManager.pendingTimesheets);
            return View("ManTimesheet", theManager);
        }

        public ActionResult ManDeniedTimesheet() {
            ManagerViewModel theManager = new ManagerViewModel();
            theManager.desiredStatus = "denied";
            theManager.pendingTimesheets = ManagerFunctions.weeksFromstatus("denied");
            theManager.names = ManagerFunctions.getEmployeeNames(theManager.pendingTimesheets);
            return View("ManTimesheet", theManager);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeStatus(ManagerViewModel contextVM) {
            ManagerFunctions.changeStatus(contextVM.pendingTimesheets[contextVM.passedItem]);
            Debug.WriteLine(contextVM.desiredStatus);
            if (contextVM.desiredStatus == "approved") {
                return RedirectToAction("ManApprovedTimesheet");
            } else if (contextVM.desiredStatus == "denied") {
                return RedirectToAction("ManDeniedTimesheet");
            } else {
                return RedirectToAction("ManPendingTimesheet");
            }
        }
    }
}