using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Maticsoft.Common;


namespace BarcodeTracking.Handler
{
    /// <summary>
    /// account 的摘要说明
    /// </summary>
    public class account : IHttpHandler
    {
        private static string connectionString = System.Configuration.ConfigurationManager.AppSettings["SqlServerConnectionString"];
        LogHelper _ErrLog = new LogHelper("ErrorLog");
        HttpContext _context;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            _context = context;
            string method = context.Request["method"];
            switch (method)
            {
                case "login":
                    
                    break;
            }

            //Project p1 = new Project() { Input = "stone", Output = "gold" };
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            //string jsonStr = serializer.Serialize(p1);  //序列化：对象=>JSON字符串
            //Response.Write(jsonStr);

            //Project p2 = serializer.Deserialize<Project>(jsonStr); //反序列化：JSON字符串=>对象
            //Response.Write(p1.Input + "=>" + p2.Output);

            //context.Response.Write("Hello World");
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