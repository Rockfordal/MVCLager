using MVCLager.DataAccessLayer;
using MVCLager.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCLager.Data
{
    public class CartItemRepository
    {
        private StoreContext db = new StoreContext();

        internal int NumberOfItems()
        {
            return db.CartItems.Count();
        }

        internal IEnumerable<CartItem> GetAll()
        {
            return db.CartItems;
        }

        //internal object FindById(int? id)
        //{
        //    var CartItem = db.CartItems.FirstOrDefault(i => i.CartItemID == id);
        //    return CartItem;
        //}

        //internal void Add(StockItem item)
        //{
        //    db.CartItems.Add(item);
        //    db.SaveChanges();
        //}

        internal void UpdateCartItem(CartItem CartItem, EntityState m)
        {
            db.Entry(CartItem).State = m;
            db.SaveChanges();
        }

        internal void DeleteById(int? id)
        {
            CartItem CartItem = db.CartItems.Find(id);
            db.CartItems.Remove(CartItem);
            db.SaveChanges();
        }


        internal void AddToCart(int? id)
        {
            CartItem CartItem = db.CartItems.Find(id);
        }

    }
}