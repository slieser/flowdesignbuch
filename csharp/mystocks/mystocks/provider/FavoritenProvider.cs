using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace mystocks.provider
{
    public class FavoritenProvider
    {
        private const string Filename = "favoriten.config";

        public IEnumerable<string> FavoritenLaden() {
            if (!File.Exists(Filename)) {
                File.WriteAllLines(Filename, new string[0]);
            }

            return File.ReadAllLines(Filename);
        }
        
        public void FavoritenSpeichern(IEnumerable<string> symbole) {
            File.WriteAllLines(Filename, symbole);
        }

        public IEnumerable<string> FavoritHinzufügen(IEnumerable<string> symbole, string symbol, Action<IEnumerable<string>> onChange) {
            if (symbole.Any(s => s.Equals(symbol, StringComparison.CurrentCultureIgnoreCase))) {
                return symbole;
            }

            var alleSymbole = new List<string>(symbole) {
                symbol
            };
            onChange(alleSymbole);
            return alleSymbole;
        }

        public IEnumerable<string> FavoritEntfernen(IEnumerable<string> symbole, string symbol, Action<IEnumerable<string>> onChange) {
            if (!symbole.Any(s => s.Equals(symbol, StringComparison.CurrentCultureIgnoreCase))) {
                return symbole;
            }

            var alleSymbole = symbole.ToList();
            alleSymbole.Remove(symbol);
            onChange(alleSymbole);
            return alleSymbole;
        }
    }
}