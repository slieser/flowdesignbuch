using System;
using wecker.logik;

namespace wecker.app
{
    public class Interactors
    {
        private TimerProvider _timer;
        private readonly Synchronizer _sync = new Synchronizer();

        public void Start(Action<bool, bool> onZustand, Action<DateTime> onTimer) {
            onZustand(true, false);

            _timer = new TimerProvider();
            _timer.Tick += () => {
                var uhrzeit = UhrzeitProvider.Aktuelle_Uhrzeit();
                _sync.Process(() => {
                    onTimer(uhrzeit);
                });
            };
        }

        public void Start_mit_Weckzeit(DateTime weckzeit, Action<bool, bool> onZustand, Action<TimeSpan> onRestzeit) {
            onZustand(false, true);

            _timer.Start(() => {
                var uhrzeit = UhrzeitProvider.Aktuelle_Uhrzeit();
                var restzeit = Restzeit_berechnen(uhrzeit, weckzeit);
                _sync.Process(() => onRestzeit(restzeit));

                Wenn_Restzeit_abgelaufen(restzeit, () => {
                    _timer.Stopp();
                    var media_Player = new Media_Player();
                    media_Player.Alarm_abspielen();
                    _sync.Process(() => onZustand(true, false));
                });
            });
        }

        public void Start_mit_Restzeit(TimeSpan restzeit, Action<bool, bool> onZustand, Action<TimeSpan> onRestzeit) {
            var uhrzeit = UhrzeitProvider.Aktuelle_Uhrzeit();
            var weckzeit = uhrzeit + restzeit;
            Start_mit_Weckzeit(weckzeit, onZustand, onRestzeit);
        }

        private TimeSpan Restzeit_berechnen(DateTime uhrzeit, DateTime weckzeit) {
            return weckzeit - uhrzeit;
        }

        private void Wenn_Restzeit_abgelaufen(TimeSpan restzeit, Action continueWith) {
            if (restzeit <= new TimeSpan()) {
                continueWith();
            }
        }

        public void Stopp(Action<bool, bool> onZustand) {
            _timer.Stopp();
            onZustand(true, false);
        }
    }
}