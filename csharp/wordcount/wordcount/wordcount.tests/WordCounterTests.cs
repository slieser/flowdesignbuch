using NUnit.Framework;

namespace wordcount.tests
{
    [TestFixture]
    public class WordCounterTests
    {
        [Test]
        public void Integrationtest() {
            var sut = new WordCounter();
            Assert.That(sut.CountWords("Mary had a little lamb."), Is.EqualTo(5));
        }
    }
}