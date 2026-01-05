using mystocks.data;
using NUnit.Framework;

namespace mystocks.tests
{
    [TestFixture]
    public class WertpapierTests
    {
        [Test]
        public void Wertpapier_SetAndGetName_ReturnsCorrectValue()
        {
            var wertpapier = new Wertpapier { Name = "Apple Inc." };

            Assert.That(wertpapier.Name, Is.EqualTo("Apple Inc."));
        }

        [Test]
        public void Wertpapier_SetAndGetSymbol_ReturnsCorrectValue()
        {
            var wertpapier = new Wertpapier { Symbol = "AAPL" };

            Assert.That(wertpapier.Symbol, Is.EqualTo("AAPL"));
        }

        [Test]
        public void Wertpapier_SetAndGetBörse_ReturnsCorrectValue()
        {
            var wertpapier = new Wertpapier { Börse = "NASDAQ" };

            Assert.That(wertpapier.Börse, Is.EqualTo("NASDAQ"));
        }

        [Test]
        public void Wertpapier_SetAndGetKurs_ReturnsCorrectValue()
        {
            var wertpapier = new Wertpapier { Kurs = "150.25" };

            Assert.That(wertpapier.Kurs, Is.EqualTo("150.25"));
        }

        [Test]
        public void Wertpapier_SetAndGetAbsolut_ReturnsCorrectValue()
        {
            var wertpapier = new Wertpapier { Absolut = "+2.50" };

            Assert.That(wertpapier.Absolut, Is.EqualTo("+2.50"));
        }

        [Test]
        public void Wertpapier_SetAndGetRelativ_ReturnsCorrectValue()
        {
            var wertpapier = new Wertpapier { Relativ = "+1.5%" };

            Assert.That(wertpapier.Relativ, Is.EqualTo("+1.5%"));
        }

        [Test]
        public void Wertpapier_SetAllProperties_ReturnsCorrectValues()
        {
            var wertpapier = new Wertpapier
            {
                Name = "Tesla Inc.",
                Symbol = "TSLA",
                Börse = "NASDAQ",
                Kurs = "250.00",
                Absolut = "-5.00",
                Relativ = "-2.0%"
            };

            Assert.Multiple(() =>
            {
                Assert.That(wertpapier.Name, Is.EqualTo("Tesla Inc."));
                Assert.That(wertpapier.Symbol, Is.EqualTo("TSLA"));
                Assert.That(wertpapier.Börse, Is.EqualTo("NASDAQ"));
                Assert.That(wertpapier.Kurs, Is.EqualTo("250.00"));
                Assert.That(wertpapier.Absolut, Is.EqualTo("-5.00"));
                Assert.That(wertpapier.Relativ, Is.EqualTo("-2.0%"));
            });
        }
    }
}