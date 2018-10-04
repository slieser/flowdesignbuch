using System;

namespace wecker.logik
{
    public static class Wecker
    {
        public static (bool startbar, bool stoppbar) Wecker_gestartet() {
            return (false, true);
        }

        public static (bool startbar, bool stoppbar) Wecker_gestoppt() {
            return (true, false);
        }

        public static DateTime Weckzeit_berechnen(TimeSpan restzeit, DateTime uhrzeit) {
            return uhrzeit + restzeit;
        }

        public static TimeSpan Restzeit_berechnen(DateTime uhrzeit, DateTime weckzeit) {
            return weckzeit - uhrzeit;
        }

        public static void Wenn_Restzeit_abgelaufen(TimeSpan restzeit, Action continueWith) {
            if (restzeit <= new TimeSpan()) {
                continueWith();
            }
        }
    }
}