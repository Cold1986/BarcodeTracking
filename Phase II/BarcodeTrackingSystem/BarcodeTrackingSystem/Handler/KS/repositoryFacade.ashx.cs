using BarcodeTracking.Biz;
using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarcodeTracking.Handler.KS
{
    /// <summary>
    /// Summary description for repositoryFacade
    /// </summary>
    public class repositoryFacade : IHttpHandler
    {
        private string KSFactoryCode = System.Configuration.ConfigurationManager.AppSettings["KSFactoryCode"];
        LogHelper _ErrLog = new LogHelper("ErrorLog");

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            repositoryBiz myRepository = new repositoryBiz();
            string result = string.Empty;
            try
            {
                string method = context.Request["method"];
                string repositoryType = context.Request["repositoryType"];
                string repository = context.Request["repository"];
                string repositoryId = context.Request["repositoryId"];
                string description = context.Request["description"];


                switch (method)
                {
                    case "searchRepository"://获取参照表列表
                        result = myRepository.searchRepository(repositoryType, repository, description, KSFactoryCode);
                        break;
                    case "updateRepository":
                        result = myRepository.updateRepository(repositoryType, repository, description, KSFactoryCode, repositoryId);
                        break;

                }
            }
            catch (Exception ex)
            {
                result = "error";
                _ErrLog.WriteLog("repositoryFacade 异常" + ex.Message);
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