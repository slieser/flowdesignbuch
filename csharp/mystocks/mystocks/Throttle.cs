using System;
using System.Threading;

namespace mystocks
{
    public class Throttle
    {
        private readonly SynchronizationContext _synchronizationContext;
        private Timer _timer;
        
        public Throttle() {
            _synchronizationContext = SynchronizationContext.Current;
        }

        public void ExecuteThrottled(int interval, Action action) {
            void StopTimer() {
                _timer.Change(Timeout.Infinite, Timeout.Infinite);
                _timer.Dispose();
                _timer = null;
            }

            if (_timer != null) {
                StopTimer();
            }
            
            _timer = new Timer(o => {
                StopTimer();
                _synchronizationContext.Send(x => action(), null);
            }, null, interval, interval);
        }
    }
}