using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLager.Models
{
    public class EditCartItemViewModel
    {
        public int ID { get; set; }

        [DisplayName("Kundvagn")]
        public int CartId { get; set; }

        [DisplayName("Produkt")]
        public int ItemId { get; set; }

        [DisplayName("Antal")]
        public int Count { get; set; }

        [DisplayName("Datum skapad")]
        public DateTime DateCreated { get; set; }

        // Virtuella
        [DisplayName("Namn")]
        public string ItemName { get; set; }

        [DisplayName("Produkt")]
        public virtual MVCLager.Entities.StockItem Item { get; set; }

        [DisplayName("Kundvagn")]
        public virtual MVCLager.Entities.Cart Cart { get; set; }

        [DisplayName("Kategori")]
        public virtual MVCLager.Entities.Category Category { get; set; }
    }
}