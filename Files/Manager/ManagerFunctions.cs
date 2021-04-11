using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using PayRollApplication.Models;

namespace PayRollApplication.Files.Manager { 
    public static class ManagerFunctions {
        public static List<string> getEmployeeNames(List<Week> weeks) {
            //userid variable from session
            //int managerId = ((UserProfile)HttpContext.Current.Session["User"]).UserId;
            //Data Context 
            List<string> returnNames = new List<string>();
            using (DataModelEntities db = new DataModelEntities()) {  
                //Get array of userids, query only returns userid array
                foreach (var i in weeks) {
                    //Replace with stored procedure
                    returnNames.Add(db.UserProfiles.Where(a => a.UserId == i.UserId)
                                                             .Select(a => a.UserName)
                                                             .FirstOrDefault());
                }
                Debug.WriteLine("///Employee Names Function:///");
                Debug.WriteLine(returnNames);
                return returnNames;
            }
        }

        public static List<Week> weeksFromstatus(string status) {
            //Try to find pending
            try {
                int manid = ((UserProfile)HttpContext.Current.Session["User"]).UserId;
                using (DataModelEntities db = new DataModelEntities()) {
                    //Replace with stored procedure
                    List<Week> returnWeeks = db.Weeks.Where(a => a.UserProfile.managerId == (manid) && a.status == (status)).ToList();
                    if (returnWeeks != null)
                    {
                        return returnWeeks;
                    } else {
                        return new List<Week>();
                    }
                }
            } catch {
                //Return an empty week if any errors
                return new List<Week>();
            }
        }
        public static void changeStatus(Week contextWeek) {
            Debug.WriteLine("///Changing Week Status///");
            using (DataModelEntities db = new DataModelEntities()) {
                Week obj = Files.Shared.GetWeek.ReturnObject(contextWeek.UserId, contextWeek.WeekId);
                Debug.WriteLine(obj.WeekId);
                Debug.WriteLine("Before status" + obj.status);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                obj.status = contextWeek.status;
                Debug.WriteLine("After Status" + obj.status);
                Debug.WriteLine(db.SaveChanges() + " changes have been made to the database");
            }
        }
    }
}