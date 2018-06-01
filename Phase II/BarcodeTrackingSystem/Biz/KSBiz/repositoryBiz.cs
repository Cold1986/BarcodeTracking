using BarcodeTracking.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace BarcodeTracking.Biz
{
    public class repositoryBiz
    {
        RepositoryInfo rInfo = new RepositoryInfo();
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        UserBiz userBiz = new UserBiz();
        public string searchRepository(string repositoryType, string repository, string description, string KSFactoryCode)
        {   
            List<BarcodeTracking.Model.RepositoryInfo> res = rInfo.GetModelList("factoryCode =" + KSFactoryCode);
            res = res.Where(x => x.status.Equals(repositoryType)).ToList();
            if (!string.IsNullOrEmpty(repository))
            {
                res = res.Where(u => u.repositoryNo.ToLower().Equals(repository.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(description))
            {
                res = res.Where(u => u.description.ToLower().Contains(description.ToLower())).ToList();
            }
            res.ForEach(u => u.status = u.status == "1" ? "正常" : "禁用");

            return serializer.Serialize(res);
        }

        public string updateRepository(string repositoryType, string repository, string description, string KSFactoryCode, string repositoryId)
        {
            string res = "fail";
            try
            {
                BarcodeTracking.Model.RepositoryInfo myInfo = new Model.RepositoryInfo();
                myInfo.id =Convert.ToInt32(repositoryId);
                myInfo.repositoryNo = repository;
                myInfo.description = description;
                myInfo.lastUpdatedTime = DateTime.Now;
                myInfo.lastUpdatedBy = userBiz.getSessionUserName();
                myInfo.status = repositoryType;
                rInfo.Update(myInfo);

                res = "success";
            }
            catch(Exception e)
            {
                throw e;
            }
            return serializer.Serialize(res);
        }
    }
}
