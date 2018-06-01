using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Threading.Tasks;

namespace KS_HTY
{
    public partial class uploadfiles : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string cfilename = this.fuload.FileName;//获取准备导入的文件名称

            if (cfilename == "")
            {
                lblMsg.Text = "请选择文件";
                lblMsg.Visible = true;
                return;
            }
            string fileExtenSion;
            fileExtenSion = Path.GetExtension(fuload.FileName);
            if (fileExtenSion.ToLower() != ".xls" && fileExtenSion.ToLower() != ".xlsx")
            {
                lblMsg.Text = "上传的文件格式不正确";
                return;
            }
            KSServiceReference1.WebService1SoapClient service = new AsyncWebService KSServiceReference1.WebService1SoapClient();
            ksService.BeginHelloword1();

           

            //webservice.HelloWorld();
            //IAsyncResult ar = webservice.HelloWorld(s => { }, null);
            //Response.Write(string.Format("调用结束时间：{0}<Br>", DateTime.Now.ToString("mm:ss.ffff")));
            //ar.AsyncWaitHandle.WaitOne();
            //string result = localService.EndHelloWorld1(ar);
            //Response.Write(string.Format("完成时间：{0}。 结果{1}<Br>", DateTime.Now.ToString("mm:ss.ffff"), result));

        }

        public Task<long> DoSomethingAsync(int n)
        {
            return TaskEx.Run<long>(() => DoSomething(n));
        }
 
    }
}