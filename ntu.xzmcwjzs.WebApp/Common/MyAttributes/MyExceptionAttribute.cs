using ntu.xzmcwjzs.Core.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ntu.xzmcwjzs.WebApp.Common.MyAttributes
{
    public class MyExceptionAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            LogHelper.WriteLog(filterContext.Exception.ToString());

            //filterContext.HttpContext.Response.Redirect("/Common/Error.html"); 
        }
    }
}