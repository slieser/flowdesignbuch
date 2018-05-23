using System;
using System.Collections.Generic;
using meinebücher.contracts;
using meinebücher.eventstoreprovider;
using meinebücher.logic;

namespace meinebücher
{
    public class Interactors
    {
        private readonly EventStoreProvider eventStoreProvider = new EventStoreProvider();
        private readonly Buchverleih buchverleih = new Buchverleih();

        public IEnumerable<Buch> Start() {
            var events = eventStoreProvider.Lese_alle_Events();
            var bücher = buchverleih.Erstelle_Buchliste(events);
            return bücher;
        }

        public IEnumerable<Buch> Neues_Buch(string titel) {
            var buchAngelegtEvent = buchverleih.Buch_anlegen(titel);
            eventStoreProvider.Speichere_Event(buchAngelegtEvent);
            var events = eventStoreProvider.Lese_alle_Events();
            var bücher = buchverleih.Erstelle_Buchliste(events);
            return bücher;
        }

        public IEnumerable<Buch> Buch_verleihen(Guid id, string name) {
            var buchVerliehenEvent = buchverleih.Buch_verleihen(id, name);
            eventStoreProvider.Speichere_Event(buchVerliehenEvent);
            var events = eventStoreProvider.Lese_alle_Events();
            var bücher = buchverleih.Erstelle_Buchliste(events);
            return bücher;
        }

        public IEnumerable<Buch> Buch_zurückgegeben(Guid id) {
            var buchZurückgegebenEvent = buchverleih.Buch_zurückgeben(id);
            eventStoreProvider.Speichere_Event(buchZurückgegebenEvent);
            var events = eventStoreProvider.Lese_alle_Events();
            var bücher = buchverleih.Erstelle_Buchliste(events);
            return bücher;
        }

        public IEnumerable<Buch> Buch_löschen(Guid id) {
            var buchGelöschtEvent = buchverleih.Buch_löschen(id);
            eventStoreProvider.Speichere_Event(buchGelöschtEvent);
            var events = eventStoreProvider.Lese_alle_Events();
            var bücher = buchverleih.Erstelle_Buchliste(events);
            return bücher;
        }
    }
}