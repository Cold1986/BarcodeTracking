using CommonLib.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace KS_HTY.handler
{
    /// <summary>
    /// Summary description for UploadInfo
    /// </summary>
    public class UploadInfo : IHttpHandler
    {
        private static string connectionString = System.Configuration.ConfigurationSettings.AppSettings["MySqlConnectionString"];
        LogHelper _ErrLog = new LogHelper("ErrorLog");
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";


            string files = context.Request["files"];
            string type = context.Request["type"];
            if (!string.IsNullOrEmpty(files) && !string.IsNullOrEmpty(type))
            {
                try
                {
                    string[] allFiles = files.Split(';');
                    string strWhere = "";
                    for (int i = 0; i < allFiles.Count(); i++)
                    {
                        strWhere += "'" + allFiles[i] + "'";
                        if (i != allFiles.Count() - 1)
                        {
                            strWhere += ",";
                        }
                    }

                    string strSql = "select * from ";
                    string tableName = type == "0" ? "outstock_info" : "instock_info";

                    strSql += tableName + " where 1=1";
                    strSql += " and file_name in(" + strWhere + ") order by upload_date desc, id asc ";

                    DataTable dt = MySqlHelper.ExecuteDataTable(connectionString, strSql, null);
                    if (type == "0")
                    {
                        Result<outstock> result = new Result<outstock>();
                        result.res = "success";
                        result.mes = new List<outstock>();
                        result.mes = ConvertHelper.DataTableToList<outstock>(dt);
                        context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(result));
                    }
                    else
                    {
                        Result<instock> result = new Result<instock>();
                        result.res = "success";
                        result.mes = new List<instock>();
                        result.mes = ConvertHelper.DataTableToList<instock>(dt);
                        context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(result));
                    }

                }
                catch (Exception ex)
                {
                    Result<stock> result = new Result<stock>();
                    result.res = "failed";
                    context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(result));
                    _ErrLog.WriteLog("获取信息异常: " + ex.Message + ex.StackTrace);
                }
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