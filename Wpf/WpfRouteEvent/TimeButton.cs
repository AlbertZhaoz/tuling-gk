using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfRouteEvent
{
    public class TimeButton:Button
    {
        // 写自定义路由事件

        public event RoutedEventHandler MyEvent
        {
            add { AddHandler(MyEventEvent, value); }
            remove { RemoveHandler(MyEventEvent, value); }
        }

        public static readonly RoutedEvent MyEventEvent = EventManager.RegisterRoutedEvent(
        "MyEvent", RoutingStrategy.Bubble, typeof(EventHandler<ReportTimeEventArgs>), typeof(TimeButton));

        protected override void OnClick()
        {
            base.OnClick();

            // 准备好路由事件的传递参数
            var args = new ReportTimeEventArgs(MyEventEvent,this);
            args.ClickTime = DateTime.Now;

            // 发起路由事件
            this.RaiseEvent(args);
        }
    }

    public class ReportTimeEventArgs : RoutedEventArgs
    {
        public ReportTimeEventArgs(RoutedEvent e,object source):base(e,source) 
        {
            
        }

        public DateTime ClickTime{get;set;}
    }
}
