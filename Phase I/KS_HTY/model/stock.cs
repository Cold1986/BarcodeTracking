using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KS_HTY
{
    public class stock
    {
        public int id { get; set; }

        /// <summary>
        /// 箱唛标签
        /// </summary>
        public string CartonNo { get; set; }

        /// <summary>
        /// 卡板编号
        /// </summary>
        public string PalletNo { get; set; }

        /// <summary>
        /// JDE号
        /// </summary>
        public string JDENo { get; set; }

        /// <summary>
        /// 生产序列号
        /// </summary>
        public string ProductionNo { get; set; }

        /// <summary>
        /// 装箱数量
        /// </summary>
        public string Num { get; set; }

        public Double SumNum { get; set; }
        /// <summary>
        /// 上传用户
        /// </summary>
        public string upload_user { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime upload_date { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        public string uploaddate { get; set; }
    }
}