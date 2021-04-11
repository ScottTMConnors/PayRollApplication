using System.Linq;
using System.Web;
using PayRollApplication.Models;

namespace PayRollApplication.Files.Login {
    public class GetUser {

        public static void logOut() {
            HttpContext.Current.Session.Clear();
        }

        public static void getProfile(UserProfile objUser) {
            //Data Context
            using (DataModelEntities db = new DataModelEntities()) {
                //Query UserProfile object
                UserProfile obj = db.UserProfiles.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                if (obj != null) {
                    //Set user session to the returned UserProfile
                    HttpContext.Current.Session["User"] = obj;
                    HttpContext.Current.Session["UserName"] = obj.UserName;
                }
            }
        }
    }
}