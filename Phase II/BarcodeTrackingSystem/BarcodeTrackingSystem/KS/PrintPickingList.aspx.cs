using BarcodeTracking.Biz;
using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarcodeTracking.KS
{
    public partial class PrintPickingList : System.Web.UI.Page
    {
        UserBiz userBiz = new UserBiz();
        LogHelper _ErrLog = new LogHelper("ErrorLog");
        protected void Page_Load(object sender, EventArgs e)
        {
            RoleBiz roleBiz = new RoleBiz();
            string userName = userBiz.getSessionUserName();
            var userRole = roleBiz.getUserRole(userName);
            if (userRole != BarcodeTracking.Enum.Roles.KS_WH
                && userRole != BarcodeTracking.Enum.Roles.KS_AE
                && userRole != BarcodeTracking.Enum.Roles.IT
                && userRole != BarcodeTracking.Enum.Roles.KS_Bindery)
            {
                Response.Redirect("index.aspx");
            }
        }
    }
}