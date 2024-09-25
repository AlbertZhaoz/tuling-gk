using DotNetify.Pulse;
using System;
using System.Reactive.Linq;

namespace VOL.WebApi.DotNetify
{
    public class DbMonitorProvider : IPulseDataProvider
    {
        public IDisposable Configure(PulseVM pulseVM, out OnPushUpdate onPushUpdate)
        {
            var clockProperty = pulseVM.AddProperty<string>("Clock", DateTime.Now.ToString("hh:mm:ss"));

            onPushUpdate = _ => { };  // No op.

            return Observable
               .Interval(TimeSpan.FromSeconds(1))
               .Subscribe(_ => clockProperty.OnNext(DateTime.Now.ToString("hh:mm:ss")));
        }
    }
}
