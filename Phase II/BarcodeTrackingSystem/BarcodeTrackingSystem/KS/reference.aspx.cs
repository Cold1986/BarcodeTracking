using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BarcodeTracking.Biz;

namespace BarcodeTracking.KS
{
    public partial class reference : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RoleBiz roleBiz = new RoleBiz();
            UserBiz userBiz = new UserBiz();
            string userName = userBiz.getSessionUserName();
            var userRole = roleBiz.getUserRole(userName);
            if (userRole != BarcodeTracking.Enum.Roles.KS_PE
                && userRole != BarcodeTracking.Enum.Roles.IT)
            {
                Response.Redirect("index.aspx");
            }
            
        }
    }
}