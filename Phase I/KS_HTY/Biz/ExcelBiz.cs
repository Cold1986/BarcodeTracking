using CommonLib.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace KS_HTY
{
    public class ExcelBiz
    {
        LogHelper _ErrLog = new LogHelper("ErrorLog");
        LogHelper _UpLog = new LogHelper("UpLog");

        private static string connectionString = System.Configuration.ConfigurationSettings.AppSettings["MySqlConnectionString"];
        public static DataTable GetExcelToDataTableBySheet(string FileFullPath, string SheetName)
        {
            //string strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + FileFullPath + ";Extended Properties='Excel 8.0; HDR=NO; IMEX=1'"; //此连接只能操作Excel2007之前(.xls)文件
            string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + FileFullPath + ";Extended Properties='Excel 12.0; HDR=NO; IMEX=1'"; //此连接可以操作.xls与.xlsx文件
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter odda = new OleDbDataAdapter(string.Format("SELECT * FROM [{0}]", SheetName), conn);                     //("select * from [Sheet1$]", conn);
            odda.Fill(ds, SheetName);
            conn.Close();
            return ds.Tables[0];

        }

        //根据Excel物理路径获取Excel文件中所有表名
        public static String[] GetExcelSheetNames(string excelFile)
        {
            OleDbConnection objConn = null;
            System.Data.DataTable dt = null;

            try
            {
                //string strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + excelFile + ";Extended Properties='Excel 8.0; HDR=NO; IMEX=1'"; //此连接只能操作Excel2007之前(.xls)文件

                string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + excelFile + ";Extended Properties='Excel 12.0; HDR=NO; IMEX=1'"; //此连接可以操作.xls与.xlsx文件
                objConn = new OleDbConnection(strConn);
                objConn.Open();
                dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null)
                {
                    return null;
                }
                String[] excelSheets = new String[dt.Rows.Count];
                int i = 0;
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[i] = row["TABLE_NAME"].ToString();
                    i++;
                }

                return excelSheets;
            }
            catch (Exception ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                if (objConn != null)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }

        /// <summary>
        /// 把excel 数据存入Mysql 中
        /// </summary>
        /// <param name="uploadPath"></param>
        /// <param name="filename"></param>
        /// <param name="type">上传类型 0销售出库  1 生产入库</param>
        public void Excel2MySql(string uploadPath, string filename, string userName, int type = 0)
        {
            string[] sheetNames = ExcelBiz.GetExcelSheetNames(uploadPath + filename);
            for (int i = 0; i < sheetNames.Count(); i++)
            {
                if (sheetNames[i].ToLower() != "pgi$" && sheetNames[i].ToLower() != "wgr$") continue;//新需求只需要查看sheet1 数据入库 即PGI

                DataTable dtExcel = ExcelBiz.GetExcelToDataTableBySheet(uploadPath + filename, sheetNames[i]);
                DataTable dt = dtExcel.DefaultView.ToTable(false, new string[] { dtExcel.Columns[0].ColumnName, dtExcel.Columns[1].ColumnName });//不能去重，否则break会被去掉

                dt.TableName = type == 0 ? "outstock_info" : "instock_info";
                string Column0Name = type == 0 ? "SONo" : "JobNo";
                string Column0Value = "";
                string palletNo = Guid.NewGuid().ToString();

                dt.Columns[0].ColumnName = Column0Name;
                if (dt.Columns.Count > 1)
                {
                    dt.Columns[1].ColumnName = "CartonNo";
                }
                if (dt.Rows.Count > 1)
                {
                    Column0Value = dt.Rows[1][Column0Name].ToString();
                }

                dt.Columns.Add("file_name");
                dt.Columns.Add("JDENo");
                dt.Columns.Add("ProductionNo");
                dt.Columns.Add("Num");
                dt.Columns.Add("upload_user");
                dt.Columns.Add("PalletNo");

                //第一行为表头所以跳过
                for (int j = dt.Rows.Count - 1; j >= 1; j--)
                {
                    if (dt.Rows[j][1].ToString().ToLower() == "break" || String.IsNullOrEmpty(dt.Rows[j][1].ToString()))
                    {
                        palletNo = Guid.NewGuid().ToString();
                        dt.Rows.RemoveAt(j);
                        continue;
                    }
                    dt.Rows[j]["file_name"] = filename;
                    string[] shippings = dt.Rows[j]["CartonNo"].ToString().Split('/');
                    if (shippings.Count() >= 3)
                    {
                        dt.Rows[j]["JDENo"] = shippings[0];
                        dt.Rows[j]["ProductionNo"] = shippings[1];
                        dt.Rows[j]["Num"] = shippings[2];
                    }
                    dt.Rows[j]["upload_user"] = userName;
                    dt.Rows[j]["PalletNo"] = palletNo;
                    Column0Value = string.IsNullOrEmpty(dt.Rows[j][Column0Name].ToString()) ? Column0Value : dt.Rows[j][Column0Name].ToString();
                    dt.Rows[j][Column0Name] = Column0Value;
                }

                MySqlHelper.BulkInsert(connectionString, dt);
            }
        }
    }
}