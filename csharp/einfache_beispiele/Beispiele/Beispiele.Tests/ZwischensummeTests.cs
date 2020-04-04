using System;
using NUnit.Framework;

namespace Beispiele.Tests
{
    [TestFixture]
    public class ZwischensummeTests
    {
        [Test]
        public void Test() {
            var sut = new Zwischensumme3();
            sut._state.Set(42);

            var result = sut.Aktuelle_Zwischensumme_berechnen(8);
            Assert.That(result, Is.EqualTo(50));
        }
    }
}