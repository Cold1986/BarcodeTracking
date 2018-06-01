using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarcodeTracking.Entity
{
    public class AccountInfo
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string userName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// 登录日期
        /// </summary>
        public DateTime loginDate { get; set; }

        /// <summary>
        /// 加密判断
        /// </summary>
        public string token { get; set; }
    }
}
