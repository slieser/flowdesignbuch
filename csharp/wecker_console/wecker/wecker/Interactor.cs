using System;
using System.Timers;

namespace wecker
{
    public class Interactor
    {
        private TimerProvider _timerProvider;

        public void Start_mit_Weckzeit(DateTime weckzeit, Action<TimeSpan> onRestzeit) {
            _timerProvider.Start(() => {
                var uhrzeit = UhrzeitProvider.Uhrzeit_lesen();
                var restzeit = Wecker.Restzeit_berechnen(uhrzeit, weckzeit);
                if (Wecker.Restzeit_ist_abgelaufen(restzeit)) {
                    _timerProvider.Stop();
                }
                else {
                    onRestzeit(restzeit);
                }
            });
        }

        public void Start(Action<DateTime> onUhrzeit) {
            _timerProvider = new TimerProvider(() => {
                var uhrzeit = UhrzeitProvider.Uhrzeit_lesen();
                onUhrzeit(uhrzeit);
            });
        }
    }

    public static class Wecker
    {
        public static TimeSpan Restzeit_berechnen(in DateTime uhrzeit, in DateTime weckzeit) {
            return weckzeit - uhrzeit;
        }

        public static bool Restzeit_ist_abgelaufen(TimeSpan restzeit) {
            return restzeit <= new TimeSpan();
        }
    }

    public static class UhrzeitProvider
    {
        public static DateTime Uhrzeit_lesen() {
            return DateTime.Now;
        }
    }

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