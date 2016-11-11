using MVCLager.Controllers.Data;
using MVCLager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLager.Controllers
{
    public abstract class ApplicationController : Controller
    {
        private CustomerService _customer = new CustomerService();

        public ApplicationController()
        {
            ViewData["cartTotal"] = _customer.NumberOfItems();
        }

    }
}