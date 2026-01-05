using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using mystocks.data;
using mystocks.provider;
using NUnit.Framework;

namespace mystocks.tests
{
    [TestFixture]
    public class InteractorsTests
    {
        private Interactors _interactors;
        private Mock<IKursProvider> _mockKursProvider;

        [SetUp]
        public void SetUp()
        {
            _mockKursProvider = new Mock<IKursProvider>();
            _interactors = new Interactors(_mockKursProvider.Object);

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
        public async Task TitelSuchen_CallsKursProvider()
        {
            var expectedTitel = new[] { new Titel { Symbol = "AAPL", Name = "Apple" } };
            _mockKursProvider.Setup(p => p.TitelSuchen("app"))
                .Returns(expectedTitel.ToAsyncEnumerable());

            var result = await _interactors.TitelSuchen("app").ToListAsync();

            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Symbol, Is.EqualTo("AAPL"));
            _mockKursProvider.Verify(p => p.TitelSuchen("app"), Times.Once);
        }

        [Test]
        public async Task TitelHinzufügen_AddsToFavoritenAndReturnsKurse()
        {
            var expectedWertpapiere = new[] { new Wertpapier { Symbol = "AAPL", Name = "Apple" } };
            _mockKursProvider.Setup(p => p.KurseErmitteln(It.IsAny<IEnumerable<string>>()))
                .Returns(expectedWertpapiere.ToAsyncEnumerable());

            var result = await _interactors.TitelHinzufügen("AAPL").ToListAsync();

            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Symbol, Is.EqualTo("AAPL"));

            var favoriten = File.ReadAllLines(FavoritenProvider.Filename);
            Assert.That(favoriten, Does.Contain("AAPL"));
        }

        [Test]
        public async Task TitelEntfernen_RemovesFromFavoritenAndReturnsKurse()
        {
            File.WriteAllLines(FavoritenProvider.Filename, new[] { "AAPL", "TSLA" });

            var expectedWertpapiere = new[] { new Wertpapier { Symbol = "AAPL", Name = "Apple" } };
            _mockKursProvider.Setup(p => p.KurseErmitteln(It.IsAny<IEnumerable<string>>()))
                .Returns(expectedWertpapiere.ToAsyncEnumerable());

            var result = await _interactors.TitelEntfernen("TSLA").ToListAsync();

            var favoriten = File.ReadAllLines(FavoritenProvider.Filename);
            Assert.That(favoriten, Does.Not.Contain("TSLA"));
            Assert.That(favoriten, Does.Contain("AAPL"));
        }

        [Test]
        public async Task TitelHinzufügen_WithMultipleTitel_AccumulatesFavoriten()
        {
            _mockKursProvider.Setup(p => p.KurseErmitteln(It.IsAny<IEnumerable<string>>()))
                .Returns(Enumerable.Empty<Wertpapier>().ToAsyncEnumerable());

            await _interactors.TitelHinzufügen("AAPL").ToListAsync();
            await _interactors.TitelHinzufügen("TSLA").ToListAsync();

            var favoriten = File.ReadAllLines(FavoritenProvider.Filename);
            Assert.That(favoriten, Has.Length.EqualTo(2));
            Assert.That(favoriten, Does.Contain("AAPL"));
            Assert.That(favoriten, Does.Contain("TSLA"));
        }
    }

    [TestFixture]
    public class InteractorsWithDummyProviderTests
    {
        private Interactors _interactors;

        [SetUp]
        public void SetUp()
        {
            _interactors = new Interactors(new KursProviderDummy());

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
        public async Task TitelSuchen_ReturnsMatchingTitel()
        {
            var result = await _interactors.TitelSuchen("ts").ToListAsync();

            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Symbol, Is.EqualTo("TSLA"));
        }

        [Test]
        public async Task TitelHinzufügen_ReturnsWertpapierForAddedTitel()
        {
            var result = await _interactors.TitelHinzufügen("TSLA").ToListAsync();

            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Symbol, Is.EqualTo("TSLA"));
            Assert.That(result[0].Name, Is.EqualTo("Tesla Inc."));
        }

        [Test]
        public async Task TitelEntfernen_AfterAdding_RemovesTitel()
        {
            await _interactors.TitelHinzufügen("TSLA").ToListAsync();
            await _interactors.TitelHinzufügen("AAPL").ToListAsync();

            var result = await _interactors.TitelEntfernen("TSLA").ToListAsync();

            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Symbol, Is.EqualTo("AAPL"));
        }
    }
}