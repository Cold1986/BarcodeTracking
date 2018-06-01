using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BarcodeTracking.BLL;

namespace BarcodeTracking.Biz
{
    public class RoleBiz
    {
        public List<BarcodeTracking.Model.jurisdiction> getUserRoleList(string ADAccount)
        {
            jurisdiction userRole = new jurisdiction();
            string strWhere = "adAccount='" + ADAccount + "'";
            return userRole.GetModelList(strWhere);
        }

        /// <summary>
        /// 根据不同权限调整不同页面
        /// </summary>
        /// <returns></returns>
        public string redirectPageByRole(string ADAccount)
        {
            string redirectPage = "ks/index.aspx";
            var userRole = getUserRole(ADAccount);
            if (userRole == BarcodeTracking.Enum.Roles.KS_PE)
            {
                redirectPage = "ks/reference.aspx";
            }
            if (userRole == BarcodeTracking.Enum.Roles.KS_Bindery)
            {
                redirectPage = "ks/QueryPallet.aspx";
            }
            else if (userRole == BarcodeTracking.Enum.Roles.KS_AE
                || userRole == BarcodeTracking.Enum.Roles.KS_WH
                || userRole == BarcodeTracking.Enum.Roles.IT
                || userRole == BarcodeTracking.Enum.Roles.KS_Bindery)
            {
                redirectPage = "ks/WHQueryPallet.aspx";
            }

            return redirectPage;
        }

        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="ADAccount"></param>
        /// <returns></returns>
        public BarcodeTracking.Enum.Roles getUserRole(string ADAccount)
        {
            List<BarcodeTracking.Model.jurisdiction> res = getUserRoleList(ADAccount);
            if (res != null)
            {
                //单一权限，有改进空间
                if (res.Where(u => u.name.Contains("IT")).ToList().Any()) return BarcodeTracking.Enum.Roles.IT;
                if (res.Where(u => u.name.Contains("KS_PE")).ToList().Any()) return BarcodeTracking.Enum.Roles.KS_PE;
                if (res.Where(u => u.name.Contains("KS_WH")).ToList().Any()) return BarcodeTracking.Enum.Roles.KS_WH;
                if (res.Where(u => u.name.Contains("KS_AE")).ToList().Any()) return BarcodeTracking.Enum.Roles.KS_AE;
                if (res.Where(u => u.name.Contains("KS_Bindery")).ToList().Any()) return BarcodeTracking.Enum.Roles.KS_Bindery;
            }
            return BarcodeTracking.Enum.Roles.Default;

        }
    }
}
