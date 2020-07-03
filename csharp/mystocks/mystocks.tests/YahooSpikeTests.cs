using System;
using System.Threading.Tasks;
using NUnit.Framework;
using YahooFinanceApi;

namespace Tests
{
    public class YahooSpikeTests
    {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public async Task Wertpapier_Infos_ermmitteln() {
            var securities = await Yahoo
                .Symbols("AAPL", "GOOG")
                .Fields(Field.LongName, Field.Symbol, Field.RegularMarketPrice, Field.FiftyTwoWeekHigh)
                .QueryAsync();
            var aapl = securities["AAPL"];
            var price = aapl[Field.RegularMarketPrice];
            Console.WriteLine(price);
        }

        [Test]
        public async Task Titel_suchen() {
            var autoCompletes = await Yahoo
                .AutoComplete("tesla")
                .SearchAsync();
            foreach (var ac in autoCompletes) {
                Console.WriteLine($"{ac.Symbol} - {ac.Name} - {ac.ExchangeShort} - {ac.ExchangeLong} - {ac.TypeShort} - {ac.TypeLong}");
            }
        }
    }
}