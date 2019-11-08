using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientSystem.Models;

namespace ClientSystem.Controllers
{
    public class UserProfileController : Controller
    {
        private ClientSystemEntities db = new ClientSystemEntities();
      
        // GET: UserProfile
        public ActionResult Index()
        {
            var value = Session["name"];
            if (value!=null && value.ToString() == "admin")
            {
                return View(db.UserProfiles.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserFirstName,UserLastName,UaserAddress,UserPhone,UserEmail,UserDOB,UserPassword")] UserProfile userProfile)
        {
            if(ModelState.IsValid)
            {
                userProfile.UserPassword = PasswordEncryptDecrypt.Encrypt(userProfile.UserPassword, "sblw-3hn8-sqoy19");
                db.UserProfiles.Add(userProfile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public JsonResult CheckEmail(string email)
        {
           
            bool isValid = db.UserProfiles.ToList().Exists(p => p.UserEmail.Equals(email, StringComparison.CurrentCultureIgnoreCase));
            return Json(isValid);
        }

        public ActionResult ChangePassword(int? id)
        {
            if (Session["id"] != null && Session["id"].ToString() != "admin")
            {
                id = Convert.ToInt32(Session["id"]);
                UserProfile userProfile = db.UserProfiles.Find(id);
                return View(userProfile);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword([Bind(Include = "UserId,UserFirstName,UserLastName,UaserAddress,UserPhone,UserEmail,UserDOB,UserPassword")] UserProfile userProfile,string PreviousPassword,string NewPassword,string ConfirmPassword)
        {
            var password = PasswordEncryptDecrypt.Decrypt(userProfile.UserPassword, "sblw-3hn8-sqoy19");
            if (PreviousPassword == password)
            {
                if (NewPassword == ConfirmPassword)
                {
                    userProfile.UserPassword =PasswordEncryptDecrypt.Encrypt(NewPassword, "sblw-3hn8-sqoy19");
                    db.Entry(userProfile).State = EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.Message = "Your Password Successfully changed";
                    return RedirectToAction("Details");
                }
                else
                {
                    ViewBag.Message = "Your New Password and Confirm Password is not matched";
                    return View(userProfile);
                }
            }
            else
            {
                ViewBag.Message = "Your Previous Password is not matched";
                return View(userProfile);
            }
            
        }

        public ActionResult Details(int? id)
        {
            if (Session["id"] != null && Session["id"].ToString()!= "admin")
            {
                id = Convert.ToInt32(Session["id"]);
                UserProfile userProfile = db.UserProfiles.Find(id);
                return View(userProfile);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
    }
}