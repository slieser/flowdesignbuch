using System;
using System.Threading;

namespace wecker.logik
{
    public class TimerProvider
    {
        private Timer _timer;
        private bool _started;
        private event Action _stoppableTick;

        public event Action Tick;

        public TimerProvider() {
            _timer = new Timer(state => TimerTick(), null, 1000, 1000);
        }

        private void TimerTick() {
            Tick?.Invoke();
            if (_started) {
                _stoppableTick?.Invoke();
            }
        }

        public void Start(Action onTick) {
            _stoppableTick = onTick;
            _started = true;
        }

        public void Stopp() {
            _stoppableTick = null;
            _started = false;
        }
    }
}