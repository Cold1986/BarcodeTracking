using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarcodeTracking.Handler.KS
{
    /// <summary>
    /// Summary description for condimentsFacade
    /// </summary>
    public class condimentsFacade : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}