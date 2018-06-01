using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maticsoft.Common;
using BarcodeTracking.Biz;
using BarcodeTracking.Model;
using System.Web.SessionState;


namespace BarcodeTracking.Handler.KS
{
    /// <summary>
    /// referenceFacade 的摘要说明
    /// </summary>
    public class referenceFacade : IHttpHandler, IReadOnlySessionState 
    {
        private string KSFactoryCode = System.Configuration.ConfigurationManager.AppSettings["KSFactoryCode"];
        LogHelper _ErrLog = new LogHelper("ErrorLog");
        referenceBiz refBiz = new referenceBiz();
        UserBiz userBiz = new UserBiz();
        ref_versionBiz refVBiz = new ref_versionBiz();
        HttpContext _context;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            _context = context;
            string result = string.Empty;
            try
            {
                string method = context.Request["method"];
                string id = context.Request["id"];
                string name = context.Request["name"];//产品名称
                string project = context.Request["project"];//项目
                string color = context.Request["color"];//颜色
                string boxType = context.Request["boxType"];//合型
                string productVersion = context.Request["productVersion"];//版本
                string apn = context.Request["apn"];//AP/N
                string label = context.Request["label"];//小标签
                string jdeNo = context.Request["jdeNo"];//JDE料号
                string outJDENo = context.Request["outJDENo"];//出wistronJDE料号
                string oemCustNo = context.Request["oemCustNo"];//OEM 客户料号
                string outCustNo = context.Request["outCustNo"];//出wistron客户料号
                string packingQty = context.Request["packingQty"];//装箱数量
                string description = context.Request["description"];//产品描述

                switch (method)
                {
                    case "getReferenceList"://获取参照表列表
                        result = refBiz.GetReferenceList();
                        break;
                    case "getReferenceById"://根据ID获取对应参照表信息
                        result = refBiz.GetReferenceById(id);
                        break;
                    case "delReferenceById"://根据ID删除对应参照表信息
                        result = refBiz.DelReferenceById(id);
                        break;
                    case "updateReferenceById"://更新对应参照表信息
                        #region Model赋值
                        reference updateModel = new reference();
                        updateModel.id = Convert.ToInt32(id);
                        updateModel.name = name;
                        updateModel.project = project;
                        updateModel.color = color;
                        updateModel.boxType = boxType;
                        updateModel.productVersion = productVersion;
                        updateModel.apn = apn;
                        updateModel.label = label;
                        updateModel.jdeNo = jdeNo;
                        updateModel.outJDENo = outJDENo;
                        updateModel.oemCustNo = oemCustNo;
                        updateModel.outCustNo = outCustNo;
                        updateModel.packingQty = packingQty;
                        updateModel.description = description;

                        updateModel.version = refVBiz.getKSRefVersion().id;
                        updateModel.factoryCode = KSFactoryCode;
                        updateModel.operatedBy = userBiz.getSessionUserName();;
                        updateModel.operatedTime = System.DateTime.Now;
                        #endregion
                        result = refBiz.UpdateReference(updateModel);
                        break;
                    case "selReferenceList"://查找参照表
                        #region Model 赋值
                        reference selModel = new reference();
                        selModel.id = Convert.ToInt32(id);
                        selModel.name = name;
                        selModel.project = project;
                        selModel.color = color;
                        selModel.boxType = boxType;
                        selModel.productVersion = productVersion;
                        selModel.apn = apn;
                        selModel.label = label;
                        selModel.jdeNo = jdeNo;
                        selModel.outJDENo = outJDENo;
                        selModel.oemCustNo = oemCustNo;
                        selModel.outCustNo = outCustNo;
                        selModel.packingQty = packingQty;
                        selModel.description = description;

                        selModel.version = refVBiz.getKSRefVersion().id;
                        selModel.factoryCode = KSFactoryCode;
                        selModel.operatedBy = userBiz.getSessionUserName();
                        selModel.operatedTime = System.DateTime.Now;
                        #endregion
                        result = refBiz.SelReferenceList(selModel);
                        break;
                    case "addReference":
                        #region Model 赋值
                        reference addModel = new reference();
                        //addModel.id = Convert.ToInt32(id);
                        addModel.name = name;
                        addModel.project = project;
                        addModel.color = color;
                        addModel.boxType = boxType;
                        addModel.productVersion = productVersion;
                        addModel.apn = apn;
                        addModel.label = label;
                        addModel.jdeNo = jdeNo;
                        addModel.outJDENo = outJDENo;
                        addModel.oemCustNo = oemCustNo;
                        addModel.outCustNo = outCustNo;
                        addModel.packingQty = packingQty;
                        addModel.description = description;

                        addModel.version = refVBiz.getKSRefVersion().id;
                        addModel.factoryCode = KSFactoryCode;
                        addModel.operatedBy = userBiz.getSessionUserName();
                        addModel.operatedTime = System.DateTime.Now;
                        #endregion
                        result = refBiz.AddReference(addModel);
                        break;
                }
            }
            catch (Exception ex)
            {
                result = "error";
                _ErrLog.WriteLog("referenceFacade 异常" + ex.Message);
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