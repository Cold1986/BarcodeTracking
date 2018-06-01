using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BarcodeTracking.Biz;
using BarcodeTracking.Entity;
using Maticsoft.Common;
using System.Web.Security;

namespace BarcodeTracking
{
    public partial class login : System.Web.UI.Page
    {
        private static string cookieKey = System.Configuration.ConfigurationManager.AppSettings["cookieKey"];
        bool IsPageRefresh = false; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();
                Session["SessionId"] = ViewState["ViewStateId"].ToString();
            }
            else
            {
                if (ViewState["ViewStateId"].ToString() != Session["SessionId"].ToString())
                {
                    IsPageRefresh = true;
                }
                Session["SessionId"] = System.Guid.NewGuid().ToString();
                ViewState["ViewStateId"] = Session["SessionId"].ToString();
            }       
            //string t = System.DateTime.Now.GetHashCode().ToString();
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            if (!IsPageRefresh)
            {
                string user = this.userName.Value.Trim();
                string psd = this.password.Value.Trim();
                ADBiz adBiz = new ADBiz();
                if (!adBiz.Authenticate(user, psd))//账号密码不正确
                {
                    lblMsg.InnerText = "用户或密码不正确！";
                }
                else//登录成功
                {
                    lblMsg.InnerText = string.Empty;
                    DateTime now = System.DateTime.Now;
                    AccountInfo account = new AccountInfo
                    {
                        userName = user,
                        password = psd,
                        loginDate = now,
                        token = FormsAuthentication.HashPasswordForStoringInConfigFile(user + psd + now.ToShortDateString() + cookieKey, "MD5").ToLower()//预留，万一需要扩展到cookie
                    };
                    SessionHelper.Set("userAccount", account, 4 * 60);//4小时过期

                    RoleBiz roleBiz = new RoleBiz();
                    var redirectPage = roleBiz.redirectPageByRole(account.userName);
                    Response.Redirect(redirectPage);
                }
            }
        }
    }
}