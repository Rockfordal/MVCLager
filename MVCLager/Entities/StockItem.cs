using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MVCLager.Entities;

namespace MVCLager.Entities
{
    public class StockItem
    {
        [Key]
        public int ItemID { get; set; }

        //public int Category_ID { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage = "Pris måste anges")]
        public decimal Price { get; set; }
        
        public string Description { get; set; }

        public string Shelf { get; set; }

        public virtual Category Category { get; set; }
    }
}