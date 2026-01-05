using System.Linq;
using System.Threading.Tasks;
using mystocks.provider;
using NUnit.Framework;

namespace mystocks.tests
{
    [TestFixture]
    public class KursProviderDummyTests
    {
        private KursProviderDummy _provider;

        [SetUp]
        public void SetUp()
        {
            _provider = new KursProviderDummy();
        }

        [Test]
        public async Task KurseErmitteln_WithValidSymbol_ReturnsWertpapier()
        {
            var symbole = new[] { "TSLA" };

            var result = await _provider.KurseErmitteln(symbole).ToListAsync();

            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Symbol, Is.EqualTo("TSLA"));
            Assert.That(result[0].Name, Is.EqualTo("Tesla Inc."));
        }

        [Test]
        public async Task KurseErmitteln_WithMultipleValidSymbols_ReturnsAllWertpapiere()
        {
            var symbole = new[] { "TSLA", "AAPL", "AMZN" };

            var result = await _provider.KurseErmitteln(symbole).ToListAsync();

            Assert.That(result, Has.Count.EqualTo(3));
        }

        [Test]
        public async Task KurseErmitteln_WithInvalidSymbol_ReturnsEmpty()
        {
            var symbole = new[] { "INVALID" };

            var result = await _provider.KurseErmitteln(symbole).ToListAsync();

            Assert.That(result, Is.Empty);
        }

        [Test]
        public async Task KurseErmitteln_WithEmptyList_ReturnsEmpty()
        {
            var symbole = Enumerable.Empty<string>();

            var result = await _provider.KurseErmitteln(symbole).ToListAsync();

            Assert.That(result, Is.Empty);
        }

        [Test]
        public async Task KurseErmitteln_WithMixedValidAndInvalidSymbols_ReturnsOnlyValid()
        {
            var symbole = new[] { "TSLA", "INVALID", "AAPL" };

            var result = await _provider.KurseErmitteln(symbole).ToListAsync();

            Assert.That(result, Has.Count.EqualTo(2));
        }

        [Test]
        public async Task TitelSuchen_WithMatchingPrefix_ReturnsTitel()
        {
            var result = await _provider.TitelSuchen("ts").ToListAsync();

            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Symbol, Is.EqualTo("TSLA"));
        }

        [Test]
        public async Task TitelSuchen_WithUpperCasePrefix_ReturnsTitel()
        {
            var result = await _provider.TitelSuchen("TS").ToListAsync();

            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Symbol, Is.EqualTo("TSLA"));
        }

        [Test]
        public async Task TitelSuchen_WithMultipleMatches_ReturnsAllMatching()
        {
            var result = await _provider.TitelSuchen("a").ToListAsync();

            Assert.That(result, Has.Count.EqualTo(2));
            Assert.That(result.Select(t => t.Symbol), Does.Contain("AAPL"));
            Assert.That(result.Select(t => t.Symbol), Does.Contain("AMZN"));
        }

        [Test]
        public async Task TitelSuchen_WithNoMatch_ReturnsEmpty()
        {
            var result = await _provider.TitelSuchen("xyz").ToListAsync();

            Assert.That(result, Is.Empty);
        }

        [Test]
        public async Task TitelSuchen_WithEmptyString_ReturnsAllItems()
        {
            var result = await _provider.TitelSuchen("").ToListAsync();

            Assert.That(result, Has.Count.EqualTo(3));
        }

        [Test]
        public async Task TitelSuchen_ReturnsCorrectTitelProperties()
        {
            var result = await _provider.TitelSuchen("tsla").ToListAsync();

            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Name, Is.EqualTo("Tesla Inc."));
            Assert.That(result[0].Symbol, Is.EqualTo("TSLA"));
        }
    }
}