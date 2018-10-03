using System;
using haushaltsbuch.contracts;
using NUnit.Framework;

namespace haushaltsbuch.logic.tests
{
    [TestFixture]
    public class Buchhaltung_Tests
    {
        [Test]
        public void Saldo() {
            var buchung = new Buchung {
                Buchungsdatum = new DateTime(2015, 8, 10)
            };

            var buchungen = new[] {
                new Buchung {
                    Buchungstyp = Buchungstypen.Einzahlung,
                    Buchungsdatum = new DateTime(2015, 8, 9),
                    Betrag = 100.0
                },
                new Buchung {
                    Buchungstyp = Buchungstypen.Auszahlung,
                    Buchungsdatum = new DateTime(2015, 8, 10),
                    Betrag = 30.0
                },
                new Buchung {
                    Buchungstyp = Buchungstypen.Auszahlung,
                    Buchungsdatum = new DateTime(2015, 8, 11),
                    Betrag = 30.0
                }
            };

            var saldo = Buchhaltung.Saldo(buchung, buchungen);

            Assert.That(saldo, Is.EqualTo(70.0));
        }

        [Test]
        public void Kategorie() {
            var buchung = new Buchung {
                Buchungsdatum = new DateTime(2015, 8, 10),
                Kategorie = "abc"
            };

            var buchungen = new[] {
                new Buchung {
                    Buchungstyp = Buchungstypen.Einzahlung,     // Keine Berücksichtigung, da Einzahlung
                    Buchungsdatum = new DateTime(2015, 8, 9),
                    Betrag = 100.0
                },
                new Buchung {
                    Buchungstyp = Buchungstypen.Auszahlung,    // berücksichtigen
                    Buchungsdatum = new DateTime(2015, 8, 10),
                    Kategorie = "abc",
                    Betrag = 10.0
                },
                new Buchung {
                    Buchungstyp = Buchungstypen.Auszahlung,     // berücksichtigen, obwohl hinter dem Buchungsdatum, aber selber Monat
                    Buchungsdatum = new DateTime(2015, 8, 11),
                    Kategorie = "abc",
                    Betrag = 20.0
                },
                new Buchung {
                    Buchungstyp = Buchungstypen.Auszahlung,     // keine Berücksichtigung, da andere Kategorie
                    Buchungsdatum = new DateTime(2015, 8, 11),
                    Kategorie = "xyz",
                    Betrag = 20.0
                }
            };

            var tuple = Buchhaltung.Kategorie_berechnen(buchung, buchungen);

            Assert.That(tuple.Item1, Is.EqualTo("abc"));
            Assert.That(tuple.Item2, Is.EqualTo(30.0));
        }
    }
}