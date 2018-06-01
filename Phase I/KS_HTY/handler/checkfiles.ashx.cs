using CommonLib.Log;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace KS_HTY.handler
{
    /// <summary>
    /// Summary description for checkfiles
    /// </summary>
    public class checkfiles : IHttpHandler
    {
        private static string connectionString = System.Configuration.ConfigurationSettings.AppSettings["MySqlConnectionString"];
        LogHelper _ErrLog = new LogHelper("ErrorLog");
        public void ProcessRequest(HttpContext context)
        {
            int i = 0;
            context.Response.ContentType = "text/plain";
            string files = context.Request["files"];
            string type = context.Request["type"];
            if (!string.IsNullOrEmpty(files) && !string.IsNullOrEmpty(type))
            {
                string tableName = type == "0" ? "outstock_info" : "instock_info";
                MySqlParameter parameter = new MySqlParameter("?file_name", MySqlDbType.VarChar, 60) { Value = "%" + files };

                string strSql = "select distinct(file_name) from " + tableName + " where file_name like ?file_name limit 1";

                DataTable dt = MySqlHelper.ExecuteDataTable(connectionString, strSql, parameter);
                i = dt.Rows.Count > 0 ? 1 : 0;
            }

            context.Response.Write(i);
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