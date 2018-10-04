using System;
using wecker.logik;

namespace wecker.app
{
    public class Interactors
    {
        private TimerProvider _timer;
        private readonly Synchronizer _sync = new Synchronizer();

        public void Start(Action<bool, bool> onZustand, Action<DateTime> onTimer) {
            var (startbar, stoppbar) = Wecker.Wecker_gestoppt();
            onZustand(startbar, stoppbar);

            _timer = new TimerProvider();
            _timer.Tick += () => {
                var uhrzeit = UhrzeitProvider.Aktuelle_Uhrzeit();
                _sync.Process(() => {
                    onTimer(uhrzeit);
                });
            };
        }

        public void Start_mit_Weckzeit(DateTime weckzeit, Action<bool, bool> onZustand, Action<TimeSpan> onRestzeit) {
            var (startbar, stoppbar) = Wecker.Wecker_gestartet();
            onZustand(startbar, stoppbar);

            _timer.Start(() => {
                var uhrzeit = UhrzeitProvider.Aktuelle_Uhrzeit();
                var restzeit = Wecker.Restzeit_berechnen(uhrzeit, weckzeit);
                _sync.Process(() => onRestzeit(restzeit));

                Wecker.Wenn_Restzeit_abgelaufen(restzeit, () => {
                    _timer.Stopp();
                    Media_Player.Alarm_abspielen();
                    _sync.Process(() => {
                        (startbar, stoppbar) = Wecker.Wecker_gestoppt();
                        onZustand(startbar, stoppbar);
                    });
                });
            });
        }

        public void Start_mit_Restzeit(TimeSpan restzeit, Action<bool, bool> onZustand, Action<TimeSpan> onRestzeit) {
            var uhrzeit = UhrzeitProvider.Aktuelle_Uhrzeit();
            var weckzeit = Wecker.Weckzeit_berechnen(restzeit, uhrzeit);
            Start_mit_Weckzeit(weckzeit, onZustand, onRestzeit);
        }

        public void Stopp(Action<bool, bool> onZustand) {
            _timer.Stopp();
            var (startbar, stoppbar) = Wecker.Wecker_gestoppt();
            onZustand(startbar, stoppbar);
        }
    }
}