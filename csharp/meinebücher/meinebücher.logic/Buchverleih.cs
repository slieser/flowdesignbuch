using System;
using System.Collections.Generic;
using meinebücher.contracts;

namespace meinebücher.logic
{
    public class Buchverleih
    {
        public IEnumerable<Book> Erstelle_Buchliste(IEnumerable<Event> events) {
            var result = new List<Book>();
            foreach (var buchEvent in events) {
                EventAusführen(buchEvent, result);
            }
            return result;
        }

        private void EventAusführen(Event buchEvent, List<Book> buchliste) {
            if (buchEvent.GetType() == typeof(AngelegtEvent)) {
                var e = (AngelegtEvent)buchEvent;
                var neuesBuch = new Book {
                    CorrelationId = e.CorrelationId,
                    Title = e.Titel,
                    Lender = "",
                    IstAusleihbar = true
                };
                buchliste.Add(neuesBuch);
            }
            if (buchEvent.GetType() == typeof(VerliehenEvent)) {
                var e = (VerliehenEvent)buchEvent;
                var buch = buchliste.Find(b => b.CorrelationId == e.CorrelationId);
                buch.Lender = e.Ausleiher;
                buch.LendingDate = e.Leihdatum;
                buch.IstAusleihbar = false;
            }
            if (buchEvent.GetType() == typeof(ZurückgegebenEvent)) {
                var e = (ZurückgegebenEvent)buchEvent;
                var buch = buchliste.Find(b => b.CorrelationId == e.CorrelationId);
                buch.Lender = "";
                buch.LendingDate = DateTime.MinValue;
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