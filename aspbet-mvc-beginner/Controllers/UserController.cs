using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aspbet_mvc_beginner.Models;


namespace aspbet_mvc_beginner.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            dbo_User userModel = new dbo_User();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult AddOrEdit(dbo_User userModel)
        {
            using (DbModels dbModel = new DbModels())
            {
                dbModel.dbo_User.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful. ";
            return View("AddOrEdit", new dbo_User());
        }
    }
}