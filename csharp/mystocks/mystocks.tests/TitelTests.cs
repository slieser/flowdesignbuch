using mystocks.data;
using NUnit.Framework;

namespace mystocks.tests
{
    [TestFixture]
    public class TitelTests
    {
        [Test]
        public void Titel_SetAndGetName_ReturnsCorrectValue()
        {
            var titel = new Titel { Name = "Apple Inc." };

            Assert.That(titel.Name, Is.EqualTo("Apple Inc."));
        }

        [Test]
        public void Titel_SetAndGetSymbol_ReturnsCorrectValue()
        {
            var titel = new Titel { Symbol = "AAPL" };

            Assert.That(titel.Symbol, Is.EqualTo("AAPL"));
        }

        [Test]
        public void Titel_SetAndGetBörse_ReturnsCorrectValue()
        {
            var titel = new Titel { Börse = "NASDAQ" };

            Assert.That(titel.Börse, Is.EqualTo("NASDAQ"));
        }

        [Test]
        public void Titel_SetAllProperties_ReturnsCorrectValues()
        {
            var titel = new Titel
            {
                Name = "Tesla Inc.",
                Symbol = "TSLA",
                Börse = "NASDAQ"
            };

            Assert.Multiple(() =>
            {
                Assert.That(titel.Name, Is.EqualTo("Tesla Inc."));
                Assert.That(titel.Symbol, Is.EqualTo("TSLA"));
                Assert.That(titel.Börse, Is.EqualTo("NASDAQ"));
            });
        }
    }
}