using System.Linq;
using PayRollApplication.Models;

namespace PayRollApplication.Files.Shared {
    public static class GetWeek {
        public static Week ReturnObject(int userId, int weekId) {
            using (DataModelEntities db = new DataModelEntities()) {
                //replace with stored procedure
                Week weekObj = db.Weeks.Where(a => a.UserId.Equals(userId) && a.WeekId.Equals(weekId)).FirstOrDefault();
                if (weekObj != null) {
                    return weekObj;
                } else {
                    Week weekObj1 = new Week();
                    weekObj1.UserId = userId;
                    weekObj1.WeekId = weekId;
                    weekObj1.SunHours = 0;
                    weekObj1.MonHours = 0;
                    weekObj1.TuesHours = 0;
                    weekObj1.WedsHours = 0;
                    weekObj1.ThursHours = 0;
                    weekObj1.FriHours = 0;
                    weekObj1.SatHours = 0;
                    weekObj1.TotalHours = 0;
                    weekObj1.status = "unsaved";
                    return weekObj1;
                }
            }
        }
    }
}