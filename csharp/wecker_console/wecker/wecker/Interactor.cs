using System;

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
}