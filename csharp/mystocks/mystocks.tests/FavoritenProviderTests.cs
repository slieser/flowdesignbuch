using System.IO;
using System.Linq;
using mystocks.provider;
using NUnit.Framework;

namespace mystocks.tests
{
    [TestFixture]
    public class FavoritenProviderTests
    {
        private FavoritenProvider _provider;

        [SetUp]
        public void SetUp()
        {
            _provider = new FavoritenProvider();
            if (File.Exists(FavoritenProvider.Filename))
            {
                File.Delete(FavoritenProvider.Filename);
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(FavoritenProvider.Filename))
            {
                File.Delete(FavoritenProvider.Filename);
            }
        }

        [Test]
        public void FavoritenLaden_WhenFileNotExists_CreatesEmptyFile()
        {
            var result = _provider.FavoritenLaden();

            Assert.That(result, Is.Empty);
            Assert.That(File.Exists(FavoritenProvider.Filename), Is.True);
        }

        [Test]
        public void FavoritenLaden_WhenFileExists_ReturnsContent()
        {
            File.WriteAllLines(FavoritenProvider.Filename, new[] { "AAPL", "TSLA" });

            var result = _provider.FavoritenLaden().ToList();

            Assert.That(result, Has.Count.EqualTo(2));
            Assert.That(result, Does.Contain("AAPL"));
            Assert.That(result, Does.Contain("TSLA"));
        }

        [Test]
        public void FavoritenSpeichern_WritesSymbolsToFile()
        {
            var symbole = new[] { "AAPL", "TSLA", "AMZN" };

            _provider.FavoritenSpeichern(symbole);

            var fileContent = File.ReadAllLines(FavoritenProvider.Filename);
            Assert.That(fileContent, Is.EqualTo(symbole));
        }

        [Test]
        public void FavoritHinzufügen_WhenSymbolNotExists_AddsSymbol()
        {
            var symbole = new[] { "AAPL", "TSLA" };

            var result = _provider.FavoritHinzufügen(symbole, "AMZN").ToList();

            Assert.That(result, Has.Count.EqualTo(3));
            Assert.That(result, Does.Contain("AMZN"));
        }

        [Test]
        public void FavoritHinzufügen_WhenSymbolExists_DoesNotAddDuplicate()
        {
            var symbole = new[] { "AAPL", "TSLA" };

            var result = _provider.FavoritHinzufügen(symbole, "AAPL").ToList();

            Assert.That(result, Has.Count.EqualTo(2));
        }

        [Test]
        public void FavoritHinzufügen_WhenSymbolExistsDifferentCase_DoesNotAddDuplicate()
        {
            var symbole = new[] { "AAPL", "TSLA" };

            var result = _provider.FavoritHinzufügen(symbole, "aapl").ToList();

            Assert.That(result, Has.Count.EqualTo(2));
        }

        [Test]
        public void FavoritHinzufügen_SavesUpdatedListToFile()
        {
            var symbole = new[] { "AAPL" };

            _provider.FavoritHinzufügen(symbole, "TSLA");

            var fileContent = File.ReadAllLines(FavoritenProvider.Filename);
            Assert.That(fileContent, Has.Length.EqualTo(2));
            Assert.That(fileContent, Does.Contain("AAPL"));
            Assert.That(fileContent, Does.Contain("TSLA"));
        }

        [Test]
        public void FavoritEntfernen_WhenSymbolExists_RemovesSymbol()
        {
            var symbole = new[] { "AAPL", "TSLA", "AMZN" };

            var result = _provider.FavoritEntfernen(symbole, "TSLA").ToList();

            Assert.That(result, Has.Count.EqualTo(2));
            Assert.That(result, Does.Not.Contain("TSLA"));
        }

        [Test]
        public void FavoritEntfernen_WhenSymbolNotExists_ReturnsUnchangedList()
        {
            var symbole = new[] { "AAPL", "TSLA" };

            var result = _provider.FavoritEntfernen(symbole, "AMZN").ToList();

            Assert.That(result, Has.Count.EqualTo(2));
        }

        [Test]
        public void FavoritEntfernen_SavesUpdatedListToFile()
        {
            var symbole = new[] { "AAPL", "TSLA" };

            _provider.FavoritEntfernen(symbole, "TSLA");

            var fileContent = File.ReadAllLines(FavoritenProvider.Filename);
            Assert.That(fileContent, Has.Length.EqualTo(1));
            Assert.That(fileContent, Does.Contain("AAPL"));
        }
    }
}