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
        // GET: User
        public ActionResult AddOrEdit(int id=0)
        {
            dbo_User userModel = new dbo_User();
            return View(userModel);
        }
    }
}