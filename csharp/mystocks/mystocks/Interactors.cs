using System;
using System.Collections.Generic;
using System.Linq;
using mystocks.data;
using mystocks.provider;

namespace mystocks
{
    public class Interactors
    {
        private readonly FavoritenProvider _favoritenProvider = new FavoritenProvider();
        private readonly IKursProvider _kursProvider;

        public Interactors() : this(new KursProvider()) {
        }

        internal Interactors(IKursProvider kursProvider) {
            _kursProvider = kursProvider;
        }

        public void Start(Action<IEnumerable<Wertpapier>> onUpdate) {
            new TimerProvider().ExecutePeriodic(30*1000, () => {
                var symbole = _favoritenProvider.FavoritenLaden();
                var wertpapiere = _kursProvider.KurseErmitteln(symbole).ToList();
                onUpdate(wertpapiere);
            });
        }

        public IEnumerable<Titel> TitelSuchen(string suchbegriff) {
            return _kursProvider.TitelSuchen(suchbegriff);
        }
        
        public IEnumerable<Wertpapier> TitelHinzufügen(string symbol) {
            var symbole = _favoritenProvider.FavoritenLaden();
            var alleSymbole = _favoritenProvider.FavoritHinzufügen(symbole, symbol);
            var wertpapiere = _kursProvider.KurseErmitteln(alleSymbole);
            return wertpapiere;
        }

        public IEnumerable<Wertpapier> TitelEntfernen(string symbol) {
            var symbole = _favoritenProvider.FavoritenLaden();
            var alleSymbole = _favoritenProvider.FavoritEntfernen(symbole, symbol);
            var wertpapiere = _kursProvider.KurseErmitteln(alleSymbole);
            return wertpapiere;
        }
    }
}