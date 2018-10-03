using System;

namespace haushaltsbuch.contracts
{
    public class Buchung
    {
        public Buchungstypen Buchungstyp { get; set; }

        public DateTime Buchungsdatum { get; set; }

        public double Betrag { get; set; }

        public string Kategorie { get; set; }

        public string Memo { get; set; }
    }
}