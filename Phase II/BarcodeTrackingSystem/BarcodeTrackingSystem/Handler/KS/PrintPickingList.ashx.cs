using BarcodeTracking.Biz;
using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarcodeTracking.Handler.KS
{
    /// <summary>
    /// Summary description for PrintPickingList
    /// </summary>
    public class PrintPickingList : IHttpHandler
    {
        LogHelper _ErrLog = new LogHelper("ErrorLog");
        public void ProcessRequest(HttpContext context)
        {
            PickingListBiz pickBiz = new PickingListBiz();
            context.Response.ContentType = "text/plain";
            string result = string.Empty;
            try
            {
                string method = context.Request["method"];
                string SONo = context.Request["SONo"];

                switch (method)
                {
                    case "getPickingList":
                        result = pickBiz.GetPickingList(SONo);
                        break;
                }
            }
            catch (Exception ex)
            {
                result = "error";
                _ErrLog.WriteLog("PrintPickingList 异常" + ex.Message);
            }
            finally
            {
                context.Response.Write(result);
            }
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