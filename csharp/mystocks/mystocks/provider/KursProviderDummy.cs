using System.Collections.Generic;
using System.Linq;
using mystocks.data;

namespace mystocks.provider
{
    public class KursProviderDummy : IKursProvider
    {
        private readonly List<Wertpapier> _wertpapiere = new List<Wertpapier>();

        public KursProviderDummy() {
            _wertpapiere.Add(new Wertpapier { Symbol="TSLA", Name="Tesla Inc."});
            _wertpapiere.Add(new Wertpapier { Symbol="AAPL", Name="Apple"});
            _wertpapiere.Add(new Wertpapier { Symbol="AMZN", Name="Amazon"});
        }

        public IAsyncEnumerable<Wertpapier> KurseErmitteln(IEnumerable<string> symbole) {
            return _wertpapiere
                .Where(w => symbole.Contains(w.Symbol.ToUpper()))
                .ToAsyncEnumerable();
        }

        public IAsyncEnumerable<Titel> TitelSuchen(string suchbegriff) {
            return _wertpapiere
                .Where(w => w.Symbol.ToLower().StartsWith(suchbegriff.ToLower()))
                .Select(t => new Titel { Name = t.Name, Symbol = t.Symbol })
                .ToAsyncEnumerable();
        }
    }
}