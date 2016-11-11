using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLager.Models
{
    public class EditItemViewModel
    {
        public int ItemID { get; set; }

        [DisplayName("Namn")]
        public string Name { get; set; }

        [DisplayName("Beskrivning")]
        public string Description { get; set; }

        [DisplayName("Pris")]
        public decimal Price { get; set; }

        [DisplayName("Hylla")]
        public string Shelf { get; set; }

        [DisplayName("Kategori")]
        public string CategoryName { get; set; }
    }
}