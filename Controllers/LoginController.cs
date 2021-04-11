using PayRollApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PayRollApplication.Files.Login;

namespace PayRollApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserProfile objUser) {
            if (ModelState.IsValid) {
                GetUser.getProfile(objUser);
                if (((UserProfile)Session["User"]) != null) {
                    UserProfile currentProfile = ((UserProfile)Session["User"]);
                    if (((UserProfile)Session["User"]).type == "manager") {
                        return RedirectToAction("ManagerDashboard", "Manager");
                    } else {
                        return RedirectToAction("EmployeeDashboard", "Employee");
                    }
                } else {
                    return View(objUser);
                }
            }
            return View(objUser);
        }

        public ActionResult Logout() {
            GetUser.logOut();
            return RedirectToAction("Index", "Home");
        }
    }
}