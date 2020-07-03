using System.Collections.Generic;
using System.Linq;
using mystocks.data;
using YahooFinanceApi;

namespace mystocks.provider
{
    public class KursProvider
    {
        public IEnumerable<Wertpapier> KurseErmitteln(IEnumerable<string> symbole) {
            foreach (var symbol in symbole) {
                yield return KursErmitteln(symbol);
            }
        }

        private Wertpapier KursErmitteln(string symbol) {
            var securities = Yahoo
                .Symbols(symbol)
                .Fields(Field.LongName, Field.Symbol, Field.RegularMarketPrice, 
                    Field.RegularMarketChange, Field.RegularMarketChangePercent,
                    Field.Currency)
                .QueryAsync()
                .Result;
            var werte = securities[symbol];
            if (werte.QuoteType == "INDEX") {
                return new Wertpapier {
                    Name = werte.FullExchangeName,
                    Symbol = werte.Symbol,
                    Kurs = werte.RegularMarketPrice.ToString("0,0.00 ") + werte.Currency,
                    Absolut = werte.RegularMarketChange.ToString("0.00"),
                    Relativ = (werte.RegularMarketChangePercent / 100.0).ToString("0.0%")
                };
                
            }
            if (werte.QuoteType == "CURRENCY") {
                return new Wertpapier {
                    Name = werte.Currency,
                    Symbol = werte.Symbol,
                    Kurs = werte.RegularMarketPrice.ToString("0,0.00 ") + werte.Currency,
                    Absolut = werte.RegularMarketChange.ToString("0.00"),
                    Relativ = (werte.RegularMarketChangePercent / 100.0).ToString("0.0%")
                };
                
            }
            return new Wertpapier {
                Name = werte.LongName,
                Symbol = werte.Symbol,
                Kurs = werte.RegularMarketPrice.ToString("0,0.00 ") + werte.Currency,
                Absolut = werte.RegularMarketChange.ToString("0.00"),
                Relativ = (werte.RegularMarketChangePercent / 100.0).ToString("0.0%")
            };
        }

        public IEnumerable<Titel> TitelSuchen(string suchbegriff) {
            var autoCompletes = Yahoo
                .AutoComplete(suchbegriff)
                .SearchAsync()
                .Result;
            return autoCompletes.Select(ac => new Titel {
                Symbol = ac.Symbol,
                Name = ac.Name,
                Börse = ac.ExchangeLong
            });
        }
    }
}