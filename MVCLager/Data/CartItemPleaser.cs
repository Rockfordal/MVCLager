using MVCLager.DataAccessLayer;
using MVCLager.Entities;
using MVCLager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLager.Data
{
    public class CartItemPleaser
    {
        private StoreContext _context = new StoreContext();

        public EditCartItemViewModel GetCartItemForEdit(int? cartItemId)
        {
            var query = _context.CartItems
                .Where(i => i.ID == cartItemId)
                .Select(i => new EditCartItemViewModel()
                {
                    ID          = i.ID,
                    CartId      = i.CartId,
                    ItemId      = i.ItemId,
                    Count       = i.Count,
                    //Item        = i.Item
                    //DateCreated = i.DateCreated
                });
            return query.FirstOrDefault();
        }

        public IEnumerable<EditCartItemViewModel> GetCartItemsForEdit(int cartId)
        {
            var query = _context.CartItems
                .Where(i => i.CartId == cartId)
                .Select(i => new EditCartItemViewModel()
                {
                    ID          = i.ID,
                    CartId      = i.CartId,
                    ItemId      = i.ItemId,
                    Count       = i.Count,
                    ItemName    = i.Item.Name
                    //DateCreated = i.DateCreated
                });
            return query;
        }
    }
}