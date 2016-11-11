using MVCLager.Data;
using MVCLager.DataAccessLayer;
using MVCLager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLager.Controllers.Data
{
    public class CustomerService
    {
        private StoreContext db = new StoreContext();
        private CartItemPleaser CartItemEdit = new CartItemPleaser();

        public static int currentCartID = -1;

        public CustomerService()
        {
            if (currentCartID == -1)
                currentCartID = db.Carts.First().ID;
        }

        internal void BuyMoreOf(int itemId)
        {
            var query = db.CartItems.Where(i => i.ItemId == itemId && i.CartId == currentCartID);
            var item = query.First();
            item.Count++;
            db.SaveChanges();
        }

        internal void BuyLessOf(int itemId)
        {
            var query = db.CartItems.Where(i => i.ItemId == itemId && i.CartId == currentCartID);
            var item = query.First();
            if (item.Count > 1)
                item.Count--;
            db.SaveChanges();
        }

        internal IEnumerable<Models.EditCartItemViewModel> GetMyItems()
        {
            var cartItems = CartItemEdit.GetCartItemsForEdit(currentCartID);
            return cartItems;
        }

        internal int NumberOfItems()
        {
            return GetMyItems().Count();
        }

        public object CartLabel
        {
            get {
                return db.Carts.Single(c => c.ID == currentCartID).Label;
            }
        }

    }
}