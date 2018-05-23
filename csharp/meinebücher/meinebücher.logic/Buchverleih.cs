using System;
using System.Collections.Generic;
using meinebücher.contracts;

namespace meinebücher.logic
{
    public class Buchverleih
    {
        public IEnumerable<Buch> Erstelle_Buchliste(IEnumerable<Event> events) {
            var result = new List<Buch>();
            foreach (var buchEvent in events) {
                EventAusführen(buchEvent, result);
            }
            return result;
        }

        private void EventAusführen(Event buchEvent, List<Buch> buchliste) {
            if (buchEvent.GetType() == typeof(AngelegtEvent)) {
                var e = (AngelegtEvent)buchEvent;
                var neuesBuch = new Buch {
                    CorrelationId = e.CorrelationId,
                    Titel = e.Titel,
                    Ausleiher = "",
                    IstAusleihbar = true
                };
                buchliste.Add(neuesBuch);
            }
            if (buchEvent.GetType() == typeof(VerliehenEvent)) {
                var e = (VerliehenEvent)buchEvent;
                var buch = buchliste.Find(b => b.CorrelationId == e.CorrelationId);
                buch.Ausleiher = e.Ausleiher;
                buch.Leihdatum = e.Leihdatum;
                buch.IstAusleihbar = false;
            }
            if (buchEvent.GetType() == typeof(ZurückgegebenEvent)) {
                var e = (ZurückgegebenEvent)buchEvent;
                var buch = buchliste.Find(b => b.CorrelationId == e.CorrelationId);
                buch.Ausleiher = "";
                buch.Leihdatum = DateTime.MinValue;
                buch.IstAusleihbar = true;
            }
            if (buchEvent.GetType() == typeof(GelöschtEvent)) {
                var e = (GelöschtEvent)buchEvent;
                buchliste.RemoveAll(b => b.CorrelationId == e.CorrelationId);
            }
        }

        public AngelegtEvent Buch_anlegen(string titel) {
            return new AngelegtEvent {
                CorrelationId = Guid.NewGuid(),
                Timestamp = DateTime.Today,
                Titel = titel
            };
        }

        public VerliehenEvent Buch_verleihen(Guid id, string name) {
            return new VerliehenEvent {
                CorrelationId = id,
                Ausleiher = name,
                Timestamp = DateTime.Today,
                Leihdatum = DateTime.Today
            };
        }

        public ZurückgegebenEvent Buch_zurückgeben(Guid id) {
            return new ZurückgegebenEvent {
                CorrelationId = id,
                Timestamp = DateTime.Today,
                Rückgabedatum = DateTime.Today
            };
        }

        public GelöschtEvent Buch_löschen(Guid id) {
            return new GelöschtEvent {
                CorrelationId = id,
                Timestamp = DateTime.Today,
                Löschdatum = DateTime.Today
            };
        }
    }
}