using MVCLager.DataAccessLayer;
using MVCLager.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCLager.Data
{
    public class ItemRepository
    {
        private StoreContext db = new StoreContext();

        internal IEnumerable<StockItem> GetAll()
        {
            return db.Items;
        }

        internal object FindById(int? id)
        {
            var item = db.Items.FirstOrDefault(i => i.ItemID == id);
            return item;
        }

        internal object Search(string searchString)
        {
             if (MVCLager.Common.IsPresent(searchString))
                return db.Items;
            else
                return db.Items.Where(i => i.Name.ToLower().Contains(searchString.ToLower()));
        }

        internal object Search(string searchString, string sortOrder)
        {
            var items = db.Items.Select(i => i);

            if (MVCLager.Common.IsPresent(searchString))
                items = db.Items.Where(i => i.Name.ToLower().Contains(searchString.ToLower()));

            switch (sortOrder)
            {
                case "Desc":
                    items = items.OrderBy(i => i.Description);
                    break;
                case "DescD":
                    items = items.OrderByDescending(i => i.Description);
                    break;
                case "Price":
                    items = items.OrderBy(i => i.Price);
                    break;
                case "PriceD":
                    items = items.OrderByDescending(i => i.Price);
                    break;
                case "NameD":
                    items = items.OrderByDescending(i => i.Name);
                    break;
                default:
                    items = items.OrderBy(i => i.Name);
                    break;
            }
            return items;
        }

        internal void Add(StockItem item)
        {
            db.Items.Add(item);
            db.SaveChanges();
        }

        internal void UpdateItem(StockItem item, EntityState m)
        {
            db.Entry(item).State = m;
            db.SaveChanges();
        }

        internal void DeleteById(int? id)
        {
            StockItem item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
        }

    }
}