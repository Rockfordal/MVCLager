using MVCLager.Controllers.Data;
using MVCLager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLager.Controllers
{
    public class ShoppingController : ApplicationController
    {
        private CustomerService _customer    = new CustomerService();
        private CartItemPleaser CartItemEdit = new CartItemPleaser();

        // GET: Shopping
        public ActionResult Index()
        {
            var cartItems = _customer.GetMyItems();

            ViewData["CartLabel"] = _customer.CartLabel;
            return View(cartItems);
        }

        // GET: Increase/<itemId>
        //public ActionResult Increase(int ItemID, int CartId)
        public ActionResult Increase(int id)
        {
            //_customer.BuyMoreOf(ItemID, CartId);
            _customer.BuyMoreOf(id);
            return RedirectToAction("Index");
        }

        // GET: Decrease
        public ActionResult Decrease(int id)
        {
            _customer.BuyLessOf(id);
            return RedirectToAction("Index");
        }
        
        //public ActionResult Detail
    }
}