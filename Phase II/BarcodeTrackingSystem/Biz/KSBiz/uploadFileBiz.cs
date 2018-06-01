using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace BarcodeTracking.Biz
{
    public class uploadFileBiz
    {
        //数据库连接字符串(web.config来配置)，多数据库可使用DbHelperSQLP来实现.
        public static string connectionString = PubConstant.ConnectionString;
        public static void DataTableToSQLServer(DataTable dt)
        {
            using (SqlConnection destinationConnection = new SqlConnection(connectionString))
            {
                destinationConnection.Open();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                {
                    try
                    {

                        bulkCopy.DestinationTableName = "KGM_HISTORYBODY";//要插入的表的表明  
                        bulkCopy.ColumnMappings.Add("PKID", "PKID");//映射字段名 DataTable列名 ,数据库 对应的列名  
                        bulkCopy.ColumnMappings.Add("OPERORDER", "OPERORDER");
                        bulkCopy.ColumnMappings.Add("CVOUCHID", "CVOUCHID");
                        bulkCopy.ColumnMappings.Add("BARCODE", "BARCODE");
                        bulkCopy.ColumnMappings.Add("OPERUSER", "OPERUSER");
                        bulkCopy.ColumnMappings.Add("OPERDATE", "OPERDATE");
                        bulkCopy.ColumnMappings.Add("COPOSCODE", "COPOSCODE");
                        bulkCopy.ColumnMappings.Add("QTY", "QTY");
                        bulkCopy.ColumnMappings.Add("CDEFINE23", "CDEFINE23");
                        bulkCopy.ColumnMappings.Add("CDEFINE25", "CDEFINE25");
                        bulkCopy.ColumnMappings.Add("RESERVE1", "RESERVE1");
                        bulkCopy.ColumnMappings.Add("RESERVE2", "RESERVE2");
                        bulkCopy.WriteToServer(dt);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                        //Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        // Close the SqlDataReader. The SqlBulkCopy  
                        // object is automatically closed at the end  
                        // of the using block.  

                    }
                }


            }

        }

        public static void Excel2DataTable(string uploadPath, string filename, string userName, string type)
        {
            string[] sheetNames = GetExcelSheetNames(uploadPath + filename);
            for (int i = 0; i < sheetNames.Count(); i++)
            {
                if (sheetNames[i].ToLower() != "pgi$" && sheetNames[i].ToLower() != "wgr$") continue;//新需求只需要查看sheet1 数据入库 即PGI

                DataTable dtExcel = GetExcelToDataTableBySheet(uploadPath + filename, sheetNames[i]);
                DataTable dt = dtExcel.DefaultView.ToTable(false, new string[] { dtExcel.Columns[0].ColumnName, dtExcel.Columns[1].ColumnName });//不能去重，否则break会被去掉
                dt.Columns[1].ColumnName = "BARCODE";

                dt.Columns.Add("PKID");
                dt.Columns.Add("OPERORDER");
                dt.Columns.Add("CVOUCHID");
                dt.Columns.Add("OPERUSER");
                dt.Columns.Add("OPERDATE");
                dt.Columns.Add("COPOSCODE");
                dt.Columns.Add("QTY");
                dt.Columns.Add("CDEFINE23");
                dt.Columns.Add("CDEFINE25");
                dt.Columns.Add("RESERVE1");
                dt.Columns.Add("RESERVE2");


                //第一行为表头所以跳过;因为正序删除时索引会发生变化
                for (int j = dt.Rows.Count - 1; j >= 1; j--)
                {
                    if (dt.Rows[j][1].ToString().ToLower() == "break" || String.IsNullOrEmpty(dt.Rows[j][1].ToString()))
                    {
                        dt.Rows.RemoveAt(j);
                        continue;
                    }
                    dt.Rows[j]["PKID"] = Guid.NewGuid().ToString().ToUpper();

                    string Column0Value = string.IsNullOrEmpty(dt.Rows[j][0].ToString()) ? dt.Rows[1][0].ToString() : dt.Rows[j][0].ToString();

                    dt.Rows[j]["OPERORDER"] = Column0Value;// dt.Rows[0][1].ToString();
                    dt.Rows[j]["CVOUCHID"] = type == "1" ? "03" : "06";//03：销售扫描、06：调仓校验
                    dt.Rows[j]["OPERUSER"] = userName;
                    dt.Rows[j]["OPERDATE"] = System.DateTime.Now;
                    dt.Rows[j]["COPOSCODE"] = "RRD00001";
                    dt.Rows[j]["CDEFINE23"] = Column0Value;// dt.Rows[0][1].ToString();
                    dt.Rows[j]["RESERVE1"] = "-1";
                    dt.Rows[j]["RESERVE2"] = "RRD" + System.DateTime.Now.ToString("yyyyMMddHHmmss");


                    string[] shippings = dt.Rows[j][1].ToString().Split('/');
                    if (shippings.Count() == 3)
                    {
                        dt.Rows[j]["CDEFINE25"] = shippings[0];
                        //dt.Rows[j]["ProductionNo"] = shippings[1];
                        dt.Rows[j]["QTY"] = shippings[2];
                    }
                    else if (shippings.Count() > 3)
                    {
                        dt.Rows[j]["CDEFINE25"] = shippings[0];
                        //dt.Rows[j]["ProductionNo"] = shippings[1] + shippings[2];
                        dt.Rows[j]["QTY"] = shippings[shippings.Count() - 1];
                    }
                }
                dt.Rows.RemoveAt(0);//去除首行
                DataTableToSQLServer(dt);
            }
        }


        //根据Excel物理路径获取Excel文件中所有表名
        private static String[] GetExcelSheetNames(string excelFile)
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

        private static DataTable GetExcelToDataTableBySheet(string FileFullPath, string SheetName)
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


        /// <summary>
        /// 将CSV文件的数据读取到DataTable中
        /// </summary>
        /// <param name="fileName">CSV文件路径</param>
        /// <returns>返回读取了CSV数据的DataTable</returns>
        public static DataTable GetdataFromCVS(FileUpload fileload, string userName, string type, string method = "in")
        {
            //Encoding encoding = Common.GetType(filePath); //Encoding.ASCII;//
            DataTable dt = new DataTable();

            //StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            StreamReader sr = new StreamReader(fileload.PostedFile.InputStream);
            //string fileContent = sr.ReadToEnd();
            //encoding = sr.CurrentEncoding;
            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine = null;
            string[] tableHead = null;
            //标示列数
            int columnCount = 0;
            //标示是否是读取的第一行
            bool IsFirst = true;
            //逐行读取CSV中的数据
            while ((strLine = sr.ReadLine()) != null)
            {
                //strLine = Common.ConvertStringUTF8(strLine, encoding);
                //strLine = Common.ConvertStringUTF8(strLine);

                if (IsFirst == true)
                {
                    IsFirst = false;
                    dt.Columns.Add(new DataColumn("PKID"));
                    dt.Columns.Add(new DataColumn("OPERORDER"));
                    dt.Columns.Add(new DataColumn("CVOUCHID"));
                    dt.Columns.Add(new DataColumn("BARCODE"));
                    dt.Columns.Add(new DataColumn("OPERUSER"));
                    dt.Columns.Add(new DataColumn("OPERDATE"));
                    dt.Columns.Add(new DataColumn("COPOSCODE"));
                    dt.Columns.Add(new DataColumn("QTY"));
                    dt.Columns.Add(new DataColumn("CDEFINE23"));
                    dt.Columns.Add(new DataColumn("CDEFINE25"));
                    dt.Columns.Add(new DataColumn("CDEFINE31"));
                    dt.Columns.Add(new DataColumn("CDEFINE32"));
                    dt.Columns.Add(new DataColumn("RESERVE1"));
                    dt.Columns.Add(new DataColumn("RESERVE2"));
                }

                if (string.IsNullOrEmpty(strLine)) continue;
                aryLine = strLine.Split(',');
                if (aryLine.Count() < 4)
                {
                    return null;
                }
                else {
                    DataRow dr = dt.NewRow();
                    
                    dr["BARCODE"] = strLine;
                    dr["OPERUSER"] = userName;
                    dr["OPERDATE"] = System.DateTime.Now;
                    dr["COPOSCODE"] = "RRDLM002";
                    dr["QTY"] = aryLine[4];
                    dr["CDEFINE23"] = aryLine[0];
                    dr["CDEFINE25"] = aryLine[1];
                    dr["RESERVE1"] = 1;
                    dr["RESERVE2"] = "1281";

                    if (method == "in")
                    {
                        dr["PKID"] = Guid.NewGuid().ToString().ToUpper();
                        dr["OPERORDER"] = "LM" + System.DateTime.Now.ToString("yyyyMMddHHmmss"); //201805180001
                        dr["CVOUCHID"] = "21";
                        dr["CDEFINE31"] = type;
                        dr["CDEFINE32"] = "";
                    }
                    else
                    {
                        dr["CVOUCHID"] = "22";
                        dr["CDEFINE32"] = type;
                    }
                    

                    dt.Rows.Add(dr);
                }
            }

            sr.Close();
            return dt;
        }

        /// <summary>
        /// 直接通过DataSet更新数据库表
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="strTblName">ds中要更新的表名</param>
        /// <param name="strConnection"></param>
        /// <returns></returns>
        public static void UpdateByDataSet(DataSet ds, string strTblName)
        {
            using (SqlConnection sqlconn = new SqlConnection(connectionString))
            {
                sqlconn.Open();

                //使用加强读写锁事务     
                SqlTransaction tran = sqlconn.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {

                    ds.Tables[0].AcceptChanges();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        //所有行设为修改状态     
                        dr.SetModified();
                    }
                    //为Adapter定位目标表     

                    SqlCommand cmd = new SqlCommand(string.Format("select * from {0} where {1}", strTblName, " 1=2"), sqlconn, tran);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    SqlCommandBuilder sqlCmdBuilder = new SqlCommandBuilder(da);
                    sqlCmdBuilder.ConflictOption = ConflictOption.OverwriteChanges;
                    da.AcceptChangesDuringUpdate = false;
                    string columnsUpdateSql = "";
                    SqlParameter[] paras = new SqlParameter[ds.Tables[0].Columns.Count];
                    int parasIndex = 0;
                    //需要更新的列设置参数是,参数名为"@+列名"  
                    for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                    {
                        //此处拼接要更新的列名及其参数值  
                        columnsUpdateSql += ("[" + ds.Tables[0].Columns[i].ColumnName + "]" + "=@" + ds.Tables[0].Columns[i].ColumnName + ",");
                        if (ds.Tables[0].Columns[i].DataType.Name == "DateTime")
                        {
                            paras[i] = new SqlParameter("@" + ds.Tables[0].Columns[i].ColumnName, SqlDbType.DateTime, 23, ds.Tables[0].Columns[i].ColumnName);
                        }
                        else if (ds.Tables[0].Columns[i].DataType.Name == "Int64")
                        {
                            paras[i] = new SqlParameter("@" + ds.Tables[0].Columns[i].ColumnName, SqlDbType.NVarChar, 19, ds.Tables[0].Columns[i].ColumnName);
                        }
                        else
                        {
                            paras[i] = new SqlParameter("@" + ds.Tables[0].Columns[i].ColumnName, SqlDbType.NVarChar, 2000, ds.Tables[0].Columns[i].ColumnName);
                        }
                    }
                    if (!string.IsNullOrEmpty(columnsUpdateSql))
                    {
                        //此处去掉拼接处最后一个","  
                        columnsUpdateSql = columnsUpdateSql.Remove(columnsUpdateSql.Length - 1);
                    }
                    //此处生成where条件语句  
                    string limitSql = ("[PKID]" + "=@PKID");
                    SqlCommand updateCmd = new SqlCommand(string.Format(" UPDATE [{0}] SET {1} WHERE {2} ", strTblName, columnsUpdateSql, limitSql));
                    //不修改源DataTable     
                    updateCmd.UpdatedRowSource = UpdateRowSource.None;
                    da.UpdateCommand = updateCmd;
                    da.UpdateCommand.Parameters.AddRange(paras);
                    //da.UpdateCommand.Parameters.Add("@" + table.Columns[0].ColumnName, table.Columns[0].ColumnName);  
                    //每次往返处理的行数  
                    da.UpdateBatchSize = ds.Tables[0].Rows.Count;
                    da.Update(ds, strTblName);
                    ds.AcceptChanges();
                    tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
                finally
                {
                    sqlconn.Dispose();
                    sqlconn.Close();
                }
            }
        }


        public static int UpdateByDataTable(DataTable dt)
        {
            int res = 0;
            using (SqlConnection sqlconn = new SqlConnection(connectionString))
            {
                sqlconn.Open();
                //事务 
                SqlTransaction tran = sqlconn.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {
                    dt.AcceptChanges();
                    foreach (DataRow dr in dt.Rows)
                    {
                        //所有行设为修改状态   
                        dr.SetModified();
                    }
                    //为Adapter定位目标表 
                    SqlCommand cmd = new SqlCommand("select * from " + dt.TableName + " where 1=0", sqlconn, tran);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    SqlCommandBuilder sqlCmdBuilder = new SqlCommandBuilder(da);
                    da.AcceptChangesDuringUpdate = false;
                    
                    SqlCommand updatecmd = new SqlCommand("UPDATE " + dt.TableName + " SET CVOUCHID=@CVOUCHID,OPERDATE=getdate(),CDEFINE32=@CDEFINE32 where PKID=@PKID");
                    //不修改源DataTable   
                    updatecmd.UpdatedRowSource = UpdateRowSource.None;
                    da.UpdateCommand = updatecmd;
                  
                    da.UpdateCommand.Parameters.Add("@CVOUCHID ", SqlDbType.NVarChar, 50, "CVOUCHID ");
                    da.UpdateCommand.Parameters.Add("@CDEFINE32 ", SqlDbType.NVarChar, 120, "CDEFINE32 ");
                    da.UpdateCommand.Parameters.Add("@PKID ", SqlDbType.NVarChar, 50, "PKID ");
                    da.UpdateBatchSize = 1000;
                    res = da.Update(dt);
                    dt.AcceptChanges();
                    tran.Commit();
                    sqlconn.Close();
                }
                catch(Exception e)
                {
                    tran.Rollback();
                    return -1;
                }
            }
            return res;
        }

        public static void CondimentsDataTableToSQLServer(DataTable dt)
        {
            using (SqlConnection destinationConnection = new SqlConnection(connectionString))
            {
                destinationConnection.Open();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                {
                    try
                    {

                        bulkCopy.DestinationTableName = "KGM_HISTORYBODY";//要插入的表的表明  
                        bulkCopy.ColumnMappings.Add("PKID", "PKID");//映射字段名 DataTable列名 ,数据库 对应的列名  
                        bulkCopy.ColumnMappings.Add("OPERORDER", "OPERORDER");
                        bulkCopy.ColumnMappings.Add("CVOUCHID", "CVOUCHID");
                        bulkCopy.ColumnMappings.Add("BARCODE", "BARCODE");
                        bulkCopy.ColumnMappings.Add("OPERUSER", "OPERUSER");
                        bulkCopy.ColumnMappings.Add("OPERDATE", "OPERDATE");
                        bulkCopy.ColumnMappings.Add("COPOSCODE", "COPOSCODE");
                        bulkCopy.ColumnMappings.Add("QTY", "QTY");
                        bulkCopy.ColumnMappings.Add("CDEFINE23", "CDEFINE23");
                        bulkCopy.ColumnMappings.Add("CDEFINE25", "CDEFINE25");
                        bulkCopy.ColumnMappings.Add("CDEFINE31", "CDEFINE31");
                        bulkCopy.ColumnMappings.Add("CDEFINE32", "CDEFINE32");
                        bulkCopy.ColumnMappings.Add("RESERVE1", "RESERVE1");
                        bulkCopy.ColumnMappings.Add("RESERVE2", "RESERVE2");
                        bulkCopy.WriteToServer(dt);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                        //Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        // Close the SqlDataReader. The SqlBulkCopy  
                        // object is automatically closed at the end  
                        // of the using block.  

                    }
                }


            }

        }
    }
}
