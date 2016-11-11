using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCLager.Entities;

namespace MVCLager.DataAccessLayer
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("DefaultConnection")
        { }

        public DbSet<StockItem> Items { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Category { get; set; }

        //public DbSet<Catagory> Catagories { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}