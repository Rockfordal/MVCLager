using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCLager.Entities
{
    public class Cart
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Etikett")]
        public string Label { get; set; }
    }
}