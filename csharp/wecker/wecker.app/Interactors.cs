using System;
using wecker.logik;

namespace wecker.app
{
    public class Interactors
    {
        private TimerProvider _timer;
        private readonly Synchronizer _sync = new Synchronizer();

        public void Start(Action<bool> onZustand, Action<DateTime> onTimer) {
            var istGestartet = Wecker.Wecker_gestoppt();
            onZustand(istGestartet);

            _timer = new TimerProvider();
            _timer.Tick += () => {
                var uhrzeit = UhrzeitProvider.Aktuelle_Uhrzeit();
                _sync.Process(() => onTimer(uhrzeit));
            };
        }

        public void Start_mit_Weckzeit(
                DateTime weckzeit, 
                Action<bool> onZustand, 
                Action<TimeSpan> onRestzeit) {
            var istGestartet = Wecker.Wecker_gestartet();
            onZustand(istGestartet);

            _timer.Start(() => {
                var uhrzeit = UhrzeitProvider.Aktuelle_Uhrzeit();
                var restzeit = Wecker.Restzeit_berechnen(uhrzeit, weckzeit);
                _sync.Process(() => onRestzeit(restzeit));

                Wecker.Wenn_Restzeit_abgelaufen(restzeit, () => {
                    _timer.Stopp();
                    Media_Player.Alarm_abspielen();
                    _sync.Process(() => {
                        istGestartet = Wecker.Wecker_gestoppt();
                        onZustand(istGestartet);
                    });
                });
            });
        }

        public void Start_mit_Dauer(TimeSpan dauer, Action<bool> onZustand, Action<TimeSpan> onRestzeit) {
            var uhrzeit = UhrzeitProvider.Aktuelle_Uhrzeit();
            var weckzeit = Wecker.Weckzeit_berechnen(dauer, uhrzeit);
            Start_mit_Weckzeit(weckzeit, onZustand, onRestzeit);
        }

        public void Stopp(Action<bool> onZustand) {
            _timer.Stopp();
            var istGestartet = Wecker.Wecker_gestoppt();
            onZustand(istGestartet);
        }
    }
}