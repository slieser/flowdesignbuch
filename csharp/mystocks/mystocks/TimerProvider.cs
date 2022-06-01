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
            _timer = new Timer(_ => {
                if (_synchronizationContext != null) {
                    _synchronizationContext.Send(_ => action(), null);
                }
                else {
                    action();
                }
            }, null, 0, interval);
        }
    }
}