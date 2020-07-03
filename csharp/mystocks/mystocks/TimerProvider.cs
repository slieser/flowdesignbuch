using System;
using System.Threading;

namespace mystocks
{
    public class TimerProvider
    {
        private readonly SynchronizationContext _synchronizationContext;
        private Timer _timer;

        public TimerProvider() {
            _synchronizationContext = SynchronizationContext.Current;
        }
        
        public void ExecutePeriodic(int interval, Action action) {
            _timer = new Timer(o => {
                _synchronizationContext.Send(x => action(), null);
            }, null, 0, interval);
        }
    }
}