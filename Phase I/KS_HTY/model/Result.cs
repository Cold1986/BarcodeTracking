using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KS_HTY
{
    public class Result<T>
    {
        public string res { get; set; }

        public List<T> mes { get; set; }
    }
}