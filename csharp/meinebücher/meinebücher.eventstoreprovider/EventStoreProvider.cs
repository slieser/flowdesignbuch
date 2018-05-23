using System;
using System.Collections.Generic;
using meinebücher.contracts;
using NEventStore;

namespace meinebücher.eventstoreprovider
{
    public class EventStoreProvider
    {
        private readonly IStoreEvents store;

        public EventStoreProvider() {
            store = Wireup.Init()
                .UsingInMemoryPersistence()
                .UsingJsonSerialization()
                .Build();
        }

        public IEnumerable<Event> Lese_alle_Events() {
            using (var stream = store.OpenStream("bücher", 0)) {
                foreach (var e in stream.CommittedEvents) {
                    yield return (Event)e.Body;
                }
            }
        }

        public void Speichere_Event(Event buchEvent) {
            using (var stream = store.OpenStream("bücher", 0)) {
                stream.Add(new EventMessage { Body = buchEvent });
                stream.CommitChanges(Guid.NewGuid());
            }
        }
    }
}