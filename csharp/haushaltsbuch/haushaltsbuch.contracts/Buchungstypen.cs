using System;

namespace haushaltsbuch.contracts
{
    public enum Buchungstypen
    {
        Einzahlung,
        Auszahlung
    };

    public static class BuchungstypenConverter
    {
        public static Buchungstypen FromString(string buchungstyp) {
            switch (buchungstyp.ToLower()) {
                case "einzahlung":
                    return Buchungstypen.Einzahlung;
                case "auszahlung":
                    return Buchungstypen.Auszahlung;
            }
            throw new ArgumentException("Unbekannter Buchungstyp");
        }

        public static string AsString(Buchungstypen buchungstyp) {
            switch (buchungstyp) {
                case Buchungstypen.Einzahlung:
                    return "einzahlung";
                case Buchungstypen.Auszahlung:
                    return "auszahlung";
                default:
                    throw new ArgumentOutOfRangeException("buchungstyp");
            }
        }
    }
}