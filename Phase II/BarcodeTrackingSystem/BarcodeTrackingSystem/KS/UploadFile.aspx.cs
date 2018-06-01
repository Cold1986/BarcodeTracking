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
    public partial class UploadFile : System.Web.UI.Page
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

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string userName = userBiz.getSessionUserName();
            string type = this.ddlType.SelectedValue;
            if (fileUpload.HasFile)
            {
                try
                {
                    string postedFileName = fileUpload.PostedFile.FileName;
                    string postedFileExtension = System.IO.Path.GetExtension(postedFileName).ToLower();
                    if (postedFileExtension == ".xlsm" || postedFileExtension == ".xlsx" || postedFileExtension == ".xls")
                    {
                        string filePath = Server.MapPath("~/UploadFiles/KS/");
                        string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "_" + postedFileName;
                        fileUpload.SaveAs(filePath + fileName);
                        uploadFileBiz.Excel2DataTable(filePath, fileName, userName, type);
                        Response.Write("<script>alert('上传成功!')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('上传文件格式不正确!')</script>");
                    }
                }
                catch (Exception ex)
                {
                    _ErrLog.WriteLog("上传出货信息解析失败：" + ex.Message);
                    Response.Write("<script>alert('文件解析失败，请联系系统管理员!')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('请添加文件!')</script>");
            }
        }



    }
}