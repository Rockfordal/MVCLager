using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCLager.Entities
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Kategori")]
        public string Name { get; set; }
    }
}