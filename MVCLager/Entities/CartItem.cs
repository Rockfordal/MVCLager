using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MVCLager.Entities;

namespace MVCLager.Entities
{
    public class CartItem : EntityBase
    {
        [Key]
        public int ID { get; set; }
        public int CartId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }

        public virtual StockItem Item { get; set; }
        public virtual Cart Cart { get; set; }
    }
}