using System;
using System.Diagnostics;
using System.Globalization;
using PayRollApplication.Models;

namespace PayRollApplication.Files.Employee {
    public static class EmployeeFunctions {
        public static void addWeek(Week contextWeek) {
            contextWeek.status = "pending";
            try {
                using (DataModelEntities db = new DataModelEntities())
                {
                    db.Weeks.Add(contextWeek);
                    Debug.WriteLine(db.SaveChanges() + " changes have been made to the database");
                }
            } catch (Exception e) {
                Debug.WriteLine(e);
                using (DataModelEntities db = new DataModelEntities())
                {
                    Week obj = Shared.GetWeek.ReturnObject(contextWeek.UserId, contextWeek.WeekId);
                    db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    obj.SunHours = contextWeek.SunHours;
                    obj.MonHours = contextWeek.MonHours;
                    obj.TuesHours = contextWeek.TuesHours;
                    obj.WedsHours = contextWeek.WedsHours;
                    obj.ThursHours = contextWeek.ThursHours;
                    obj.FriHours = contextWeek.FriHours;
                    obj.SatHours = contextWeek.SatHours;
                    obj.status = contextWeek.status;
                    obj.TotalHours = contextWeek.SunHours +
                                     contextWeek.MonHours +
                                     contextWeek.TuesHours +
                                     contextWeek.WedsHours +
                                     contextWeek.ThursHours +
                                     contextWeek.FriHours +
                                     contextWeek.SatHours;
                    Debug.WriteLine(db.SaveChanges() + " changes have been made to the database");
                }
            }
        }

        public static int returnWeekofYear(DateTime date) {
            int weekInYear = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            return weekInYear;
        }

    }
}