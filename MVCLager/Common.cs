using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLager
{
    public class Common
    {
        public static bool IsPresent(string s)
        {
            return (!String.IsNullOrEmpty(s));
        }
    }
}