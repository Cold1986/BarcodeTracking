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
    /// Summary description for getReport
    /// </summary>
    public class getReport : IHttpHandler
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
                string chkJobNo = context.Request["chkJobNo"];
                string chkSONo = context.Request["chkSONo"];
                string chkJDE = context.Request["chkJDE"];
                string chkProNo = context.Request["chkProNo"];
                string chkDate = context.Request["chkDate"];

                string tableName = "";
                if (type == "0")
                {
                    tableName = " from (select SONo,JDENo,ProductionNo,Num,DATE_FORMAT(upload_date,'%Y-%m-%d') as upload_date from ks_hty.outstock_info) as tb";
                }
                else
                {
                    tableName = " from (select JobNo,JDENo,ProductionNo,Num,DATE_FORMAT(upload_date,'%Y-%m-%d') as upload_date from ks_hty.instock_info) as tb";
                }


                string strSel = "select sum(num) as SumNum ";
                string strGroup = " group by";

                string strOrder = " order by";
                if (!string.IsNullOrEmpty(chkJobNo) && chkJobNo.ToLower() == "true")
                {
                    strSel += ", JobNo";
                    strGroup += " JobNo,";
                    strOrder += " JobNo,";
                }
                if (!string.IsNullOrEmpty(chkSONo) && chkSONo.ToLower() == "true")
                {
                    strSel += ", SONo";
                    strGroup += " SONo,";
                    strOrder += " SONo,";
                }
                if (chkJDE.ToLower() == "true")
                {
                    strSel += ", JDENo";
                    strGroup += " JDENo,";
                    strOrder += " JDENo,";
                }
                if (chkProNo.ToLower() == "true")
                {
                    strSel += ", ProductionNo";
                    strGroup += " ProductionNo,";
                    strOrder += " ProductionNo,";
                }
                if (chkDate.ToLower() == "true")
                {
                    strSel += ", DATE_FORMAT(upload_date,'%Y-%m-%d') as uploaddate";
                    strGroup += " upload_date,";
                    strOrder += " upload_date,";
                }

                if (strGroup != " group by")
                {
                    strGroup = strGroup.Substring(0, strGroup.Length - 1);
                    strOrder = strOrder.Substring(0, strOrder.Length - 1);
                }
                string strWhere = " where 1=1";

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


                string sql = strSel + tableName + strWhere + strGroup + strOrder;
                DataTable dt = MySqlHelper.ExecuteDataTable(connectionString, sql, parameters);

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
                            filename = filename + "_" + strUsers[1];
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