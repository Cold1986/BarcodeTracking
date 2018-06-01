using CommonLib.Log;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace KS_HTY.handler
{
    /// <summary>
    /// Summary description for getInfo
    /// </summary>
    public class getInfo : IHttpHandler
    {
        private static string connectionString = System.Configuration.ConfigurationSettings.AppSettings["MySqlConnectionString"];
        LogHelper _ErrLog = new LogHelper("ErrorLog");

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string method = context.Request["method"];
                string type = context.Request["type"];

                string strJobNo = context.Request["strJobNo"];//工单号
                string strSONo = context.Request["strSONO"];//销售订单号
                string strCartonNo = context.Request["strCartonNo"];//箱唛编号
                string strJDE = context.Request["strJDE"];//JDE编号
                string strProNo = context.Request["strProNo"];//生产序列号
                string strUser = context.Request["strUser"];//操作人员
                string strUploadDate = context.Request["strUploadDate"];

                string tableName = type == "0" ? "outstock_info" : "instock_info";

                string sql = "select * from " + tableName + " where 1=1";
                string strWhere = string.Empty;
                string strOrder = string.Empty;
                MySqlParameter[] parameters =
                {
                     new MySqlParameter("?strJobNo", MySqlDbType.VarChar, 60) {Value = "" },
                     new MySqlParameter("?strSONo", MySqlDbType.VarChar, 60) {Value = "" },
                     new MySqlParameter("?strCartonNo", MySqlDbType.VarChar, 60) {Value = "" },
                     new MySqlParameter("?strJDE", MySqlDbType.VarChar, 60) {Value = "" },
                     new MySqlParameter("?strProNo", MySqlDbType.VarChar, 60) {Value = "" },
                     new MySqlParameter("?strUser", MySqlDbType.VarChar, 60) {Value = "" },
                     new MySqlParameter("?strUploadDate", MySqlDbType.VarChar, 60) {Value = "" },
                };

                if (!string.IsNullOrEmpty(strJobNo))
                {
                    strWhere += " and JobNo like ?strJobNo";
                    parameters[0].Value = "%" + strJobNo + "%";
                }
                if (!string.IsNullOrEmpty(strSONo))
                {
                    strWhere += " and SONo like ?strSONo";
                    parameters[1].Value = "%" + strSONo + "%";
                }
                if (!string.IsNullOrEmpty(strCartonNo))
                {
                    strWhere += " and CartonNo like ?strCartonNo";
                    parameters[2].Value = "%" + strCartonNo + "%";
                }
                if (!string.IsNullOrEmpty(strJDE))
                {
                    strWhere += " and JDENo like ?strJDE";
                    parameters[3].Value = "%" + strJDE + "%";
                }
                if (!string.IsNullOrEmpty(strProNo))
                {
                    strWhere += " and ProductionNo like ?strProNo ";
                    parameters[4].Value = "%" + strProNo + "%";
                }
                if (!string.IsNullOrEmpty(strUser))
                {
                    strWhere += " and upload_user like ?strUser";
                    string[] strUsers = strUser.Split('\\');

                    if (strUsers.Length > 1)
                    {
                        parameters[5].Value = "%" + strUsers[1] + "%";
                    }
                    else
                    {
                        parameters[5].Value = "%" + strUser + "%";
                    }

                }
                if (!string.IsNullOrEmpty(strUploadDate))
                {
                    strWhere += " and datediff(upload_date,?strUploadDate)=0";
                    parameters[6].Value = strUploadDate;
                }

                strOrder = " order by upload_date desc, id asc";
                DataTable dt = MySqlHelper.ExecuteDataTable(connectionString, sql + strWhere.ToString(), parameters);

                if (dt.Rows.Count > 0)
                {
                    if (method.ToLower() == "search")
                    {
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
                    else if (method.ToLower() == "download")
                    {
                        string userName = "";
                        if (HttpContext.Current.User.Identity.IsAuthenticated)
                        {
                            userName = HttpContext.Current.User.Identity.Name;
                        }

                        string path;
                        if (type == "0")
                        {
                            path = context.Server.MapPath("\\downloads\\outstock\\");
                        }
                        else
                        {
                            path = context.Server.MapPath("\\downloads\\instock\\");
                        }
                        string filename = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "_" + type;
                        string[] strUsers = userName.Split('\\');

                        if (strUsers.Length > 1)
                        {
                            filename += "_" + strUsers[1];
                        }
                        ConvertHelper.dataTableToCsv(dt, path + "\\" + filename + ".xls");
                        if (type == "0")
                        {
                            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject("downloads\\outstock\\" + filename + ".xls"));
                        }
                        else
                        {
                            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject("downloads\\instock\\" + filename + ".xls"));
                        }
                    }
                }
                context.Response.ContentType = "text/plain";
            }
            catch (Exception ex)
            {
                _ErrLog.WriteLog("查询异常: " + ex.Message + ex.StackTrace);
                context.Response.Clear();
                context.Response.Write("error");
                context.Response.End();
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