using System;
using System.Timers;

namespace wecker
{
    public class TimerProvider
    {
        private readonly Timer _timer;
        private readonly Action _handler;
        private Action _onTimer;
        private bool _isStarted;

        public TimerProvider(Action onTimer) {
            _handler = onTimer;
            _timer = new Timer(1000);
            _timer.Elapsed += (o, e) => {
                _handler?.Invoke();
                if (_isStarted) {
                    _onTimer?.Invoke();
                }
            };
            _timer.Start();
        }

        public void Start(Action onTimer) {
            _onTimer = onTimer;
            _isStarted = true;
        }

        public void Stop() {
            _isStarted = false;
        }
    }
}