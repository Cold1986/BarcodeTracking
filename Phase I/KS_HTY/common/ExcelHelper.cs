using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KS_HTY
{
    public class ExcelHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Path">Excel路径</param>
        /// <param name="IsExcel2010">是否是Excel 2010</param>
        /// <returns></returns>
        public static DataTable ExcelToDT(string Path, string TableName = "", bool IsExcel2010 = true)
        {
            if (!File.Exists(Path))
            {
                throw new Exception("Excel文件不存在！");
            }

            string strConn = GetStrConn(Path, IsExcel2010);
            if (string.IsNullOrEmpty(TableName))
            {
                ArrayList TableList = new ArrayList();
                TableList = GetExcelTables(Path, IsExcel2010);
                TableName = TableList[0].ToString().Trim();
            }

            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            DataTable table = new DataTable();
            strExcel = "select * from [" + TableName + "$]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                myCommand.Fill(table);
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return table;
        }

        /// <summary>
        /// 获取Excel文件数据表列表
        /// </summary>
        public static ArrayList GetExcelTables(string ExcelFileName, bool IsExcel2010 = true)
        {
            DataTable dt = new DataTable();
            ArrayList TablesList = new ArrayList();
            if (File.Exists(ExcelFileName))
            {
                string strConn = GetStrConn(ExcelFileName, IsExcel2010);
                using (OleDbConnection conn = new OleDbConnection(strConn))
                {
                    try
                    {
                        conn.Open();
                        dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                    }
                    catch (Exception exp)
                    {
                        throw exp;
                    }

                    //获取数据表个数
                    int tablecount = dt.Rows.Count;
                    for (int i = 0; i < tablecount; i++)
                    {
                        string tablename = dt.Rows[i][2].ToString().Trim().TrimEnd('$');
                        if (TablesList.IndexOf(tablename) < 0)
                        {
                            TablesList.Add(tablename);
                        }
                    }
                }
            }
            return TablesList;
        }

        /// <summary>
        /// 获取Excel文件指定数据表的数据列表
        /// </summary>
        /// <param name="ExcelFileName">Excel文件名</param>
        /// <param name="TableName">数据表名</param>
        public static ArrayList GetExcelTableColumns(string ExcelFileName, string TableName, bool IsExcel2010 = true)
        {
            DataTable dt = new DataTable();
            ArrayList ColsList = new ArrayList();
            if (File.Exists(ExcelFileName))
            {
                using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Excel 8.0;Data Source=" + ExcelFileName))
                {
                    conn.Open();
                    dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, TableName, null });

                    //获取列个数
                    int colcount = dt.Rows.Count;
                    for (int i = 0; i < colcount; i++)
                    {
                        string colname = dt.Rows[i]["Column_Name"].ToString().Trim();
                        ColsList.Add(colname);
                    }
                }
            }
            return ColsList;
        }

        /// <summary>
        /// 判断是否是老版本的Excel
        /// </summary>
        /// <param name="ExcelFileName"></param>
        /// <param name="IsExcel2010"></param>
        /// <returns></returns>
        private static string GetStrConn(string ExcelFileName, bool IsExcel2010 = true)
        {
            string strConn = string.Empty;
            if (IsExcel2010)
            {
                strConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=No;IMEX=1;'", ExcelFileName);//2010（Microsoft.ACE.OLEDB.12.0）
            }
            else
            {
                strConn = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=No;IMEX=1;'", ExcelFileName);//2003（Microsoft.Jet.Oledb.4.0）
            }
            return strConn;
        }

        /// </summary> 
        /// 导出Excel文件，自动返回可下载的文件流 
        /// </summary> 
        public static void DataTable1Excel(DataTable dtData)
        {
            GridView gvExport = null;
            HttpContext curContext = HttpContext.Current;
            StringWriter strWriter = null;
            HtmlTextWriter htmlWriter = null;
            if (dtData != null)
            {
                curContext.Response.ContentType = "application/vnd.ms-excel";
                curContext.Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                curContext.Response.Charset = "utf-8";
                strWriter = new StringWriter();
                htmlWriter = new HtmlTextWriter(strWriter);
                gvExport = new GridView();
                gvExport.DataSource = dtData.DefaultView;
                gvExport.AllowPaging = false;
                gvExport.DataBind();
                gvExport.RenderControl(htmlWriter);
                curContext.Response.Write("<meta http-equiv=\"Content-Type\" content=\"text/html;charset=gb2312\"/>" + strWriter.ToString());
                curContext.Response.End();
            }
        }

        /// <summary>
        /// 导出Excel文件，转换为可读模式
        /// </summary>
        public static void DataTable2Excel(DataTable dtData)
        {
            DataGrid dgExport = null;
            HttpContext curContext = HttpContext.Current;
            StringWriter strWriter = null;
            HtmlTextWriter htmlWriter = null;

            if (dtData != null)
            {
                curContext.Response.ContentType = "application/vnd.ms-excel";
                curContext.Response.ContentEncoding = System.Text.Encoding.UTF8;
                curContext.Response.Charset = "";
                strWriter = new StringWriter();
                htmlWriter = new HtmlTextWriter(strWriter);
                dgExport = new DataGrid();
                dgExport.DataSource = dtData.DefaultView;
                dgExport.AllowPaging = false;
                dgExport.DataBind();
                dgExport.RenderControl(htmlWriter);
                curContext.Response.Write(strWriter.ToString());
                curContext.Response.End();
            }
        }

        /// <summary>
        /// 导出Excel文件，并自定义文件名
        /// </summary>
        public static void DataTable3Excel(DataTable dtData, String FileName)
        {
            GridView dgExport = null;
            HttpContext curContext = HttpContext.Current;
            StringWriter strWriter = null;
            HtmlTextWriter htmlWriter = null;

            if (dtData != null)
            {
                HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8);
                curContext.Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + ".xls");
                curContext.Response.ContentType = "application nd.ms-excel";
                curContext.Response.ContentEncoding = System.Text.Encoding.UTF8;
                curContext.Response.Charset = "GB2312";
                strWriter = new StringWriter();
                htmlWriter = new HtmlTextWriter(strWriter);
                dgExport = new GridView();
                dgExport.DataSource = dtData.DefaultView;
                dgExport.AllowPaging = false;
                dgExport.DataBind();
                dgExport.RenderControl(htmlWriter);
                curContext.Response.Write(strWriter.ToString());
                curContext.Response.End();
            }
        }

        /// <summary>
        /// 该方法需要引用Microsoft.Office.Interop.Excel.dll 和 Microsoft.CSharp.dll
        /// 将数据由DataTable导出到Excel
        /// </summary>
        /// <param name = "dataTable" ></ param >
        /// < param name="fileName"></param>
        /// <param name = "filePath" ></ param >
        public static string exportDataTableToExcel(DataTable dataTable, string fileName, string filePath)
        {
            Microsoft.Office.Interop.Excel.Application excel;

            Microsoft.Office.Interop.Excel._Workbook workBook;

            Microsoft.Office.Interop.Excel._Worksheet workSheet;

            object misValue = System.Reflection.Missing.Value;

            excel = new Microsoft.Office.Interop.Excel.Application();

            workBook = excel.Workbooks.Add(misValue);

            workSheet = (Microsoft.Office.Interop.Excel._Worksheet)workBook.ActiveSheet;

            int rowIndex = 1;

            int colIndex = 0;

            //取得标题  
            foreach (DataColumn col in dataTable.Columns)
            {
                colIndex++;

                excel.Cells[1, colIndex] = col.ColumnName;
            }

            //取得表格中的数据  
            foreach (DataRow row in dataTable.Rows)
            {
                rowIndex++;

                colIndex = 0;

                foreach (DataColumn col in dataTable.Columns)
                {
                    colIndex++;

                    excel.Cells[rowIndex, colIndex] =

                         row[col.ColumnName].ToString().Trim();

                    //设置表格内容居中对齐  
                    //workSheet.get_Range(excel.Cells[rowIndex, colIndex],

                    //  excel.Cells[rowIndex, colIndex]).HorizontalAlignment =

                    //  Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                }
            }

            excel.Visible = true;

            string saveFile = filePath + fileName + ".xls";

            if (File.Exists(saveFile))
            {
                File.Delete(saveFile);//嘿嘿，这样不好，偷偷把原来的删掉了，暂时这样写，项目中不可以
            }

            workBook.SaveAs(saveFile, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue,

                misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,

                misValue, misValue, misValue, misValue, misValue);

            dataTable = null;

            workBook.Close(true, misValue, misValue);

            excel.Quit();

            PublicMethod.Kill(excel);//调用kill当前excel进程  

            releaseObject(workSheet);

            releaseObject(workBook);

            releaseObject(excel);

            if (!File.Exists(saveFile))
            {
                return null;
            }
            return saveFile;
        }
        /// <summary>
        /// 释放COM组件对象
        /// </summary>
        /// <param name="obj"></param>
        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        /// <summary>
        /// 关闭进程的内部类
        /// </summary>
        public class PublicMethod
        {
            [DllImport("User32.dll", CharSet = CharSet.Auto)]

            public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

            public static void Kill(Microsoft.Office.Interop.Excel.Application excel)
            {
                //如果外层没有try catch方法这个地方需要抛异常。
                IntPtr t = new IntPtr(excel.Hwnd);

                int k = 0;

                GetWindowThreadProcessId(t, out k);

                System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);

                p.Kill();
            }
        }
    }
}