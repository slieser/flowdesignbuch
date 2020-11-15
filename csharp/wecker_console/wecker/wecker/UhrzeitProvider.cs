using System;

namespace wecker
{
    public static class UhrzeitProvider
    {
        public static DateTime Uhrzeit_lesen() {
            return DateTime.Now;
        }
    }
}