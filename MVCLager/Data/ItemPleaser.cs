using MVCLager.DataAccessLayer;
using MVCLager.Entities;
using MVCLager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLager.Data
{
    public class ItemPleaser
    {
        private StoreContext _context = new StoreContext();

        public EditItemViewModel GetItemForEdit(int? ItemId)
        {
            var query = _context.Items
                .Where(i => i.ItemID == ItemId)
                .Select(i => new EditItemViewModel()
                {
                    ItemID      = i.ItemID,
                    Name        = i.Name,
                    Description = i.Description,
                    Price       = i.Price
                });
            return query.FirstOrDefault();
        }

        public IEnumerable<EditItemViewModel> GetCartItemsForEdit(IEnumerable<StockItem> stockItems)
        {
            List<EditItemViewModel> items = new List<EditItemViewModel>();

            foreach (var item in stockItems)
            {
                var newItem = new EditItemViewModel
                {
                    ItemID = item.ItemID,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    CategoryName = item.Category.Name
                    //Shelf = item.Shelf
                };
                items.Add(newItem);
            }

            return (IEnumerable<EditItemViewModel>) items;
        }

    }
}