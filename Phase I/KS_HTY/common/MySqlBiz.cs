using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace KS_HTY
{
    public class MySqlBiz
    {
        ///// <summary>
        /////大批量数据插入,返回成功插入行数
        ///// </summary>
        ///// <param name="connectionString">数据库连接字符串</param>
        ///// <param name="table">数据表</param>
        ///// <returns>返回成功插入行数</returns>
        //public static int BulkInsert(DataTable table)
        //{
        //    MySqlConnection GetConnection = new MySqlConnection("Server=" + dbServer + ";User Id=" + dbUser + ";Password=" + dbPwd + ";Persist Security Info=True;Database=" + dbName);


        //    if (string.IsNullOrEmpty(table.TableName)) throw new Exception("请给DataTable的TableName属性附上表名称");
        //    if (table.Rows.Count == 0) return 0;
        //    int insertCount = 0;
        //    string tmpPath = Path.GetTempFileName();
        //    //string csv = DataTableToCsv(table);
        //    //File.WriteAllText(tmpPath, csv);
        //    using (MySqlConnection conn = GetConnection)
        //    {
        //        MySqlTransaction tran = null;
        //        try
        //        {
        //            conn.Open();
        //            tran = conn.BeginTransaction();
        //            MySqlBulkLoader bulk = new MySqlBulkLoader(conn)
        //            {
        //                FieldTerminator = ",",
        //                FieldQuotationCharacter = '"',
        //                EscapeCharacter = '"',
        //                LineTerminator = "\r\n",
        //                FileName = tmpPath,
        //                NumberOfLinesToSkip = 0,
        //                TableName = table.TableName,
        //            };
        //            bulk.Columns.AddRange(table.Columns.Cast<DataColumn>().Select(colum => colum.ColumnName).ToList());
        //            insertCount = bulk.Load();
        //            tran.Commit();
        //        }
        //        catch (MySqlException ex)
        //        {
        //            if (tran != null) tran.Rollback();
        //            throw ex;
        //        }
        //    }
        //    //File.Delete(tmpPath);
        //    return insertCount;
        //}

    }
}