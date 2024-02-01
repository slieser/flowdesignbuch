using System;
using System.Collections.Generic;
using mystocks.data;
using mystocks.provider;

namespace mystocks
{
    public class Interactors
    {
        private readonly FavoritenProvider _favoritenProvider = new();
        private readonly IKursProvider _kursProvider;

        public Interactors() : this(new KursProvider()) {
        }

        internal Interactors(IKursProvider kursProvider) {
            _kursProvider = kursProvider;
        }

        public void Start(Action<IAsyncEnumerable<Wertpapier>> onUpdate) {
            new TimerProvider().ExecutePeriodic(30*1000, () => {
                var symbole = _favoritenProvider.FavoritenLaden();
                var wertpapiere = _kursProvider.KurseErmitteln(symbole);
                onUpdate(wertpapiere);
            });
        }

        public IAsyncEnumerable<Titel> TitelSuchen(string suchbegriff) {
            return _kursProvider.TitelSuchen(suchbegriff);
        }
        
        public IAsyncEnumerable<Wertpapier> TitelHinzufügen(string symbol) {
            var symbole = _favoritenProvider.FavoritenLaden();
            var alleSymbole = _favoritenProvider.FavoritHinzufügen(symbole, symbol);
            var wertpapiere = _kursProvider.KurseErmitteln(alleSymbole);
            return wertpapiere;
        }

        public IAsyncEnumerable<Wertpapier> TitelEntfernen(string symbol) {
            var symbole = _favoritenProvider.FavoritenLaden();
            var alleSymbole = _favoritenProvider.FavoritEntfernen(symbole, symbol);
            var wertpapiere = _kursProvider.KurseErmitteln(alleSymbole);
            return wertpapiere;
        }
    }
}