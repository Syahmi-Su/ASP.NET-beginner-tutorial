using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppsBeginner2.Data;
using WebAppsBeginner2.Models;

namespace WebAppsBeginner2.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDBContext _db; 

        public ItemController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items;
            return View(objList);
        }
    }
}
