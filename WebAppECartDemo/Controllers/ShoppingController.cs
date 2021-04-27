using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppECartDemo.Models;
using WebAppECartDemo.ViewModel;

namespace WebAppECartDemo.Controllers
{
    public class ShoppingController : Controller
    {
        private ECartDBEntities objCartDbEntities;
        private List<ShoppingCartModel> listOfShoppingCartModels;
        public ShoppingController()
        {
            objCartDbEntities = new ECartDBEntities();
            listOfShoppingCartModels = new List<ShoppingCartModel>();
        }
        // GET: Shopping
        public ActionResult Index()
        {
            IEnumerable<ShoppingViewModel> listofShoppingViewModels = (from objItem in objCartDbEntities.Items
                                                                       join
                                                                       objCate in objCartDbEntities.Categories
                                                                       on objItem.CategoryId equals objCate.CategoryId
                                                                       select new ShoppingViewModel()
                                                                       {
                                                                           ImagePath = objItem.ImagePath,
                                                                           ItemName = objItem.ItemName,
                                                                           Description = objItem.Description,
                                                                           ItemPrice = objItem.ItemPrice,
                                                                           ItemId = objItem.ItemId,
                                                                           Category = objCate.CategoryName,
                                                                           ItemCode = objItem.ItemCode,
                                                                       }

                                                                       ).ToList();
            return View(listofShoppingViewModels);
        }
    
        
        [HttpPost]
        public JsonResult Index(string ItemId)
        {
            ShoppingCartModel objShoppingCartModel = new ShoppingCartModel();
            Item objItem = objCartDbEntities.Items.Single(model => model.ItemId.ToString() == ItemId);
            if(Session["CartCounter"] != null)
            {
                listOfShoppingCartModels = Session["CartItem"] as List<ShoppingCartModel>;
            }
            
            if(listOfShoppingCartModels.Any(model => model.ItemId == ItemId))
            {
                objShoppingCartModel = listOfShoppingCartModels.Single(model => model.ItemId == ItemId);
                objShoppingCartModel.Quantity = objShoppingCartModel.Quantity + 1;
                objShoppingCartModel.Total = objShoppingCartModel.Quantity * objShoppingCartModel.UnitPrice;
            }
            else
            {
                objShoppingCartModel.ItemId = ItemId;
                objShoppingCartModel.ImagePath = objItem.ImagePath;
                objShoppingCartModel.ItemName = objItem.ItemName;
                objShoppingCartModel.Quantity = 1;
                objShoppingCartModel.Total = objItem.ItemPrice;
                objShoppingCartModel.UnitPrice = objItem.ItemPrice;
                listOfShoppingCartModels.Add(objShoppingCartModel);
            }

            Session["CartCounter"] = listOfShoppingCartModels.Count;
            Session["CartItem"] = listOfShoppingCartModels;
            return Json(new { Success = true, Counter = listOfShoppingCartModels.Count }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ShoppingCart()
        {
            return View();
        }
    }

}