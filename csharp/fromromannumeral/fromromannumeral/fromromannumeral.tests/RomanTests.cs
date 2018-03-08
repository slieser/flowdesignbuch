using NUnit.Framework;

namespace fromromannumeral.tests
{
    [TestFixture]
    public class RomanTests
    {
        [Test]
        public void Ziffern() {
            Assert.That(Roman.FromRomanNumeral("I"), Is.EqualTo(1));
            Assert.That(Roman.FromRomanNumeral("V"), Is.EqualTo(5));
            Assert.That(Roman.FromRomanNumeral("X"), Is.EqualTo(10));
            Assert.That(Roman.FromRomanNumeral("L"), Is.EqualTo(50));
            Assert.That(Roman.FromRomanNumeral("C"), Is.EqualTo(100));
            Assert.That(Roman.FromRomanNumeral("D"), Is.EqualTo(500));
            Assert.That(Roman.FromRomanNumeral("M"), Is.EqualTo(1000));
        }

        [Test]
        public void Addition() {
            Assert.That(Roman.FromRomanNumeral("II"), Is.EqualTo(2));
            Assert.That(Roman.FromRomanNumeral("VII"), Is.EqualTo(7));
            Assert.That(Roman.FromRomanNumeral("XV"), Is.EqualTo(15));
        }

        [Test]
        public void Subtraktion() {
            Assert.That(Roman.FromRomanNumeral("IV"), Is.EqualTo(4));
            Assert.That(Roman.FromRomanNumeral("IX"), Is.EqualTo(9));
            Assert.That(Roman.FromRomanNumeral("CM"), Is.EqualTo(900));
        }

        [Test]
        public void Integrationstest() {
            Assert.That(Roman.FromRomanNumeral("XLII"), Is.EqualTo(42));
            Assert.That(Roman.FromRomanNumeral("XCIX"), Is.EqualTo(99));
            Assert.That(Roman.FromRomanNumeral("MMXIII"), Is.EqualTo(2013));
        }
    }
}