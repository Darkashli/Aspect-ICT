﻿using System.Web;
using System.Web.Mvc;

namespace AspectIct.KnowledgeBase
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
