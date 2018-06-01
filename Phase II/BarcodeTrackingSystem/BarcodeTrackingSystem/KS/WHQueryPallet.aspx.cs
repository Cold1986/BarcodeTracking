using BarcodeTracking.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarcodeTracking.KS
{
    public partial class WHQueryPallet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RoleBiz roleBiz = new RoleBiz();
            UserBiz userBiz = new UserBiz();
            string userName = userBiz.getSessionUserName();
            var userRole = roleBiz.getUserRole(userName);
            if (userRole != BarcodeTracking.Enum.Roles.KS_AE
                && userRole != BarcodeTracking.Enum.Roles.IT
                && userRole != BarcodeTracking.Enum.Roles.KS_WH)
            {
                Response.Redirect("index.aspx");
            }
        }
    }
}