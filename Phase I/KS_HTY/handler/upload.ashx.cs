using CommonLib.Log;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace KS_HTY.handler
{
    /// <summary>
    /// Summary description for upload
    /// </summary>
    public class upload : IHttpHandler
    {
        LogHelper _ErrLog = new LogHelper("ErrorLog");
        LogHelper _UpLog = new LogHelper("UpLog");

        private static string connectionString = System.Configuration.ConfigurationSettings.AppSettings["MySqlConnectionString"];

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            string filename = "error";

            ExcelBiz excelBiz = new ExcelBiz();

            HttpPostedFile file = context.Request.Files["Filedata"];
            try
            {
                string userName = "";
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    userName = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    throw new Exception("未能识别用户");
                }

                string uploadPath = context.Server.MapPath("\\files\\shipment\\");
                filename = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "_" + file.FileName;
                if (file != null)
                {
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    file.SaveAs(uploadPath + filename);
                    _UpLog.WriteLog(file.FileName + " | 另存为：| " + filename);

                    excelBiz.Excel2MySql(uploadPath, filename, userName, 0);
                    //异步执行excel 存mysql
                    new Thread(o =>
                    {
                        //excelBiz.Excel2MySql(uploadPath, filename);
                    });
                }
            }
            catch (Exception ex)
            {
                _ErrLog.WriteLog(file.FileName + " 上传异常: " + ex.Message + ex.StackTrace);
                context.Response.Clear();
                context.Response.Write("error");
                context.Response.End();
            }
            context.Response.Clear();
            context.Response.Write(filename);
            context.Response.End();

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