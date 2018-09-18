using System.IO;
using System.Linq;
using NUnit.Framework;

namespace questionnaire.tests
{
    [TestFixture]
    public class InteractorsTests
    {
        [SetUp]
        public void Setup() {
            Directory.SetCurrentDirectory(TestContext.CurrentContext.TestDirectory);
        }
        
        [Test]
        public void Integrationstest() {
            var aufgaben = Interactors.Start().ToArray();
            
            Assert.That(aufgaben.Length, Is.EqualTo(2));
            
            Assert.That(aufgaben[0].Frage, Is.EqualTo("Welches Tier ist ein Säugetier?"));
            Assert.That(aufgaben[0].Antwortmöglichkeiten.Count, Is.EqualTo(3));
            Assert.That(aufgaben[0].Antwortmöglichkeiten[0].Antwort, Is.EqualTo("Katze"));
            Assert.That(aufgaben[0].Antwortmöglichkeiten[0].IstKorrekt, Is.True);
            Assert.That(aufgaben[0].Antwortmöglichkeiten[1].Antwort, Is.EqualTo("Ameise"));
            Assert.That(aufgaben[0].Antwortmöglichkeiten[1].IstKorrekt, Is.False);
            Assert.That(aufgaben[0].Antwortmöglichkeiten[2].Antwort, Is.EqualTo("Fliege"));
            Assert.That(aufgaben[0].Antwortmöglichkeiten[2].IstKorrekt, Is.False);

            Assert.That(aufgaben[1].Frage, Is.EqualTo("Wieviel ist 2+3?"));
            Assert.That(aufgaben[1].Antwortmöglichkeiten.Count, Is.EqualTo(3));
            Assert.That(aufgaben[1].Antwortmöglichkeiten[0].Antwort, Is.EqualTo("4"));
            Assert.That(aufgaben[1].Antwortmöglichkeiten[0].IstKorrekt, Is.False);
            Assert.That(aufgaben[1].Antwortmöglichkeiten[1].Antwort, Is.EqualTo("5"));
            Assert.That(aufgaben[1].Antwortmöglichkeiten[1].IstKorrekt, Is.True);
            Assert.That(aufgaben[1].Antwortmöglichkeiten[2].Antwort, Is.EqualTo("6"));
            Assert.That(aufgaben[1].Antwortmöglichkeiten[2].IstKorrekt, Is.False);
        }
    }
}