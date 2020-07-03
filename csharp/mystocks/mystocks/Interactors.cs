using System;
using System.Collections.Generic;
using mystocks.data;
using mystocks.provider;

namespace mystocks
{
    public class Interactors
    {
        private readonly FavoritenProvider _favoritenProvider = new FavoritenProvider();
        private readonly KursProvider _kursProvider = new KursProvider();

        public void Start(Action<IEnumerable<Wertpapier>> onUpdate) {
            new TimerProvider().ExecutePeriodic(30*1000, () => {
                var symbole = _favoritenProvider.FavoritenLaden();
                var wertpapiere = _kursProvider.KurseErmitteln(symbole);
                onUpdate(wertpapiere);
            });
        }

        public IEnumerable<Titel> TitelSuchen(string suchbegriff) {
            return _kursProvider.TitelSuchen(suchbegriff);
        }
        
        public IEnumerable<Wertpapier> TitelHinzufügen(string symbol) {
            var symbole = _favoritenProvider.FavoritenLaden();
            var alleSymbole = _favoritenProvider.FavoritHinzufügen(
                symbole, symbol, s => _favoritenProvider.FavoritenSpeichern(s));
            var wertpapiere = _kursProvider.KurseErmitteln(alleSymbole);
            return wertpapiere;
        }
    }
}