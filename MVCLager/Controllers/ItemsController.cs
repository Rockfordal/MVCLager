using MVCLager.Data;
using MVCLager.DataAccessLayer;
using MVCLager.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLager.Controllers
{
    public class ItemsController : Controller
    {
        private ItemRepository Item = new ItemRepository();
        private ItemPleaser ItemEdit = new ItemPleaser();

        // GET: Items
        //public ActionResult Index()
        public ActionResult Index(string sortOrder, string searchText)
        {
            ViewBag.NameSortParm  = String.IsNullOrEmpty(sortOrder) ? "NameD" : "";
            ViewBag.DescSortParm  = sortOrder == "Description" ? "DescD" : "Desc";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "PriceD" : "Price";
            var items = Item.Search(searchText, sortOrder);
            ModelState.Clear();
            return View("Index", items);
        }

        // POST: Search, Sort
        //[HttpPost]
        //public ActionResult Index(string sortOrder, string searchText)
        //{
        //    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    ViewBag.DescriptionSortParm = sortOrder == "Description" ? "desc_desc" : "Description";

        //    var keys = Request.QueryString.Keys;
        //    string sok = Request.QueryString["searchText"];
        //    var items = Item.Search(searchText, sortOrder);
        //    ModelState.Clear();
        //    return View("Index", items);
        //}

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Edit
        public ActionResult Edit(int? id)
        {
            //var item = Item.FindById(id);
            var item = ItemEdit.GetItemForEdit(id);
            return View(item);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "ItemID,Name,Description,Price")] StockItem item)
        {
            var m = EntityState.Modified;
            Item.UpdateItem(item, m);
            return RedirectToAction("Index");
        }

        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return Content("Du måste ange en id");
        //    }
        //    Item.Delete(id);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            Item.DeleteById(id);
            return RedirectToAction("Index");
        }

        public ActionResult Fel()
        {
            return Content("<h1>Ett fel har inträffat</h1>");
        }
        
    }
}