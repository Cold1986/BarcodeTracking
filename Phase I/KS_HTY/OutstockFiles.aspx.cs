using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using CommonLib.Log;
using System.Data.OleDb;
using System.Data;

namespace KS_HTY
{
    public partial class OutstockFiles : System.Web.UI.Page
    {
        private static string connectionString = System.Configuration.ConfigurationSettings.AppSettings["MySqlConnectionString"];
        ExcelBiz excelBiz = new ExcelBiz();
        LogHelper _ErrLog = new LogHelper("ErrorLog");

        protected void Page_Load(object sender, EventArgs e)
        {

         

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (saveFiles())
            {

            }
        }

        private bool saveFiles()
        {
            bool uploadsuccess = true;


            string cfilename = this.fuload.FileName;//获取准备导入的文件名称

            if (cfilename == "")
            {

                uploadsuccess = false;
                return uploadsuccess;
            }
            string fileExtenSion;
            fileExtenSion = Path.GetExtension(fuload.FileName);
            if (fileExtenSion.ToLower() != ".xls" && fileExtenSion.ToLower() != ".xlsx")
            {

                uploadsuccess = false;
                return uploadsuccess;
            }


            try
            {
                string userName = "";
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    userName = HttpContext.Current.User.Identity.Name;
                }

                string uploadPath = Server.MapPath("\\files\\shipment\\");
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "_" + fuload.FileName;
                if (fuload != null)
                {
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    fuload.SaveAs(uploadPath + filename);

                    excelBiz.Excel2MySql(uploadPath, filename, userName, 0);
                    //异步执行excel 存mysql
                    new Thread(o =>
                    {

                    });
                }
            }
            catch (Exception ex)
            {


            }
            return true;
        }


    }
}