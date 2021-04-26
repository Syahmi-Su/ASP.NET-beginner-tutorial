using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebECartDemo.Models;
using WebECartDemo.ViewModel;

namespace WebECartDemo.Controllers
{
    public class ItemController : Controller
    {
        private ECartDBEntities objeCartDBEntities;
        public ItemController()
        {
            objeCartDBEntities = new ECartDBEntities();
        }
        // GET: Item
        public ActionResult Index()
        {
            ItemViewModel objItemViewModel = new ItemViewModel();
            objItemViewModel.CategorySelectListItem = (from objCat in objeCartDBEntities.Categories
                                                       select new SelectListItem()
                                                       {
                                                           Text = objCat.CategoryName,
                                                           Value = objCat.CategoryId.ToString(),
                                                           Selected = true

                                                       });
            return View(objItemViewModel);
        }
    }
}