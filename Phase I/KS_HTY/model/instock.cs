using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KS_HTY
{
    /// <summary>
    /// 生产入库
    /// </summary>
    public class instock : stock
    {
        /// <summary>
        /// 工单号
        /// </summary>
        public string JobNo { get; set; }

    }
}