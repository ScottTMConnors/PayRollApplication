using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayRollApplication.Models;

namespace PayRollApplication.ViewModels.Manager {
    public class ManagerViewModel {
        //List of names of week owner of each timesheet returned form a static method
        public List<string> names {get; set;}
        //List of al week objects returned from a static method
        public List<Week> pendingTimesheets {get; set;}
        //Keeps track of which item is being modified
        public int passedItem { get; set; }
        //This is to keep on the same view after page refresh
        public string desiredStatus { get; set; }
    }
}