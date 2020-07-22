﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Common;
using System.Web.Routing;


namespace WebShop.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
       
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (String)Session[CommonConstants.USER_SESSION];
            if(session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", Action ="Index" ,Area ="Admin"}));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}