using NUnit.Framework;

namespace wordwrap.tests
{
    [TestFixture]
    public class InteractorsTests
    {
        [Test]
        public void Wrap_empty_string_to_20_characters() {
            var result = new Interactors().Wrap("", 20);
            Assert.That(result, Is.EqualTo(""));
        }

        [TestCase("Alle meine Entchen", 10, "Alle meine\nEntchen")]
        [TestCase("Alle meine Entchen", 5, "Alle\nmeine\nEntchen")]
        [TestCase("Alle meine Entchen", 4, "Alle\nmeine\nEntchen")]
        [TestCase("Alle\nmeine\nEntchen", 10, "Alle meine\nEntchen")]
        [TestCase("Alle meine\n\nEntchen", 4, "Alle\nmeine\n\nEntchen")]
        [TestCase("Das ist ein Text, der umbrochen wird.", 10, "Das ist\nein Text,\nder\numbrochen\nwird.")]
        public void Wrap(string text, int width, string expected) {
            var result = new Interactors().Wrap(text, width);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}