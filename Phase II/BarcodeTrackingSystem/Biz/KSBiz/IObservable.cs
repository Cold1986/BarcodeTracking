using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarcodeTracking.Biz
{
    public interface IObservable
    {
        void ChangeBiz(int id);//观察者对主题变动所对应的操作
    }
}
