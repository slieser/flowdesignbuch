using System;
using System.Threading;

namespace wecker.logik
{
    public class TimerProviderSimple {
        private Timer _timer;
        public event Action Tick;

        public TimerProviderSimple() {
            _timer = new Timer(state => TimerTick(), null, 1000, 1000);
        }

        private void TimerTick() {
            Tick?.Invoke();
        }
    }
}