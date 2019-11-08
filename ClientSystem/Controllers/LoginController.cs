using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ClientSystem.Models;

namespace ClientSystem.Controllers
{
    public class LoginController : Controller
    {
        private ClientSystemEntities db = new ClientSystemEntities();
      

        public ActionResult Login()
        {
            return View();
        }


        public JsonResult Check(string email, string password)
        {
            bool value = false;
            if (email == "admin@localhost.local" && password == "admin")
            {
                value = true;
                Session["id"] = "admin";
                Session["name"] = "admin";
                
            }
            else
            {
                string firstName, lastName;
                value = db.UserProfiles.ToList().Exists(p => p.UserEmail.Equals(email, StringComparison.CurrentCultureIgnoreCase)
               && PasswordEncryptDecrypt.Decrypt(p.UserPassword, "sblw-3hn8-sqoy19").Equals(password, StringComparison.CurrentCultureIgnoreCase));
                if (value == true)
                {
                    Session["id"] = db.UserProfiles.Where(x => x.UserEmail == email).FirstOrDefault().UserId;
                    firstName = db.UserProfiles.Where(x => x.UserEmail == email).FirstOrDefault().UserFirstName;
                    lastName = db.UserProfiles.Where(x => x.UserEmail == email).FirstOrDefault().UserLastName;
                    Session["name"] = firstName + " " + lastName;
                }
            }          
            return Json(value);
        }
        public ActionResult Location()
        {
            if (Session["id"].ToString() != "admin")
            {
                return RedirectToAction("Details","UserProfile");
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
          
        }
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
           
            Session.Abandon();
            Response.Cookies.Clear();          
            Session["id"] = null;
            return RedirectToAction("Login", "Login");
        }
    }
}