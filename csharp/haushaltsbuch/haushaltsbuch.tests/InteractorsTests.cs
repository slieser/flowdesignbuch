﻿using System;
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
            Assert.That(result.TheSaldo, Is.EqualTo(500));
            Assert.That(result.Bezeichnung, Is.Null);
            Assert.That(result.Betrag, Is.EqualTo(0));

            result = Interactors.Buchung_ausführen(new[]{"einzahlung", "300"});
            Assert.That(result.TheSaldo, Is.EqualTo(800));
            Assert.That(result.Bezeichnung, Is.Null);
            Assert.That(result.Betrag, Is.EqualTo(0));

            result = Interactors.Buchung_ausführen(new[]{"auszahlung", "200", "Miete"});
            Assert.That(result.TheSaldo, Is.EqualTo(600));
            Assert.That(result.Bezeichnung, Is.EqualTo("Miete"));
            Assert.That(result.Betrag, Is.EqualTo(200));

            result = Interactors.Buchung_ausführen(new[]{"auszahlung", "100", "Miete"});
            Assert.That(result.TheSaldo, Is.EqualTo(500));
            Assert.That(result.Bezeichnung, Is.EqualTo("Miete"));
            Assert.That(result.Betrag, Is.EqualTo(300));

            result = Interactors.Buchung_ausführen(new[]{"auszahlung", "50", "Lebenshaltung"});
            Assert.That(result.TheSaldo, Is.EqualTo(450));
            Assert.That(result.Bezeichnung, Is.EqualTo("Lebenshaltung"));
            Assert.That(result.Betrag, Is.EqualTo(50));

            var monat = DateTime.Now.Month.ToString();
            var jahr = DateTime.Now.Year.ToString();
            var result2 = Interactors.Übersicht_ausführen(new[]{monat, jahr}).ToArray();
            Assert.That(result2[0].Bezeichnung, Is.EqualTo("Miete"));
            Assert.That(result2[0].Betrag, Is.EqualTo(300));
            Assert.That(result2[1].Bezeichnung, Is.EqualTo("Lebenshaltung"));
            Assert.That(result2[1].Betrag, Is.EqualTo(50));
        }
    }
}