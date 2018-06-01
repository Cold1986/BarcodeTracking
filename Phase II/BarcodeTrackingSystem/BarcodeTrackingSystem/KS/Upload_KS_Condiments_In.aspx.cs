using BarcodeTracking.Biz;
using BarcodeTracking.BLL;
using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Data;

namespace BarcodeTracking.KS
{
    public partial class Upload_KS_Condiments_In : System.Web.UI.Page
    {
        UserBiz userBiz = new UserBiz();
        LogHelper _ErrLog = new LogHelper("ErrorLog");
        protected void Page_Load(object sender, EventArgs e)
        {
            RoleBiz roleBiz = new RoleBiz();
            string userName = userBiz.getSessionUserName();
            var userRole = roleBiz.getUserRole(userName);
            if (userRole != BarcodeTracking.Enum.Roles.IT
                && userRole != BarcodeTracking.Enum.Roles.KS_Bindery)
            {
                Response.Redirect("index.aspx");
            }

            if (!IsPostBack)
            {
                this.ddlBind();
            }
        }

        private void ddlBind()
        {
            sys_ddlData ddlBiz = new sys_ddlData();

            this.ddlType.DataSource = ddlBiz.GetList(" type=1 order by sort");
            ddlType.DataTextField = "showValue";    //控件显示的字段
            ddlType.DataValueField = "showKey";     //控件绑定值
            ddlType.DataBind();                   //进行绑定
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string userName = userBiz.getSessionUserName();//获取操作员信息
            string type = this.ddlType.SelectedValue;

            if (fileUpload.HasFile)
            {
                try
                {
                    KS_Condiments_Reference referenceBiz = new KS_Condiments_Reference();
                    KGM_HISTORYBODY kgmHistoryBiz = new KGM_HISTORYBODY();
                    Dictionary<string, int> dct = new Dictionary<string, int>();

                    string postedFileName = fileUpload.PostedFile.FileName;
                    string postedFileExtension = System.IO.Path.GetExtension(postedFileName).ToLower();
                    if (postedFileExtension == ".csv" || postedFileExtension == ".txt")
                    {
                        //读取参照表信息转换为字典
                        DataSet dsReference = referenceBiz.GetAllList();
                        if (dsReference != null && dsReference.Tables.Count > 0)
                        {
                            DataTable dtReference = dsReference.Tables[0];
                            if (dtReference != null && dtReference.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtReference.Rows.Count; i++)
                                {
                                    dct.Add(dtReference.Rows[i]["jdeNo"].ToString(), Convert.ToInt32(dtReference.Rows[i]["packingQty"]));
                                }
                            }
                        }

                        //读取用户上传文件
                        DataTable dt = uploadFileBiz.GetdataFromCVS(fileUpload, userName, type);

                        bool result = true;// 验证是否所有数据都符合要求； 上传时判断数量是否小于配置表数量，正常情况等于，尾箱小于。大于出错
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            string errMsg = string.Empty;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                int userNumbers = Convert.ToInt32(dt.Rows[i]["QTY"]);//用户上传文件里的数字
                                int sysNumbers = 0;
                                if (dct.ContainsKey(dt.Rows[i]["CDEFINE25"].ToString()))
                                {
                                    sysNumbers = dct[dt.Rows[i]["CDEFINE25"].ToString()];//数据库里存的数字
                                }

                                if (userNumbers > sysNumbers)//数字大于系统配置数直接错
                                {
                                    result = false;
                                    errMsg += (i + 1).ToString() + "、";
                                }
                                else
                                {
                                    //判断是否已经上传过
                                    var tmpResult = kgmHistoryBiz.GetList("BARCODE = '" + dt.Rows[i]["BARCODE"].ToString() + "'");
                                    if ((tmpResult != null) 
                                        && tmpResult.Tables.Count != 0 
                                        && tmpResult.Tables[0].Rows.Count !=0)
                                    {
                                        result = false;
                                        errMsg += (i + 1).ToString() + "、";
                                    } 
                                }
                            }

                            //说明数据都正常可以保存进数据库
                            if (result)
                            {
                                //保存用户文件
                                string filePath = Server.MapPath("~/UploadFiles/KS_Condiments/");
                                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "_in_" + userName + "_" + postedFileName;
                                fileUpload.SaveAs(filePath + fileName);
                                //插入数据库
                                uploadFileBiz.CondimentsDataTableToSQLServer(dt);
                                Response.Write("<script>alert('上传成功!')</script>");
                            }
                            else
                            {
                                errMsg = errMsg.Substring(0, errMsg.Length - 1);//去掉最后一个、符号
                                Response.Write("<script>alert('上传失败!请检查行" + errMsg + "数据')</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('上传文件是空文件或不符合格式要求!')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('上传文件格式不正确!')</script>");
                    }
                }
                catch (Exception ex)
                {
                    _ErrLog.WriteLog("上传小料接收记录解析失败：" + ex.Message);
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