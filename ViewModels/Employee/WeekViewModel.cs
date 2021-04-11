using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayRollApplication.Models;

namespace PayRollApplication.ViewModels.Employee {
    public class WeekViewModel {
        public Week theWeek { get; set; }
        public DateTime MyDate { get; set; }

    }
}