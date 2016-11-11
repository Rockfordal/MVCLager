using MVCLager.Data;
using MVCLager.DataAccessLayer;
using MVCLager.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MVCLager.Controllers
{
    public class ItemsController : ApplicationController
    {
        private ItemRepository Item  = new ItemRepository();
        private ItemPleaser ItemEdit = new ItemPleaser();

        // GET: Items
        public ViewResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
           if (searchString != null)
              page = 1;
           else
              searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentSort   = sortOrder;
            ViewBag.NameSortParm  = String.IsNullOrEmpty(sortOrder) ? "NameD"  : "";
            ViewBag.DescSortParm  = sortOrder == "Description"      ? "DescD"  : "Desc";
            ViewBag.PriceSortParm = sortOrder == "Price"            ? "PriceD" : "Price";

            var items = Item.Search(searchString, sortOrder);
            const int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(items.ToPagedList(pageNumber, pageSize));
        }

        // POST: Search, Sort
        //[HttpPost]
        //public ActionResult Index(string sortOrder, string searchString)
        //{
        //    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    ViewBag.DescriptionSortParm = sortOrder == "Description" ? "desc_desc" : "Description";
        //    var keys = Request.QueryString.Keys;
        //    string sok = Request.QueryString["searchString"];
        //    var items = Item.Search(searchString, sortOrder);
        //    ModelState.Clear();
        //    return View("Index", items);
        //}

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Name,Description,Price")] StockItem item)
        {
            if (ModelState.IsValid)
            {
                Item.Add(item);
                return RedirectToAction("Index");
                //return Content("<h1>Valid</h1>");
            }
            else
            {
                //var errors = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList();
                var errors = ModelState
                    .SelectMany(ms => ms.Value.Errors)
                    .Select(ms => ms.ErrorMessage);
                var response = new
                {
                    isValid = ModelState.IsValid,
                    errors = errors
                };
                return Json(response);
                //return Content("<h1>Invalid " + errors.Count + "</h1>");
            }
        }

        // GET: Edit
        public ActionResult Edit(int? id)
        {
            //var item = Item.FindById(id);
            var item = ItemEdit.GetItemForEdit(id);
            return View(item);
        }

        // POST: Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "ItemID,Name,Description,Price")] StockItem item)
        {
            var p = Request;
            var m = EntityState.Modified;
            Item.UpdateItem(item, m);
            return RedirectToAction("Index");
        }

        // GET: Edit
        public ActionResult Buy(int? id)
        {
            //Item.AddToCart(id);
            //return View(item);
            //return RedirectToAction("Index");
            return Content("Sorry, you cannot buy stuff yet");
        }

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            Item.DeleteById(id);
            return RedirectToAction("Index");
        }
        //    if (id == null)
        //        return Content("Du måste ange en id");
        //    Item.Delete(id);

        public ActionResult Fel()
        {
            return Content("<h1>Ett fel har inträffat</h1>");
        }
        
    }
}