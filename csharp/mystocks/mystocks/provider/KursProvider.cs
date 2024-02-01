using System.Collections.Generic;
using System.Threading.Tasks;
using AlphaVantage.Net.Core.Client;
using AlphaVantage.Net.Stocks.Client;
using mystocks.data;

namespace mystocks.provider
{
    public class KursProvider : IKursProvider
    {
        public async IAsyncEnumerable<Wertpapier> KurseErmitteln(IEnumerable<string> symbole) {
            foreach (var symbol in symbole) {
                yield return await KursErmitteln(symbol);
            }
        }

        private async Task<Wertpapier> KursErmitteln(string symbol) {
            var apiKey = "1";
            using var client = new AlphaVantageClient(apiKey);
            using var stocksClient = client.Stocks();        
            var globalQuote = await stocksClient.GetGlobalQuoteAsync(symbol);
            return new Wertpapier {
                Symbol = globalQuote.Symbol,
                Name = "???",
                Börse = "???",
                Kurs = globalQuote.Price.ToString(),
                Absolut = globalQuote.Change.ToString(),
                Relativ = globalQuote.ChangePercent.ToString()
            };
        }

        public async IAsyncEnumerable<Titel> TitelSuchen(string suchbegriff) {
            var apiKey = "1";
            using var client = new AlphaVantageClient(apiKey);
            using var stocksClient = client.Stocks();
            var searchResult = await stocksClient.SearchSymbolAsync(suchbegriff);
            foreach (var match in searchResult) {
                yield return new Titel {
                    Symbol = match.Symbol,
                    Name = match.Name,
                    Börse = match.Region
                };
            }
        }
    }
}