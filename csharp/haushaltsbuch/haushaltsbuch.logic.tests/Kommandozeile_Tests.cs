using System;
using haushaltsbuch.contracts;
using NUnit.Framework;

namespace haushaltsbuch.logic.tests
{
    [TestFixture]
    public class Kommandozeile_Tests
    {
        [Test]
        public void Integrationstest_Einzahlung() {
            var buchung = Kommandozeile.Buchung_aus_Parametern_erstellen(new[] { "einzahlung", "01.02.2015", "3,45" });
            Assert.That(buchung.Buchungstyp, Is.EqualTo(Buchungstypen.Einzahlung));
            Assert.That(buchung.Betrag, Is.EqualTo(3.45));
            Assert.That(buchung.Buchungsdatum, Is.EqualTo(new DateTime(2015, 2, 1)));
        }

        [Test]
        public void Integrationstest_Auszahlung() {
            var buchung = Kommandozeile.Buchung_aus_Parametern_erstellen(new[] { "auszahlung", "01.02.2015", "3,45", "abc", "mem" });
            Assert.That(buchung.Buchungstyp, Is.EqualTo(Buchungstypen.Auszahlung));
            Assert.That(buchung.Betrag, Is.EqualTo(3.45));
            Assert.That(buchung.Buchungsdatum, Is.EqualTo(new DateTime(2015, 2, 1)));
            Assert.That(buchung.Kategorie, Is.EqualTo("abc"));
            Assert.That(buchung.Memo, Is.EqualTo("mem"));
        }

        [Test]
        public void Kommando_Einzahlung() {
            var tuple = Kommandozeile.Buchung_zu_Kommando_erstellen(new[] { "einzahlung" });
            Assert.That(tuple.Buchung.Buchungstyp, Is.EqualTo(Buchungstypen.Einzahlung));
            Assert.That(tuple.Args, Is.Empty);
        } 

        [Test]
        public void Kommando_Auszahlung() {
            var tuple = Kommandozeile.Buchung_zu_Kommando_erstellen(new[] { "auszahlung" });
            Assert.That(tuple.Buchung.Buchungstyp, Is.EqualTo(Buchungstypen.Auszahlung));
            Assert.That(tuple.Args, Is.Empty);
        }

        [Test]
        public void Buchungsdatum_ist_gegeben() {
            var tuple = Kommandozeile.Datum_übernehmen(new Buchung(), new[] { "04.02.2015" });
            Assert.That(tuple.Buchung.Buchungsdatum, Is.EqualTo(new DateTime(2015, 2, 4)));
            Assert.That(tuple.Args, Is.Empty);
        }

        [Test]
        public void Buchungsdatum_ist_nicht_gegeben() {
            Kommandozeile.now = () => new DateTime(2014, 1, 2);
            var tuple = Kommandozeile.Datum_übernehmen(new Buchung(), new [] { "" });
            Assert.That(tuple.Buchung.Buchungsdatum, Is.EqualTo(new DateTime(2014, 1, 2)));
            Assert.That(tuple.Args, Is.Not.Empty);
        }

        [Test]
        public void Betrag() {
            var tuple = Kommandozeile.Betrag_übernehmen(new Buchung(), new[] { "1,23" });
            Assert.That(tuple.Buchung.Betrag, Is.EqualTo(1.23));
            Assert.That(tuple.Args, Is.Empty);
        }

        [Test]
        public void Kategorie_ist_gegeben() {
            var tuple = Kommandozeile.Kategorie_übernehmen(new Buchung(), new[] { "abc" });
            Assert.That(tuple.Buchung.Kategorie, Is.EqualTo("abc"));
            Assert.That(tuple.Args, Is.Empty);
        }

        [Test]
        public void Kategorie_ist_nicht_gegeben() {
            var tuple = Kommandozeile.Kategorie_übernehmen(new Buchung(), new string[] { });
            Assert.That(tuple.Buchung.Kategorie, Is.Null);
            Assert.That(tuple.Args, Is.Empty);
        }

        [Test]
        public void Memo_ist_gegeben() {
            var tuple = Kommandozeile.Memo_übernehmen(new Buchung(), new[] { "abc" });
            Assert.That(tuple.Buchung.Memo, Is.EqualTo("abc"));
            Assert.That(tuple.Args, Is.Empty);
        }

        [Test]
        public void Memo_ist_nicht_gegeben() {
            var tuple = Kommandozeile.Memo_übernehmen(new Buchung(), new string[] { });
            Assert.That(tuple.Buchung.Memo, Is.Null);
            Assert.That(tuple.Args, Is.Empty);
        }
    }
}