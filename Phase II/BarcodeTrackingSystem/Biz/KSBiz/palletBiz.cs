using BarcodeTracking.BLL;
using BarcodeTracking.Common;
using Maticsoft.Common;
using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace BarcodeTracking.Biz
{
    public class palletBiz
    {
        LogHelper _ErrLog = new LogHelper("ErrorLog");
        BarcodeTracking.BLL.PH_PALLETLABEL palletlabel;
        BarcodeTracking.BLL.PH_RELATION phRelation;
        BarcodeTracking.BLL.PH_RELATIONHISTORY phRelationHistory;
        JavaScriptSerializer serializer;

        public palletBiz()
        {
            serializer = new JavaScriptSerializer();
            palletlabel = new BarcodeTracking.BLL.PH_PALLETLABEL();
            phRelation = new PH_RELATION();
            phRelationHistory = new PH_RELATIONHISTORY();
        }

        public string getPHListByPalletCode(string palletQRCode)
        {
            try
            {
                string strWhere = " PalletNocode ='" + palletQRCode + "'";
                var res = phRelation.GetModelList(strWhere);
                return serializer.Serialize(res);
            }
            catch (Exception ex)
            {
                _ErrLog.WriteLog("referenceBiz下GetReferenceList程序异常：" + ex.Message);
                throw ex;
            }
        }

        public string getPH_RELATIONHISTORYListByPalletCode(string palletQRCode)
        {
            try
            {
                string strWhere = " PalletNocode ='" + palletQRCode + "'";
                var res = phRelationHistory.GetModelList(strWhere);
                return serializer.Serialize(res);
            }
            catch (Exception ex)
            {
                _ErrLog.WriteLog("referenceBiz下getPH_RELATIONHISTORYListByPalletCode程序异常：" + ex.Message);
                throw ex;
            }
        }

        #region 生产组卡板

        /// <summary>
        /// 获取卡板信息,palletType 根据新需求调整后只会是1
        /// </summary>
        /// <param name="method">方法，查询还是导出</param>
        /// <param name="palletNo">卡板ID</param>
        /// <param name="JDECode">JDE编号</param>
        /// <param name="beginDate">查询开始日期</param>
        /// <param name="endDate">查询结束日期</param>
        /// <param name="palletQRCode">卡板二维码</param>
        /// <param name="APN">APN号</param>
        /// <returns></returns>
        public string GetPalletList(string method, string palletNo, string JDECode, string beginDate, string endDate, string palletQRCode, string APN, string palletType, string SONo, string path = "")
        {
            try
            {
                string strWhere = "1=1 and ph_palletlabel.DELETEMARK IS NULL";// and ph_palletlabel.QTY <> 0

                if (!string.IsNullOrEmpty(palletNo))
                {
                    strWhere += " and ph_palletlabel.code like '%" + palletNo + "%'";
                }
                if (!string.IsNullOrEmpty(JDECode))
                {
                    strWhere += " and ph_palletlabel.JDENO like '%" + JDECode + "%'";
                }
                if (!string.IsNullOrEmpty(palletQRCode))
                {
                    strWhere += " and ph_palletlabel.Barcode like '%" + palletQRCode + "%'";
                }
                if (!string.IsNullOrEmpty(APN))
                {
                    strWhere += " and ph_palletlabel.APN like '%" + APN + "%'";
                }
                if (palletType == "1")
                {
                    if (!string.IsNullOrEmpty(beginDate))
                    {
                        strWhere += " and datediff(dd,'" + beginDate + "', ph_palletlabel.MODIFIEDON)>=0";
                    }
                    if (!string.IsNullOrEmpty(endDate))
                    {
                        strWhere += " and datediff(dd, ph_palletlabel.MODIFIEDON,'" + endDate + "')>0";
                    }
                }
                else if (palletType == "3")
                {
                    strWhere += " and kgm_historybody.RESERVE1 = 0";
                    if (!string.IsNullOrEmpty(beginDate))
                    {
                        strWhere += " and datediff(dd,'" + beginDate + "', kgm_historybody.operdate)>=0";
                    }
                    if (!string.IsNullOrEmpty(endDate))
                    {
                        strWhere += " and datediff(dd, kgm_historybody.operdate,'" + endDate + "')>0";
                    }
                    if (!string.IsNullOrEmpty(SONo))
                    {
                        strWhere += " and kgm_historybody.cdefine23 like '%" + SONo + "%'";
                    }
                }

                // DbHelperSQL.Query(strSql.ToString());
                DataSet ds = new DataSet();

                if (palletType == "1")
                {
                    string strSql = "select ph_palletlabel.BARCODE,ph_palletlabel.CODE,ph_palletlabel.NAME,ph_palletlabel.APN,ph_palletlabel.JDENO,ph_palletlabel.BOXQTY,ph_palletlabel.BOXQTY,ph_palletlabel.QTY,ph_palletlabel.MODIFIEDON,'' as Operdate,'' as SONo from ph_palletlabel  ";
                    strSql += "where " + strWhere + " order by ph_palletlabel.MODIFIEDON";
                    ds = DbHelperSQL.Query(strSql.ToString());
                    //ds = palletlabel.GetList(strWhere);
                }
                else if (palletType == "3")
                {
                    string strSql = "select distinct(ph_palletlabel.BARCODE),ph_palletlabel.CODE,ph_palletlabel.NAME,ph_palletlabel.APN,ph_palletlabel.JDENO,ph_palletlabel.BOXQTY,ph_palletlabel.BOXQTY,ph_palletlabel.QTY,ph_palletlabel.MODIFIEDON,kgm_historybody.Operdate,kgm_historybody.cdefine23 as SONo from ph_palletlabel  ";
                    strSql += " inner join kgm_historybody  on ph_palletlabel.barcode=kgm_historybody.barcode where " + strWhere + " order by ph_palletlabel.MODIFIEDON";
                    ds = DbHelperSQL.Query(strSql.ToString());
                    //ds = palletlabel.GetList(strWhere);
                }
                DataTable dt = ds.Tables[0] ?? new DataTable();
                dt.Columns.Add("stringMODIFIEDON", typeof(string));
                dt.Columns.Add("stringOutDate", typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["stringMODIFIEDON"] = String.Format("{0:yyyy-MM-dd}", dt.Rows[i]["MODIFIEDON"]);
                    dt.Rows[i]["stringOutDate"] = String.Format("{0:yyyy-MM-dd}", dt.Rows[i]["Operdate"]);
                }

                string strList = string.Empty;

                if (method == "searchPalletInfo")//页面查询
                {
                    strList = ConvertHelper.DataTableToJsonWithJavaScriptSerializer(dt);
                }
                else if (method == "exportPalletInfo")//导出Excel
                {
                    DataTable dt2 = new DataTable();
                    dt2.Columns.Add("卡板二维码");
                    dt2.Columns.Add("卡板ID");
                    dt2.Columns.Add("产品名称");
                    dt2.Columns.Add("APN");
                    dt2.Columns.Add("JDE号");
                    dt2.Columns.Add("箱数");
                    dt2.Columns.Add("数量");
                    dt2.Columns.Add("创建日期");
                    dt2.Columns.Add("出库日期");
                    dt2.Columns.Add("出库号");
                    DataRow dr2;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dr2 = dt2.NewRow();
                        dr2["卡板二维码"] = dt.Rows[i]["BARCODE"];
                        dr2["卡板ID"] = dt.Rows[i]["CODE"];
                        dr2["产品名称"] = dt.Rows[i]["NAME"];
                        dr2["APN"] = dt.Rows[i]["APN"];
                        dr2["JDE号"] = dt.Rows[i]["JDENO"];
                        dr2["箱数"] = dt.Rows[i]["BOXQTY"];
                        dr2["数量"] = dt.Rows[i]["QTY"];
                        dr2["创建日期"] = dt.Rows[i]["stringMODIFIEDON"];
                        dr2["出库日期"] = dt.Rows[i]["stringOutDate"];
                        dr2["出库号"] = dt.Rows[i]["SONo"];
                        dt2.Rows.Add(dr2);
                    }
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                    ConvertHelper.dataTableToCsv(dt2, path + "卡板信息_" + filename + ".xls");
                    strList = serializer.Serialize("\\downloads\\KS\\Pallet\\" + "卡板信息_" + filename + ".xls");
                }
                else if (method == "exportShippingInfo")
                {
                    DataSet res3 = new DataSet();

                    if (palletType == "1")
                    {
                        string strSql = "select ph_relation.Boxcode,ph_relation.PalletNocode from ph_relation  where exists(select 1 from ph_palletlabel where " + strWhere;
                        strSql += " and ph_relation.palletnocode=ph_palletlabel.Barcode) order by ph_relation.PalletNocode";
                        res3 = DbHelperSQL.Query(strSql.ToString());
                    }
                    else if (palletType == "3")
                    {
                        string strSql = "select distinct(ph_relation.Boxcode),ph_relation.PalletNocode from ph_relation ";
                        strSql += " inner join ph_palletlabel on ph_palletlabel.Barcode=ph_relation.palletnocode";
                        strSql += " inner join kgm_historybody  on ph_palletlabel.barcode=kgm_historybody.barcode where " + strWhere + " order by ph_relation.PalletNocode";
                        res3 = DbHelperSQL.Query(strSql.ToString());
                    }
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                    ConvertHelper.dataTableToCsv(res3.Tables[0], path + "箱唛信息_" + filename + ".xls");
                    strList = serializer.Serialize("\\downloads\\KS\\Pallet\\" + "箱唛信息_" + filename + ".xls");
                }


                return strList;
            }
            catch (Exception ex)
            {
                _ErrLog.WriteLog("palletBiz下GetPalletList程序异常：" + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="palletQRCode"></param>
        /// <returns></returns>
        public string getBinderyReport(string method, string palletNo, string JDECode, string beginDate, string endDate, string palletQRCode, string APN, string palletType, string SONo)
        {

            string strWhere = "1=1 and ph_palletlabel.DELETEMARK IS NULL ";//and ph_palletlabel.QTY <> 0

            if (!string.IsNullOrEmpty(palletNo))
            {
                strWhere += " and ph_palletlabel.code like '%" + palletNo + "%'";
            }
            if (!string.IsNullOrEmpty(JDECode))
            {
                strWhere += " and ph_palletlabel.JDENO like '%" + JDECode + "%'";
            }
            if (!string.IsNullOrEmpty(palletQRCode))
            {
                strWhere += " and ph_palletlabel.Barcode like '%" + palletQRCode + "%'";
            }
            if (!string.IsNullOrEmpty(APN))
            {
                strWhere += " and ph_palletlabel.APN like '%" + APN + "%'";
            }

            if (!string.IsNullOrEmpty(beginDate))
            {
                strWhere += " and datediff(dd,'" + beginDate + "', ph_palletlabel.MODIFIEDON)>=0";
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                strWhere += " and datediff(dd, ph_palletlabel.MODIFIEDON,'" + endDate + "')>0";
            }


            string sql = @"SELECT sum(A.PACKINGQTY) 'nums', A.JOBCODE 'workNo', A.JDENO 'JDE' FROM(
                            SELECT MST_INDICATORCARD.JOBCODE 'JOBCODE', PH_PALLETLABEL.JDENO 'JDENO',MST_INDICATORCARD.work_order_qty 'PACKINGQTY' FROM PH_PALLETLABEL 
                            INNER JOIN MST_INDICATORCARD ON PH_PALLETLABEL.BARCODE = MST_INDICATORCARD.CARDNO
                            WHERE " + strWhere + ") AS A group by A.JOBCODE ,A.JDENO";
            try
            {
                DataSet ds = new DataSet();
                ds = DbHelperSQL.Query(sql.ToString());
                return ConvertHelper.DataTableToJsonWithJavaScriptSerializer(ds.Tables[0]);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region 大方法
        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="method"></param>
        /// <param name="palletNo"></param>
        /// <param name="JDECode"></param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="palletQRCode"></param>
        /// <param name="APN"></param>
        /// <param name="palletType"></param>
        /// <param name="SONo"></param>
        /// <returns></returns>
        public string GetWHPalletList(string method, string palletNo, string JDECode, string beginDate, string endDate, string palletQRCode, string APN, string palletType, string SONo)
        {
            if (palletType == "1")
            {
                return getWHInPalletList(method, palletNo, JDECode, beginDate, endDate, palletQRCode, APN, palletType, SONo);
            }
            else if (palletType == "2")
            {
                return getWHOutSOPalletList(method, palletNo, JDECode, beginDate, endDate, palletQRCode, APN, palletType, SONo);
            }
            else if(palletType == "3")
            {
                return getWHOutVMIPalletList(method, palletNo, JDECode, beginDate, endDate, palletQRCode, APN, palletType, SONo);
            }
                return "";
        }

        /// <summary>
        /// 获取报表
        /// </summary>
        /// <param name="method"></param>
        /// <param name="palletNo"></param>
        /// <param name="JDECode"></param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="palletQRCode"></param>
        /// <param name="APN"></param>
        /// <param name="palletType"></param>
        /// <param name="SONo"></param>
        /// <returns></returns>
        public string GetReport(string method, string palletNo, string JDECode, string beginDate, string endDate, string palletQRCode, string APN, string palletType, string SONo)
        {
            if (palletType == "1")
            {
                return getWHInReport(method, palletNo, JDECode, beginDate, endDate, palletQRCode, APN, palletType, SONo);
            }
            else if (palletType == "2")
            {
                return getWHOutSOReport(method, palletNo, JDECode, beginDate, endDate, palletQRCode, APN, palletType, SONo);
            }
            else if (palletType == "3")
            {
                return getWHOutVMIReport(method, palletNo, JDECode, beginDate, endDate, palletQRCode, APN, palletType, SONo);
            }
            return "";
        }

        /// <summary>
        /// 导出卡唛文件
        /// </summary>
        /// <param name="method"></param>
        /// <param name="palletNo"></param>
        /// <param name="JDECode"></param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="palletQRCode"></param>
        /// <param name="APN"></param>
        /// <param name="palletType"></param>
        /// <param name="SONo"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public string exportWHPalletList(string method, string palletNo, string JDECode, string beginDate, string endDate, string palletQRCode, string APN, string palletType, string SONo, string path = "")
        {
            if (palletType == "1")
            {
                return exportWHInPalletList(method, palletNo, JDECode, beginDate, endDate, palletQRCode, APN, palletType, SONo, path);
            }
            if (palletType == "2")
            {
                return exportWHOutSOPalletList(method, palletNo, JDECode, beginDate, endDate, palletQRCode, APN, palletType, SONo, path);
            }
            if (palletType == "3")
            {
                return exportWHOutVMIPalletList(method, palletNo, JDECode, beginDate, endDate, palletQRCode, APN, palletType, SONo, path);
            }
            return "";
        }

        /// <summary>
        /// 导出箱唛明细文件
        /// </summary>
        /// <param name="method"></param>
        /// <param name="palletNo"></param>
        /// <param name="JDECode"></param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="palletQRCode"></param>
        /// <param name="APN"></param>
        /// <param name="palletType"></param>
        /// <param name="SONo"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public string exportWHShippingList(string method, string palletNo, string JDECode, string beginDate, string endDate, string palletQRCode, string APN, string palletType, string SONo, string path = "")
        {
            if (palletType == "1")
            {
                return exportWHInShippingList(method, palletNo, JDECode, beginDate, endDate, palletQRCode, APN, palletType, SONo, path);
            }
            else if (palletType == "2")
            {
                return exportWHOutSOShippingList(method, palletNo, JDECode, beginDate, endDate, palletQRCode, APN, palletType, SONo, path);
            }
            else if (palletType == "3")
            {
                return exportWHOutVMIShippingList(method, palletNo, JDECode, beginDate, endDate, palletQRCode, APN, palletType, SONo, path);
            }
            return "";
        }
        #endregion

        #region 内仓入库方法
        /// <summary>
        /// 内仓入库报表
        /// </summary>
        /// <param name="method"></param>
        /// <param name="palletNo"></param>
        /// <param name="JDECode"></param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="palletQRCode"></param>
        /// <param name="APN"></param>
        /// <param name="palletType"></param>
        /// <param name="SONo"></param>
        /// <returns></returns>
        public string getWHInReport(string method, string palletNo, string JDECode, string beginDate, string endDate, string palletQRCode, string APN, string palletType, string SONo)
        {

            string strWhere = "1=1 and  KGM_HISTORYBODY.CVOUCHID = '08'";//ph_palletlabel.DELETEMARK IS NULL and ph_palletlabel.QTY <> 0 and

            if (!string.IsNullOrEmpty(palletNo))
            {
                strWhere += " and ph_palletlabel.code like '%" + palletNo + "%'";
            }
            if (!string.IsNullOrEmpty(JDECode))
            {
                strWhere += " and ph_palletlabel.JDENO like '%" + JDECode + "%'";
            }
            if (!string.IsNullOrEmpty(palletQRCode))
            {
                strWhere += " and ph_palletlabel.Barcode like '%" + palletQRCode + "%'";
            }
            if (!string.IsNullOrEmpty(APN))
            {
                strWhere += " and ph_palletlabel.APN like '%" + APN + "%'";
            }

            if (!string.IsNullOrEmpty(beginDate))
            {
                strWhere += " and datediff(dd,'" + beginDate + "', KGM_HISTORYBODY.OPERDATE)>=0";
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                strWhere += " and datediff(dd, KGM_HISTORYBODY.OPERDATE,'" + endDate + "')>0";
            }
            if (!string.IsNullOrEmpty(SONo))
            {
                strWhere += " and MST_INDICATORCARD.JOBCODE like '%" + SONo + "%'";
            }

            string sql = @"SELECT SUM(MST_INDICATORCARD.work_order_qty) as 'nums', MST_INDICATORCARD.JOBCODE as 'workorder', MST_INDICATORCARD.JDECODE  as'JDE'
                            FROM KGM_HISTORYBODY KGM_HISTORYBODY
                            LEFT JOIN PH_PALLETLABEL ph_palletlabel ON ph_palletlabel.BARCODE = KGM_HISTORYBODY.BARCODE
                            LEFT JOIN MST_INDICATORCARD MST_INDICATORCARD ON ph_palletlabel.BARCODE = MST_INDICATORCARD.CARDNO
                            WHERE " + strWhere + "group by MST_INDICATORCARD.JOBCODE, MST_INDICATORCARD.JDECODE;";

            try
            {
                DataSet ds = new DataSet();
                ds = DbHelperSQL.Query(sql.ToString());
                return ConvertHelper.DataTableToJsonWithJavaScriptSerializer(ds.Tables[0]);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string getWHInPalletList(string method, string palletNo, string JDECode, string beginDate, string endDate, string palletQRCode, string APN, string palletType, string SONo)
        {

            string strWhere = "1=1 and  KGM_HISTORYBODY.CVOUCHID = '08'";//ph_palletlabel.DELETEMARK IS NULL and ph_palletlabel.QTY <> 0 and

            if (!string.IsNullOrEmpty(palletNo))
            {
                strWhere += " and ph_palletlabel.code like '%" + palletNo + "%'";
            }
            if (!string.IsNullOrEmpty(JDECode))
            {
                strWhere += " and ph_palletlabel.JDENO like '%" + JDECode + "%'";
            }
            if (!string.IsNullOrEmpty(palletQRCode))
            {
                strWhere += " and ph_palletlabel.Barcode like '%" + palletQRCode + "%'";
            }
            if (!string.IsNullOrEmpty(APN))
            {
                strWhere += " and ph_palletlabel.APN like '%" + APN + "%'";
            }

            if (!string.IsNullOrEmpty(beginDate))
            {
                strWhere += " and datediff(dd,'" + beginDate + "', KGM_HISTORYBODY.OPERDATE)>=0";
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                strWhere += " and datediff(dd, KGM_HISTORYBODY.OPERDATE,'" + endDate + "')>0";
            }

            if (!string.IsNullOrEmpty(SONo))
            {
                strWhere += " and MST_INDICATORCARD.JOBCODE like '%" + SONo + "%'";
            }


            string sql = @"Select ph_palletlabel.*,KGM_HISTORYBODY.OPERDATE
                            FROM KGM_HISTORYBODY KGM_HISTORYBODY
                            LEFT JOIN PH_PALLETLABEL ph_palletlabel ON ph_palletlabel.BARCODE = KGM_HISTORYBODY.BARCODE
                            LEFT JOIN MST_INDICATORCARD MST_INDICATORCARD ON ph_palletlabel.BARCODE = MST_INDICATORCARD.CARDNO
                            WHERE " + strWhere;


            try
            {
                DataSet ds = new DataSet();
                ds = DbHelperSQL.Query(sql.ToString());
                return ConvertHelper.DataTableToJsonWithJavaScriptSerializer(ds.Tables[0]);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 导出内仓入库卡板信息
        /// </summary>
        /// <param name="method"></param>
        /// <param name="palletNo"></param>
        /// <param name="JDECode"></param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="palletQRCode"></param>
        /// <param name="APN"></param>
        /// <param name="palletType"></param>
        /// <param name="SONo"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public string exportWHInPalletList(string method, string palletNo, string JDECode, string beginDate, string endDate, string palletQRCode, string APN, string palletType, string SONo, string path)
        {
            string strWhere = "1=1 and  KGM_HISTORYBODY.CVOUCHID = '08'";//ph_palletlabel.DELETEMARK IS NULL and ph_palletlabel.QTY <> 0 and

            if (!string.IsNullOrEmpty(palletNo))
            {
                strWhere += " and ph_palletlabel.code like '%" + palletNo + "%'";
            }
            if (!string.IsNullOrEmpty(JDECode))
            {
                strWhere += " and ph_palletlabel.JDENO like '%" + JDECode + "%'";
            }
            if (!string.IsNullOrEmpty(palletQRCode))
            {
                strWhere += " and ph_palletlabel.Barcode like '%" + palletQRCode + "%'";
            }
            if (!string.IsNullOrEmpty(APN))
            {
                strWhere += " and ph_palletlabel.APN like '%" + APN + "%'";
            }

            if (!string.IsNullOrEmpty(beginDate))
            {
                strWhere += " and datediff(dd,'" + beginDate + "', KGM_HISTORYBODY.OPERDATE)>=0";
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                strWhere += " and datediff(dd, KGM_HISTORYBODY.OPERDATE,'" + endDate + "')>0";
            }

            if (!string.IsNullOrEmpty(SONo))
            {
                strWhere += " and MST_INDICATORCARD.JOBCODE like '%" + SONo + "%'";
            }


            string sql = @"Select ph_palletlabel.*,KGM_HISTORYBODY.OPERDATE, MST_INDICATORCARD.work_order_qty
                            FROM KGM_HISTORYBODY KGM_HISTORYBODY
                            LEFT JOIN PH_PALLETLABEL ph_palletlabel ON ph_palletlabel.BARCODE = KGM_HISTORYBODY.BARCODE
                            LEFT JOIN MST_INDICATORCARD MST_INDICATORCARD ON ph_palletlabel.BARCODE = MST_INDICATORCARD.CARDNO
                            WHERE " + strWhere;


            try
            {
                DataSet ds = new DataSet();
                ds = DbHelperSQL.Query(sql.ToString());

                DataTable dt2 = new DataTable();
                dt2.Columns.Add("卡板二维码");
                dt2.Columns.Add("卡板ID");
                dt2.Columns.Add("产品名称");
                dt2.Columns.Add("APN");
                dt2.Columns.Add("JDE号");
                dt2.Columns.Add("箱数");
                dt2.Columns.Add("数量");
                dt2.Columns.Add("操作日期");

                DataRow dr2;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dr2 = dt2.NewRow();
                    dr2["卡板二维码"] = ds.Tables[0].Rows[i]["BARCODE"];
                    dr2["卡板ID"] = ds.Tables[0].Rows[i]["CODE"];
                    dr2["产品名称"] = ds.Tables[0].Rows[i]["NAME"];
                    dr2["APN"] = ds.Tables[0].Rows[i]["APN"];
                    dr2["JDE号"] = ds.Tables[0].Rows[i]["JDENO"];
                    dr2["箱数"] = ds.Tables[0].Rows[i]["BOXQTY"];
                    //dr2["数量"] = ds.Tables[0].Rows[i]["QTY"];
                    dr2["数量"] = ds.Tables[0].Rows[i]["work_order_qty"];
                    dr2["操作日期"] = ds.Tables[0].Rows[i]["OPERDATE"];
                    dt2.Rows.Add(dr2);
                }
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                ConvertHelper.dataTableToCsv(dt2, path + "内仓入库卡板信息_" + filename + ".xls");
                return serializer.Serialize("\\downloads\\KS\\Pallet\\" + "内仓入库卡板信息_" + filename + ".xls");

                //return ConvertHelper.DataTableToJsonWithJavaScriptSerializer(ds.Tables[0]);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 导出内仓入库箱唛信息
        /// </summary>
        /// <param name="method"></param>
        /// <param name="palletNo"></param>
        /// <param name="JDECode"></param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="palletQRCode"></param>
        /// <param name="APN"></param>
        /// <param name="palletType"></param>
        /// <param name="SONo"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public string exportWHInShippingList(string method, string palletNo, string JDECode, string beginDate, string endDate, string palletQRCode, string APN, string palletType, string SONo, string path)
        {
            string strWhere = "1=1 and  KGM_HISTORYBODY.CVOUCHID = '08'";//ph_palletlabel.DELETEMARK IS NULL and ph_palletlabel.QTY <> 0 and

            if (!string.IsNullOrEmpty(palletNo))
            {
                strWhere += " and ph_palletlabel.code like '%" + palletNo + "%'";
            }
            if (!string.IsNullOrEmpty(JDECode))
            {
                strWhere += " and ph_palletlabel.JDENO like '%" + JDECode + "%'";
            }
            if (!string.IsNullOrEmpty(palletQRCode))
            {
                strWhere += " and ph_palletlabel.Barcode like '%" + palletQRCode + "%'";
            }
            if (!string.IsNullOrEmpty(APN))
            {
                strWhere += " and ph_palletlabel.APN like '%" + APN + "%'";
            }

            if (!string.IsNullOrEmpty(beginDate))
            {
                strWhere += " and datediff(dd,'" + beginDate + "', KGM_HISTORYBODY.OPERDATE)>=0";
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                strWhere += " and datediff(dd, KGM_HISTORYBODY.OPERDATE,'" + endDate + "')>0";
            }

            if (!string.IsNullOrEmpty(SONo))
            {
                strWhere += " and MST_INDICATORCARD.JOBCODE like '%" + SONo + "%'";
            }

            string sql = @"select distinct([PH_RELATIONHISTORY].Boxcode), [PH_RELATIONHISTORY].PalletNocode 
                            FROM KGM_HISTORYBODY KGM_HISTORYBODY
                            LEFT JOIN PH_PALLETLABEL ph_palletlabel ON ph_palletlabel.BARCODE = KGM_HISTORYBODY.BARCODE
                            LEFT JOIN PH_RELATIONHISTORY PH_RELATIONHISTORY on ph_palletlabel.Barcode=PH_RELATIONHISTORY.palletnocode
                            LEFT JOIN MST_INDICATORCARD MST_INDICATORCARD ON ph_palletlabel.BARCODE = MST_INDICATORCARD.CARDNO
                            WHERE " + strWhere;
            try
            {
                DataSet res3 = DbHelperSQL.Query(sql.ToString());

                string filename = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                ConvertHelper.dataTableToCsv(res3.Tables[0], path + "内仓入库箱唛信息__" + filename + ".xls");
                return serializer.Serialize("\\downloads\\KS\\Pallet\\" + "内仓入库箱唛信息__" + filename + ".xls");
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        #endregion

        #region 销售出库方法

        /// <summary>
        /// 外仓销售出库报表
        /// </summary>
        /// <param name="method"></param>
        /// <param name="palletNo"></param>
        /// <param name="JDECode"></param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="palletQRCode"></param>
        /// <param name="APN"></param>
        /// <param name="palletType"></param>
        /// <param name="SONo"></param>
        /// <returns></returns>
        public string getWHOutSOReport(string method, string palletNo, string JDECode, string beginDate, string endDate, string palletQRCode, string APN, string palletType, string SONo)
        {

            string strWhere = "1=1  and KGM_HISTORYBODY.CVOUCHID = '03'";//and ph_palletlabel.DELETEMARK IS NULL and ph_palletlabel.QTY <> 0

            if (!string.IsNullOrEmpty(palletNo))
            {
                strWhere += " and ph_palletlabel.code like '%" + palletNo + "%'";
            }
            if (!string.IsNullOrEmpty(JDECode))
            {
                strWhere += " and ph_palletlabel.JDENO like '%" + JDECode + "%'";
            }
            if (!string.IsNullOrEmpty(palletQRCode))
            {
                strWhere += " and ph_palletlabel.Barcode like '%" + palletQRCode + "%'";
            }
            if (!string.IsNullOrEmpty(APN))
            {
                strWhere += " and ph_palletlabel.APN like '%" + APN + "%'";
            }

            if (!string.IsNullOrEmpty(beginDate))
            {
                strWhere += " and datediff(dd,'" + beginDate + "', KGM_HISTORYBODY.OPERDATE)>=0";
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                strWhere += " and datediff(dd, KGM_HISTORYBODY.OPERDATE,'" + endDate + "')>0";
            }
            if (!string.IsNullOrEmpty(SONo))
            {
                strWhere += " and KGM_HISTORYBODY.CDEFINE23 like '%" + SONo + "%'";
            }


            string sql = @"SELECT SUM(KGM_HISTORYBODY.QTY) as 'nums', KGM_HISTORYBODY.CDEFINE23 as 'sono', KGM_HISTORYBODY.CDEFINE25  as'JDE'
                            FROM KGM_HISTORYBODY KGM_HISTORYBODY
                            LEFT JOIN PH_PALLETLABEL ph_palletlabel ON ph_palletlabel.BARCODE = KGM_HISTORYBODY.BARCODE
                            WHERE " + strWhere + "group by KGM_HISTORYBODY.CDEFINE23, KGM_HISTORYBODY.CDEFINE25";


            try
            {
                DataSet ds = new DataSet();
                ds = DbHelperSQL.Query(sql.ToString());
                return ConvertHelper.DataTableToJsonWithJavaScriptSerializer(ds.Tables[0]);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string getWHOutSOPalletList(string method, string palletNo, string JDECode, string beginDate, string endDate, string palletQRCode, string APN, string palletType, string SONo)
        {

            string strWhere = "1=1 and  KGM_HISTORYBODY.CVOUCHID = '03'";//ph_palletlabel.DELETEMARK IS NULL and ph_palletlabel.QTY <> 0 and

            if (!string.IsNullOrEmpty(palletNo))
            {
                strWhere += " and ph_palletlabel.code like '%" + palletNo + "%'";
            }
            if (!string.IsNullOrEmpty(JDECode))
            {
                strWhere += " and ph_palletlabel.JDENO like '%" + JDECode + "%'";
            }
            if (!string.IsNullOrEmpty(palletQRCode))
            {
                strWhere += " and ph_palletlabel.Barcode like '%" + palletQRCode + "%'";
            }
            if (!string.IsNullOrEmpty(APN))
            {
                strWhere += " and ph_palletlabel.APN like '%" + APN + "%'";
            }

            if (!string.IsNullOrEmpty(beginDate))
            {
                strWhere += " and datediff(dd,'" + beginDate + "', KGM_HISTORYBODY.OPERDATE)>=0";
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                strWhere += " and datediff(dd, KGM_HISTORYBODY.OPERDATE,'" + endDate + "')>0";
            }

            if (!string.IsNullOrEmpty(SONo))
            {
                strWhere += " and KGM_HISTORYBODY.CDEFINE23 like '%" + SONo + "%'";
            }


            string sql = @"Select distinct ph_palletlabel.*,KGM_HISTORYBODY.CDEFINE23 as SONo,KGM_HISTORYBODY.OPERDATE
                            FROM KGM_HISTORYBODY KGM_HISTORYBODY
                            LEFT JOIN PH_PALLETLABEL ph_palletlabel ON ph_palletlabel.BARCODE = KGM_HISTORYBODY.BARCODE
                            WHERE " + strWhere;


            try
            {
                DataSet ds = new DataSet();
                ds = DbHelperSQL.Query(sql.ToString());
                return ConvertHelper.DataTableToJsonWithJavaScriptSerializer(ds.Tables[0]);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string exportWHOutSOPalletList(string method, string palletNo, string JDECode, string beginDate, string endDate, string palletQRCode, string APN, string palletType, string SONo, string path)
        {
            string strWhere = "1=1 and  KGM_HISTORYBODY.CVOUCHID = '03'";//ph_palletlabel.DELETEMARK IS NULL and ph_palletlabel.QTY <> 0 and

            if (!string.IsNullOrEmpty(palletNo))
            {
                strWhere += " and ph_palletlabel.code like '%" + palletNo + "%'";
            }
            if (!string.IsNullOrEmpty(JDECode))
            {
                strWhere += " and ph_palletlabel.JDENO like '%" + JDECode + "%'";
            }
            if (!string.IsNullOrEmpty(palletQRCode))
            {
                strWhere += " and ph_palletlabel.Barcode like '%" + palletQRCode + "%'";
            }
            if (!string.IsNullOrEmpty(APN))
            {
                strWhere += " and ph_palletlabel.APN like '%" + APN + "%'";
            }

            if (!string.IsNullOrEmpty(beginDate))
            {
                strWhere += " and datediff(dd,'" + beginDate + "', KGM_HISTORYBODY.OPERDATE)>=0";
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                strWhere += " and datediff(dd, KGM_HISTORYBODY.OPERDATE,'" + endDate + "')>0";
            }

            if (!string.IsNullOrEmpty(SONo))
            {
                strWhere += " and KGM_HISTORYBODY.CDEFINE23 like '%" + SONo + "%'";
            }


            string sql = @"Select distinct ph_palletlabel.*,KGM_HISTORYBODY.CDEFINE23 as SONo,KGM_HISTORYBODY.OPERDATE
                            FROM KGM_HISTORYBODY KGM_HISTORYBODY
                            LEFT JOIN PH_PALLETLABEL ph_palletlabel ON ph_palletlabel.BARCODE = KGM_HISTORYBODY.BARCODE
                           
                            WHERE " + strWhere;


            try
            {
                DataSet ds = new DataSet();
                ds = DbHelperSQL.Query(sql.ToString());

                DataTable dt2 = new DataTable();
                dt2.Columns.Add("销售单号");
                dt2.Columns.Add("卡板二维码");
                dt2.Columns.Add("卡板ID");
                dt2.Columns.Add("产品名称");
                dt2.Columns.Add("APN");
                dt2.Columns.Add("JDE号");
                dt2.Columns.Add("箱数");
                dt2.Columns.Add("数量");
                dt2.Columns.Add("操作日期");

                DataRow dr2;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dr2 = dt2.NewRow();
                    dr2["销售单号"] = ds.Tables[0].Rows[i]["SONo"];
                    dr2["卡板二维码"] = ds.Tables[0].Rows[i]["BARCODE"];
                    dr2["卡板ID"] = ds.Tables[0].Rows[i]["CODE"];
                    dr2["产品名称"] = ds.Tables[0].Rows[i]["NAME"];
                    dr2["APN"] = ds.Tables[0].Rows[i]["APN"];
                    dr2["JDE号"] = ds.Tables[0].Rows[i]["JDENO"];
                    dr2["箱数"] = ds.Tables[0].Rows[i]["BOXQTY"];
                    dr2["数量"] = ds.Tables[0].Rows[i]["QTY"];
                    dr2["操作日期"] = ds.Tables[0].Rows[i]["OPERDATE"];
                    dt2.Rows.Add(dr2);
                }
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                ConvertHelper.dataTableToCsv(dt2, path + "销售出库卡板信息_" + filename + ".xls");
                return serializer.Serialize("\\downloads\\KS\\Pallet\\" + "销售出库卡板信息_" + filename + ".xls");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string exportWHOutSOShippingList(string method, string palletNo, string JDECode, string beginDate, string endDate, string palletQRCode, string APN, string palletType, string SONo, string path)
        {
            string strWhere = "1=1 and  KGM_HISTORYBODY.CVOUCHID = '03'";//ph_palletlabel.DELETEMARK IS NULL and ph_palletlabel.QTY <> 0 and

            if (!string.IsNullOrEmpty(palletNo))
            {
                strWhere += " and ph_palletlabel.code like '%" + palletNo + "%'";
            }
            if (!string.IsNullOrEmpty(JDECode))
            {
                strWhere += " and ph_palletlabel.JDENO like '%" + JDECode + "%'";
            }
            if (!string.IsNullOrEmpty(palletQRCode))
            {
                strWhere += " and ph_palletlabel.Barcode like '%" + palletQRCode + "%'";
            }
            if (!string.IsNullOrEmpty(APN))
            {
                strWhere += " and ph_palletlabel.APN like '%" + APN + "%'";
            }

            if (!string.IsNullOrEmpty(beginDate))
            {
                strWhere += " and datediff(dd,'" + beginDate + "', KGM_HISTORYBODY.OPERDATE)>=0";
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                strWhere += " and datediff(dd, KGM_HISTORYBODY.OPERDATE,'" + endDate + "')>0";
            }

            if (!string.IsNullOrEmpty(SONo))
            {
                strWhere += " and KGM_HISTORYBODY.CDEFINE23 like '%" + SONo + "%'";
            }

            string sql = @"select distinct([PH_RELATIONHISTORY].Boxcode), [PH_RELATIONHISTORY].PalletNocode 
                            FROM KGM_HISTORYBODY KGM_HISTORYBODY
                            LEFT JOIN PH_PALLETLABEL ph_palletlabel ON ph_palletlabel.BARCODE = KGM_HISTORYBODY.BARCODE
                            LEFT JOIN PH_RELATIONHISTORY PH_RELATIONHISTORY on ph_palletlabel.Barcode=PH_RELATIONHISTORY.palletnocode
                            WHERE " + strWhere;
            try
            {
                DataSet res3 = DbHelperSQL.Query(sql.ToString());

                string filename = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                ConvertHelper.dataTableToCsv(res3.Tables[0], path + "销售出库箱唛信息__" + filename + ".xls");
                return serializer.Serialize("\\downloads\\KS\\Pallet\\" + "销售出库箱唛信息__" + filename + ".xls");
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        #endregion

        #region VMI方法
        public string getWHOutVMIReport(string method, string palletNo, string JDECode, string beginDate, string endDate, string palletQRCode, string APN, string palletType, string SONo)
        {

            string strWhere = "1=1 and  KGM_HISTORYBODY.CVOUCHID = '06'";//ph_palletlabel.DELETEMARK IS NULL and ph_palletlabel.QTY <> 0 and

            if (!string.IsNullOrEmpty(palletNo))
            {
                strWhere += " and ph_palletlabel.code like '%" + palletNo + "%'";
            }
            if (!string.IsNullOrEmpty(JDECode))
            {
                strWhere += " and ph_palletlabel.JDENO like '%" + JDECode + "%'";
            }
            if (!string.IsNullOrEmpty(palletQRCode))
            {
                strWhere += " and ph_palletlabel.Barcode like '%" + palletQRCode + "%'";
            }
            if (!string.IsNullOrEmpty(APN))
            {
                strWhere += " and ph_palletlabel.APN like '%" + APN + "%'";
            }

            if (!string.IsNullOrEmpty(beginDate))
            {
                strWhere += " and datediff(dd,'" + beginDate + "', KGM_HISTORYBODY.OPERDATE)>=0";
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                strWhere += " and datediff(dd, KGM_HISTORYBODY.OPERDATE,'" + endDate + "')>0";
            }
            if (!string.IsNullOrEmpty(SONo))
            {
                strWhere += " and KGM_HISTORYBODY.CDEFINE23 like '%" + SONo + "%'";
            }


            string sql = @"SELECT SUM(KGM_HISTORYBODY.QTY) as 'nums', KGM_HISTORYBODY.CDEFINE23 as 'VMI', KGM_HISTORYBODY.CDEFINE25  as'JDE'
                            FROM KGM_HISTORYBODY KGM_HISTORYBODY
                            LEFT JOIN PH_PALLETLABEL ph_palletlabel ON ph_palletlabel.BARCODE = KGM_HISTORYBODY.BARCODE
                            WHERE " + strWhere + "group by KGM_HISTORYBODY.CDEFINE23, KGM_HISTORYBODY.CDEFINE25";


            try
            {
                DataSet ds = new DataSet();
                ds = DbHelperSQL.Query(sql.ToString());
                return ConvertHelper.DataTableToJsonWithJavaScriptSerializer(ds.Tables[0]);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string getWHOutVMIPalletList(string method, string palletNo, string JDECode, string beginDate, string endDate, string palletQRCode, string APN, string palletType, string SONo)
        {

            string strWhere = "1=1 and KGM_HISTORYBODY.CVOUCHID = '06'"; //ph_palletlabel.DELETEMARK IS NULL and ph_palletlabel.QTY <> 0

            if (!string.IsNullOrEmpty(palletNo))
            {
                strWhere += " and ph_palletlabel.code like '%" + palletNo + "%'";
            }
            if (!string.IsNullOrEmpty(JDECode))
            {
                strWhere += " and ph_palletlabel.JDENO like '%" + JDECode + "%'";
            }
            if (!string.IsNullOrEmpty(palletQRCode))
            {
                strWhere += " and ph_palletlabel.Barcode like '%" + palletQRCode + "%'";
            }
            if (!string.IsNullOrEmpty(APN))
            {
                strWhere += " and ph_palletlabel.APN like '%" + APN + "%'";
            }

            if (!string.IsNullOrEmpty(beginDate))
            {
                strWhere += " and datediff(dd,'" + beginDate + "', KGM_HISTORYBODY.OPERDATE)>=0";
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                strWhere += " and datediff(dd, KGM_HISTORYBODY.OPERDATE,'" + endDate + "')>0";
            }

            if (!string.IsNullOrEmpty(SONo))
            {
                strWhere += " and KGM_HISTORYBODY.CDEFINE23 like '%" + SONo + "%'";
            }


            string sql = @"Select distinct ph_palletlabel.*,KGM_HISTORYBODY.CDEFINE23 as VMI,KGM_HISTORYBODY.OPERDATE
                            FROM KGM_HISTORYBODY KGM_HISTORYBODY
                            LEFT JOIN PH_PALLETLABEL ph_palletlabel ON ph_palletlabel.BARCODE = KGM_HISTORYBODY.BARCODE
                            WHERE " + strWhere;


            try
            {
                DataSet ds = new DataSet();
                ds = DbHelperSQL.Query(sql.ToString());
                return ConvertHelper.DataTableToJsonWithJavaScriptSerializer(ds.Tables[0]);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string exportWHOutVMIPalletList(string method, string palletNo, string JDECode, string beginDate, string endDate, string palletQRCode, string APN, string palletType, string SONo, string path)
        {
            string strWhere = "1=1 and  KGM_HISTORYBODY.CVOUCHID = '06'";//ph_palletlabel.DELETEMARK IS NULL and ph_palletlabel.QTY <> 0 and

            if (!string.IsNullOrEmpty(palletNo))
            {
                strWhere += " and ph_palletlabel.code like '%" + palletNo + "%'";
            }
            if (!string.IsNullOrEmpty(JDECode))
            {
                strWhere += " and ph_palletlabel.JDENO like '%" + JDECode + "%'";
            }
            if (!string.IsNullOrEmpty(palletQRCode))
            {
                strWhere += " and ph_palletlabel.Barcode like '%" + palletQRCode + "%'";
            }
            if (!string.IsNullOrEmpty(APN))
            {
                strWhere += " and ph_palletlabel.APN like '%" + APN + "%'";
            }

            if (!string.IsNullOrEmpty(beginDate))
            {
                strWhere += " and datediff(dd,'" + beginDate + "', KGM_HISTORYBODY.OPERDATE)>=0";
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                strWhere += " and datediff(dd, KGM_HISTORYBODY.OPERDATE,'" + endDate + "')>0";
            }

            if (!string.IsNullOrEmpty(SONo))
            {
                strWhere += " and KGM_HISTORYBODY.CDEFINE23 like '%" + SONo + "%'";
            }


            string sql = @"Select distinct ph_palletlabel.*,KGM_HISTORYBODY.CDEFINE23 as VMINo,KGM_HISTORYBODY.OPERDATE
                            FROM KGM_HISTORYBODY KGM_HISTORYBODY
                            LEFT JOIN PH_PALLETLABEL ph_palletlabel ON ph_palletlabel.BARCODE = KGM_HISTORYBODY.BARCODE
                           
                            WHERE " + strWhere;


            try
            {
                DataSet ds = new DataSet();
                ds = DbHelperSQL.Query(sql.ToString());

                DataTable dt2 = new DataTable();
                dt2.Columns.Add("VMI单号");
                dt2.Columns.Add("卡板二维码");
                dt2.Columns.Add("卡板ID");
                dt2.Columns.Add("产品名称");
                dt2.Columns.Add("APN");
                dt2.Columns.Add("JDE号");
                dt2.Columns.Add("箱数");
                dt2.Columns.Add("数量");
                dt2.Columns.Add("操作日期");

                DataRow dr2;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dr2 = dt2.NewRow();
                    dr2["VMI单号"] = ds.Tables[0].Rows[i]["VMINo"];
                    dr2["卡板二维码"] = ds.Tables[0].Rows[i]["BARCODE"];
                    dr2["卡板ID"] = ds.Tables[0].Rows[i]["CODE"];
                    dr2["产品名称"] = ds.Tables[0].Rows[i]["NAME"];
                    dr2["APN"] = ds.Tables[0].Rows[i]["APN"];
                    dr2["JDE号"] = ds.Tables[0].Rows[i]["JDENO"];
                    dr2["箱数"] = ds.Tables[0].Rows[i]["BOXQTY"];
                    dr2["数量"] = ds.Tables[0].Rows[i]["QTY"];
                    dr2["操作日期"] = ds.Tables[0].Rows[i]["OPERDATE"];
                    dt2.Rows.Add(dr2);
                }
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                ConvertHelper.dataTableToCsv(dt2, path + "VMI出库卡板信息_" + filename + ".xls");
                return serializer.Serialize("\\downloads\\KS\\Pallet\\" + "VMI出库卡板信息_" + filename + ".xls");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string exportWHOutVMIShippingList(string method, string palletNo, string JDECode, string beginDate, string endDate, string palletQRCode, string APN, string palletType, string SONo, string path)
        {
            string strWhere = "1=1 and KGM_HISTORYBODY.CVOUCHID = '06'";//ph_palletlabel.DELETEMARK IS NULL and ph_palletlabel.QTY <> 0 and

            if (!string.IsNullOrEmpty(palletNo))
            {
                strWhere += " and ph_palletlabel.code like '%" + palletNo + "%'";
            }
            if (!string.IsNullOrEmpty(JDECode))
            {
                strWhere += " and ph_palletlabel.JDENO like '%" + JDECode + "%'";
            }
            if (!string.IsNullOrEmpty(palletQRCode))
            {
                strWhere += " and ph_palletlabel.Barcode like '%" + palletQRCode + "%'";
            }
            if (!string.IsNullOrEmpty(APN))
            {
                strWhere += " and ph_palletlabel.APN like '%" + APN + "%'";
            }

            if (!string.IsNullOrEmpty(beginDate))
            {
                strWhere += " and datediff(dd,'" + beginDate + "', KGM_HISTORYBODY.OPERDATE)>=0";
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                strWhere += " and datediff(dd, KGM_HISTORYBODY.OPERDATE,'" + endDate + "')>0";
            }

            if (!string.IsNullOrEmpty(SONo))
            {
                strWhere += " and KGM_HISTORYBODY.CDEFINE23 like '%" + SONo + "%'";
            }

            string sql = @"select distinct([PH_RELATIONHISTORY].Boxcode), [PH_RELATIONHISTORY].PalletNocode 
                            FROM KGM_HISTORYBODY KGM_HISTORYBODY
                            LEFT JOIN PH_PALLETLABEL ph_palletlabel ON ph_palletlabel.BARCODE = KGM_HISTORYBODY.BARCODE
                            LEFT JOIN PH_RELATIONHISTORY PH_RELATIONHISTORY on ph_palletlabel.Barcode=PH_RELATIONHISTORY.palletnocode
                            WHERE " + strWhere;
            try
            {
                DataSet res3 = DbHelperSQL.Query(sql.ToString());

                string filename = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                ConvertHelper.dataTableToCsv(res3.Tables[0], path + "VMI出库箱唛信息__" + filename + ".xls");
                return serializer.Serialize("\\downloads\\KS\\Pallet\\" + "VMI出库箱唛信息__" + filename + ".xls");
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        #endregion
    }
}
