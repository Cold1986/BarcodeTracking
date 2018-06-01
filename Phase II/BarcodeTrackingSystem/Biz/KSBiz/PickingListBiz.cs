using BarcodeTracking.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BarcodeTracking.Biz
{
    public class PickingListBiz
    {
        public string GetPickingList(string SONo)
        {
            string res = string.Empty;
            BarcodeTracking.BLL.MST_PICKINGLIST mstBLL = new BarcodeTracking.BLL.MST_PICKINGLIST();
            DataSet result = mstBLL.getPickingListBySO(SONo);
            if (result.Tables.Count > 0)
            {
                DataTable dt = result.Tables[0];
                res = DataTableToJson(dt);
            }
            return res;
        }

        /// <summary>  
        /// table转json  
        /// </summary>  
        /// <param name="dt"></param>  
        /// <returns></returns>  
        public static string DataTableToJson(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"Name\":\"" + dt.TableName + "\",\"Rows");
            jsonBuilder.Append("\":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString().Replace("\"", "\\\""));
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }
    }
}
