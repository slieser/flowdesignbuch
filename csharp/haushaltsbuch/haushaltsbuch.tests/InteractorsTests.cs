using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace haushaltsbuch.tests
{
    [TestFixture]
    public class InteractorsTests
    {
        [SetUp]
        public void Setup() {
            Directory.SetCurrentDirectory(TestContext.CurrentContext.TestDirectory);
            File.Delete("buchungen.csv");
        }
        
        [Test]
        public void Integrationstest() {
            var result = Interactors.Buchung_ausführen(new[]{"einzahlung", "500"});
            Assert.That(result.saldo, Is.EqualTo(500));
            Assert.That(result.kategorie, Is.Null);
            Assert.That(result.betrag, Is.EqualTo(0));

            result = Interactors.Buchung_ausführen(new[]{"einzahlung", "300"});
            Assert.That(result.saldo, Is.EqualTo(800));
            Assert.That(result.kategorie, Is.Null);
            Assert.That(result.betrag, Is.EqualTo(0));

            result = Interactors.Buchung_ausführen(new[]{"auszahlung", "200", "Miete"});
            Assert.That(result.saldo, Is.EqualTo(600));
            Assert.That(result.kategorie, Is.EqualTo("Miete"));
            Assert.That(result.betrag, Is.EqualTo(200));

            result = Interactors.Buchung_ausführen(new[]{"auszahlung", "100", "Miete"});
            Assert.That(result.saldo, Is.EqualTo(500));
            Assert.That(result.kategorie, Is.EqualTo("Miete"));
            Assert.That(result.betrag, Is.EqualTo(300));

            result = Interactors.Buchung_ausführen(new[]{"auszahlung", "50", "Lebenshaltung"});
            Assert.That(result.saldo, Is.EqualTo(450));
            Assert.That(result.kategorie, Is.EqualTo("Lebenshaltung"));
            Assert.That(result.betrag, Is.EqualTo(50));

            var monat = DateTime.Now.Month.ToString();
            var jahr = DateTime.Now.Year.ToString();
            var result2 = Interactors.Übersicht_ausführen(new[]{monat, jahr}).ToArray();
            Assert.That(result2[0].Item1, Is.EqualTo("Miete"));
            Assert.That(result2[0].Item2, Is.EqualTo(300));
            Assert.That(result2[1].Item1, Is.EqualTo("Lebenshaltung"));
            Assert.That(result2[1].Item2, Is.EqualTo(50));
        }
    }
}