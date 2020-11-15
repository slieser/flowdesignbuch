using System;

namespace wecker
{
    public static class Wecker
    {
        public static TimeSpan Restzeit_berechnen(in DateTime uhrzeit, in DateTime weckzeit) {
            return weckzeit - uhrzeit;
        }

        public static bool Restzeit_ist_abgelaufen(TimeSpan restzeit) {
            return restzeit <= new TimeSpan();
        }
    }
}