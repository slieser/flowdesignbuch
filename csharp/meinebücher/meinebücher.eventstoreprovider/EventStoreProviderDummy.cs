using System;
using System.Collections.Generic;
using meinebücher.contracts;

namespace meinebücher.eventstoreprovider
{
    public class EventStoreProviderDummy
    {
        private List<Event> events = new List<Event> {
            new AngelegtEvent {
                CorrelationId = Guid.NewGuid(),
                Timestamp = new DateTime(2010, 1, 1),
                Titel = "Visual C# 2010"
            },
            new AngelegtEvent {
                CorrelationId = Guid.NewGuid(),
                Timestamp = new DateTime(2008, 2, 4),
                Titel = "Visual C# 2008"
            }
        };

        public IEnumerable<Event> Lese_alle_Events() {
            return events;
        }

        public void Speichere_Event(Event buchEvent) {
            events.Add(buchEvent);
        }
    }
}