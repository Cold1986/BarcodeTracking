using BarcodeTracking.Biz;
using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarcodeTracking.Handler.KS
{
    /// <summary>
    /// Summary description for palletFacade
    /// </summary>
    public class palletFacade : IHttpHandler
    {
        private string KSFactoryCode = System.Configuration.ConfigurationManager.AppSettings["KSFactoryCode"];
        LogHelper _ErrLog = new LogHelper("ErrorLog");
        HttpContext _context;
        palletBiz pallet = new palletBiz();


        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            _context = context;
            string result = string.Empty;
            try
            {
                string method = context.Request["method"];
                string palletNo = context.Request["palletNo"];//箱唛id
                string JDECode = context.Request["JDECode"];//JDE编号
                string beginDate = context.Request["beginDate"];//开始日期
                string endDate = context.Request["endDate"];//结束日期
                string palletQRCode = context.Request["palletQRCode"];//箱唛二维码
                string APN = context.Request["APN"];//APN
                string palletType = context.Request["palletType"];//palletType
                string SONo = context.Request["SONo"];//SONo

                string path = context.Server.MapPath("\\downloads\\KS\\Pallet\\");


                switch (method)
                {
                    case "searchPalletInfo"://获取卡板信息列表
                        result = pallet.GetPalletList(method, palletNo, JDECode, beginDate, endDate, palletQRCode, APN, palletType, SONo);
                        break;
                    case "exportPalletInfo"://导出卡板信息列表
                        result = pallet.GetPalletList(method, palletNo, JDECode, beginDate, endDate, palletQRCode, APN, palletType, SONo, path);
                        break;
                    case "getPHListByPalletCode"://获取卡板对应箱唛列表
                        result = pallet.getPHListByPalletCode(palletQRCode);
                        break;
                    case "exportShippingInfo"://获取箱唛信息
                        result = pallet.GetPalletList(method, palletNo, JDECode, beginDate, endDate, palletQRCode, APN, palletType, SONo, path);
                        break;
                    case "getBinderyReport"://获取生产组卡板报表信息
                        result = pallet.getBinderyReport(method, palletNo, JDECode, beginDate, endDate, palletQRCode, APN, palletType, SONo);
                        break;
                }
            }
            catch (Exception ex)
            {
                result = "error";
                _ErrLog.WriteLog("palletFacade 异常" + ex.Message);
            }
            finally
            {
                context.Response.Write(result);
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