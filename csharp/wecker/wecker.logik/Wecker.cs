using System;

namespace wecker.logik
{
    public static class Wecker
    {
        public static bool Wecker_gestartet() {
            return true;
        }

        public static bool Wecker_gestoppt() {
            return false;
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