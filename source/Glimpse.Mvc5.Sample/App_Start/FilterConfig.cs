﻿using System.Web;
using System.Web.Mvc;

namespace Glimpse.Mvc5.Sample
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
