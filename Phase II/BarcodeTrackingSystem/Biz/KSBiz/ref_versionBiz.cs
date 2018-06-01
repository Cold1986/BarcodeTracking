using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BarcodeTracking.Model;
using Maticsoft.Common;

namespace BarcodeTracking.Biz
{
    public class ref_versionBiz : IObservable
    {
        /// <summary>
        /// 昆山工厂ID
        /// </summary>
        private string KSFactoryCode = System.Configuration.ConfigurationManager.AppSettings["KSFactoryCode"];
        private LogHelper _ErrLog = new LogHelper("ErrorLog");
        private LogHelper _KSReferenceLog = new LogHelper("KSReferenceLog");
        private BarcodeTracking.BLL.ref_version refV;
        private UserBiz userBiz;

        public ref_versionBiz()
        {
            refV = new BarcodeTracking.BLL.ref_version();
            userBiz = new UserBiz();
        }

        /// <summary>
        /// 获取昆山版本号信息
        /// </summary>
        /// <returns></returns>
        public ref_version getKSRefVersion()
        {
            var res = refV.GetModelList("").Where(u => u.factoryCode.Contains(KSFactoryCode)).First();
            return res;
        }

        /// <summary>
        /// 更新版本号
        /// </summary>
        /// <param name="id"></param>
        private void updateRefVersion(int id)
        {
            //var dnow = System.DateTime.Now;
            //string userName = userBiz.getSessionUserName();
            //ref_version refVmodel = new ref_version();
            //refVmodel.id = id;
            //refVmodel.factoryCode = KSFactoryCode;
            //refVmodel.version = dnow.Year.ToString() + dnow.Month.ToString().PadLeft(2, '0') + dnow.Day.ToString().PadLeft(2, '0') + dnow.Hour.ToString().PadLeft(2, '0') + dnow.Minute.ToString().PadLeft(2, '0');
            //refV.Update(refVmodel);
            //_KSReferenceLog.WriteLog("用户 " + userName + " 修改参照表版本。更新为：" + refVmodel.version);
        }

        public void ChangeBiz(int id)
        {
            this.updateRefVersion(id);
        }
    }
}
