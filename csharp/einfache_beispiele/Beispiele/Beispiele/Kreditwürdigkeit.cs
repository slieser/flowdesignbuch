using System;

namespace Beispiele
{
    public class Kreditwürdigkeit
    {
        public void Kreditwürdigkeit_prüfen(double betrag, Action beiKartenzahlung, Action beiVorkasse) {
            if (betrag <= 1.000) {
                beiKartenzahlung();
            }
            else {
                beiVorkasse();
            }
        }

        public void Verwendung() {
            var betrag = 2.39;  // ... irgendein Betrag
            Kreditwürdigkeit_prüfen(betrag,
                beiKartenzahlung: () => {
                    // ... Code, der bei Kartenzahlung
                    // ausgeführt wird
                },
                beiVorkasse: () => {
                    // ... Code, der bei Vorkasse
                    // ausgeführt wird
                });
        }

        public bool IstKreditwürdig(double betrag) {
            if (betrag <= 1.000) {
                return true;
            }
            else {
                return false;
            }
        }

        public void Verwendung2() {
            var betrag = 2.39;  // ... irgendein Betrag
            if (IstKreditwürdig(betrag)) {
                // ... Code, der bei Kartenzahlung
                // ausgeführt wird
            }
            else {
                // ... Code, der bei Vorkasse
                // ausgeführt wird
            };
        }

        public void Verwendung3() {
            var kunde = new Kunde();
            var betrag = 2.39;  // ... irgendein Betrag
            if (IstKreditwürdig(betrag) || kunde.Status == Status.Gold) {
                // ... Code, der bei Kartenzahlung
                // ausgeführt wird
            }
            else {
                // ... Code, der bei Vorkasse
                // ausgeführt wird
            };
        }

        public class Kunde
        {
            public Status Status { get; set; }
        }

        public enum Status
        {
            Bronze,
            Silber,
            Gold
        };
    }
}