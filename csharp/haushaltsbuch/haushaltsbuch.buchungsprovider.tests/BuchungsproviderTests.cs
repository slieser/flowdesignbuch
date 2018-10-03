using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using haushaltsbuch.contracts;
using NUnit.Framework;

namespace haushaltsbuch.buchungsprovider.tests
{
    [TestFixture]
    public class BuchungsproviderTests
    {
        [SetUp]
        public void Setup() {
            Directory.SetCurrentDirectory(TestContext.CurrentContext.TestDirectory);
            File.Delete("buchungen.csv");
        }
        
        [Test]
        public void Save_and_Load_all() {
            Buchungsprovider.Save(new Buchung {
                Betrag = 42d,
                Buchungsdatum = new DateTime(2018, 2, 4),
                Buchungstyp = Buchungstypen.Einzahlung,
                Kategorie = null,
                Memo = null
            });

            var result = Buchungsprovider.Load_All().ToArray();
            Assert.That(result.Length, Is.EqualTo(1));
        }
    }
}