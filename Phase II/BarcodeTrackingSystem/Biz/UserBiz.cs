using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BarcodeTracking.Entity;
using Maticsoft.Common;


namespace BarcodeTracking.Biz
{
    public class UserBiz
    {
        private AccountInfo getSessionUser()
        {
            return (AccountInfo)SessionHelper.Get("userAccount");
        }

        public string getSessionUserName()
        {
            string userName = string.Empty;
            var res = (AccountInfo)SessionHelper.Get("userAccount");
            if (res != null)
            {
                userName = res.userName;
            }
            return userName;
        }

       
    }
}
