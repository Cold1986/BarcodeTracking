using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarcodeTracking.Biz
{
    public interface ISubject
    {
        void Notify(int id);//主题变动时，通知虽有观察者
        //void Regiester(IObservable o);//观察者注册
        //void UnRegiester(IObservable o);//观察者取消注册，此时主题发生任何变动，观察者都不会得到通知
    }
}
