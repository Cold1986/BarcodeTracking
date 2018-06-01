using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BarcodeTracking.Biz;

namespace BarcodeTracking.KS
{
    public partial class KSMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RoleBiz roleBiz = new RoleBiz();
            UserBiz userBiz = new UserBiz();
            string userName = userBiz.getSessionUserName();
            var userRole = roleBiz.getUserRole(userName);
            ShowMenuBar(userRole);
        }


        private void ShowMenuBar(BarcodeTracking.Enum.Roles userRole)
        {
            //参照表页面控制
            if (userRole == BarcodeTracking.Enum.Roles.KS_PE
               || userRole == BarcodeTracking.Enum.Roles.IT)
            {
                this.icon_reference.Visible = true;
            }

            //生产组卡板号查询页面
            if (userRole == BarcodeTracking.Enum.Roles.KS_AE
                || userRole == BarcodeTracking.Enum.Roles.KS_Bindery
                || userRole == BarcodeTracking.Enum.Roles.IT)
            {
                this.icon_queryPallet.Visible = true;
            }

            //库位管理页面
            //上传文件
            if (userRole == BarcodeTracking.Enum.Roles.KS_WH
                || userRole == BarcodeTracking.Enum.Roles.IT)
            {
                this.icon_manageRepository.Visible = true;
                this.icon_uploadFile.Visible = true;
                this.icon_printPickingList.Visible = true;
            }

            //出入库查询页面
            if (userRole == BarcodeTracking.Enum.Roles.KS_AE
                || userRole == BarcodeTracking.Enum.Roles.KS_WH
                || userRole == BarcodeTracking.Enum.Roles.IT)
            {
                this.icon_queryPalletByWH.Visible = true;
            }

            //昆山小料入页面
            //昆山小料出页面
            if (userRole == BarcodeTracking.Enum.Roles.KS_Bindery
                || userRole == BarcodeTracking.Enum.Roles.IT)
            {
                this.icon_upload_ks_condiments_in.Visible = true;
                this.icon_upload_ks_condiments_out.Visible = true;
            }
        }
    }
}