using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsumeApi.Models;

namespace ConsumeApi.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }
            ErrorLog errorLog = new ErrorLog();
            // handle / log errors        
        
        }

            
    }
}