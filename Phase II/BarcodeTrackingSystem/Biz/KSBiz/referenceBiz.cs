using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maticsoft.Common;
using BarcodeTracking.Model;
using BarcodeTracking.Biz;
using System.Web.Script.Serialization;
using BarcodeTracking.Entity;

namespace BarcodeTracking.Biz
{
    public class referenceBiz : ISubject
    {
        /// <summary>
        /// 昆山工厂ID
        /// </summary>
        public string KSFactoryCode = System.Configuration.ConfigurationManager.AppSettings["KSFactoryCode"];
        LogHelper _ErrLog = new LogHelper("ErrorLog");
        LogHelper _KSReferenceLog = new LogHelper("KSReferenceLog");
        BarcodeTracking.BLL.reference refer;
        UserBiz userBiz;
        JavaScriptSerializer serializer;
        private IList<IObservable> observers = new List<IObservable>();

        public referenceBiz()
        {
            serializer = new JavaScriptSerializer();
            refer = new BarcodeTracking.BLL.reference();
            userBiz = new UserBiz();
            observers.Clear();
            observers.Add(new ref_versionBiz());

        }

        /// <summary>
        /// 获取参照表清单
        /// </summary>
        /// <returns></returns>
        public List<reference> GetModelList(string strWhere = "")
        {
            return refer.GetModelList(strWhere);
        }
        /// <summary>
        /// 获取参照表清单
        /// </summary>
        /// <returns></returns>
        public string GetReferenceList(string strWhere = "")
        {
            try
            {
                var res = GetModelList(strWhere);
                return serializer.Serialize(res);
            }
            catch (Exception ex)
            {
                _ErrLog.WriteLog("referenceBiz下GetReferenceList程序异常：" + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 根据id获取参照表信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetReferenceById(string id)
        {
            try
            {
                var res = getReferenceById(id);
                return serializer.Serialize(res);
            }
            catch (Exception ex)
            {
                _ErrLog.WriteLog("referenceBiz下GetReferenceById程序异常：" + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 根据id删除参照表信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DelReferenceById(string id)
        {
            try
            {
                int intId;
                int.TryParse(id, out intId);

                reference model = getReferenceById(id);
                if (model != null)
                {
                    #region 日志记录用户删除数据
                    string userName = userBiz.getSessionUserName();
                    string idInfo = serializer.Serialize(model);
                    _KSReferenceLog.WriteLog("用户 " + userName + " 删除" + idInfo);
                    #endregion
                    #region 删除对应记录
                    var res = refer.Delete(intId);
                    Notify(model.version);
                    //refVBiz.updateRefVersion(model.version);//更新版本号
                    #endregion
                    return res ? "success" : "fail";
                }
                else
                {
                    return "fail";
                }
            }
            catch (Exception ex)
            {
                _ErrLog.WriteLog("referenceBiz下DelReferenceById程序异常：" + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 更新参照表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string UpdateReference(reference model)
        {
            try
            {
                #region 日志记录用户更新前数据
                string userName = userBiz.getSessionUserName();
                string idInfo = GetReferenceById(model.id.ToString());
                _KSReferenceLog.WriteLog("用户 " + userName + " 修改参照表。更新前：" + idInfo);
                #endregion
                #region 更新对应记录
                var res = refer.Update(model);
                Notify(model.version);
                //refVBiz.updateRefVersion(model.version);
                #endregion
                #region 日志记录用户更新后数据
                idInfo = GetReferenceById(model.id.ToString());
                _KSReferenceLog.WriteLog("用户 " + userName + " 修改参照表。更新后：" + idInfo);
                #endregion
                return res ? "success" : "fail";
            }
            catch (Exception ex)
            {
                _ErrLog.WriteLog("referenceBiz下UpdateReference程序异常：" + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 根据条件查询参照表
        /// </summary>
        /// <param name="model"></param>
        public string SelReferenceList(reference model)
        {
            try
            {
                var res = GetModelList();
                if (res != null)
                {
                    if (res != null && !string.IsNullOrEmpty(model.name)) res = res.Where(u => u.name.Contains(model.name)).ToList();
                    if (res != null && !string.IsNullOrEmpty(model.project)) res = res.Where(u => u.project.Contains(model.project)).ToList();
                    if (res != null && !string.IsNullOrEmpty(model.color)) res = res.Where(u => u.color.Contains(model.color)).ToList();
                    if (res != null && !string.IsNullOrEmpty(model.boxType)) res = res.Where(u => u.boxType.Contains(model.boxType)).ToList();
                    if (res != null && !string.IsNullOrEmpty(model.productVersion)) res = res.Where(u => u.productVersion.Contains(model.productVersion)).ToList();
                    if (res != null && !string.IsNullOrEmpty(model.apn)) res = res.Where(u => u.apn.Contains(model.apn)).ToList();
                    if (res != null && !string.IsNullOrEmpty(model.label)) res = res.Where(u => u.label.Contains(model.label)).ToList();
                    if (res != null && !string.IsNullOrEmpty(model.jdeNo)) res = res.Where(u => u.jdeNo.Contains(model.jdeNo)).ToList();
                    if (res != null && !string.IsNullOrEmpty(model.outJDENo)) res = res.Where(u => u.outJDENo.Contains(model.outJDENo)).ToList();
                    if (res != null && !string.IsNullOrEmpty(model.oemCustNo)) res = res.Where(u => u.oemCustNo.Contains(model.oemCustNo)).ToList();
                    if (res != null && !string.IsNullOrEmpty(model.outCustNo)) res = res.Where(u => u.outCustNo.Contains(model.outCustNo)).ToList();
                    if (res != null && !string.IsNullOrEmpty(model.packingQty)) res = res.Where(u => u.packingQty.Contains(model.packingQty)).ToList();
                    if (res != null && !string.IsNullOrEmpty(model.description)) res = res.Where(u => u.description.Contains(model.description)).ToList();
                }
                return serializer.Serialize(res);
            }
            catch (Exception ex)
            {
                _ErrLog.WriteLog("referenceBiz下SelReferenceList程序异常：" + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 添加参照表信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string AddReference(reference model)
        {
            try
            {
                #region 更新对应记录
                int res = refer.Add(model);
                Notify(model.version);
                //refVBiz.updateRefVersion(model.version);
                #endregion
                #region 日志记录用户添加后数据
                string userName = userBiz.getSessionUserName();
                string idInfo = GetReferenceById(res.ToString());
                _KSReferenceLog.WriteLog("用户 " + userName + " 修改参照表。更新后：" + idInfo);
                #endregion
                return res != 0 ? "success" : "fail";
            }
            catch (Exception ex)
            {
                _ErrLog.WriteLog("referenceBiz下AddReference程序异常：" + ex.Message);
                throw ex;
            }
        }


        /// <summary>
        /// 根据id获取参照表信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private reference getReferenceById(string id)
        {
            int intId;
            int.TryParse(id, out intId);
            var res = refer.GetModel(intId);
            return res;
        }

        public void Notify(int id)
        {
            foreach (IObservable o in observers)//逐个通知观察者
            {
                o.ChangeBiz(id);
            }
        }

        //private void Regiester(IObservable o)
        //{
        //    if (o != null || !observers.Contains(o))
        //    {
        //        observers.Add(o);
        //    }
        //}

        //private void UnRegiester(IObservable o)
        //{
        //    if (o != null || !observers.Contains(o))
        //    {
        //        observers.Remove(o);
        //    }
        //}
    }
}
