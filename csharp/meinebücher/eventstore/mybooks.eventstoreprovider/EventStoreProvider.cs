using System;
using System.Collections.Generic;
using mybooks.contracts;
using NEventStore;
using NEventStore.Serialization.Json;

namespace mybooks.eventstoreprovider
{
    public class EventStoreProvider : IEventStoreProvider
    {
        private readonly IStoreEvents _store;

        public EventStoreProvider() {
            _store = Wireup.Init()
                .UsingInMemoryPersistence()
                .UsingJsonSerialization()
                .Build();
        }

        public IEnumerable<Event> Read_all_events() {
            using var stream = _store.OpenStream("books", 0);
            foreach (var e in stream.CommittedEvents) {
                yield return (Event)e.Body;
            }
        }

        public void Save_event(Event bookEvent) {
            using var stream = _store.OpenStream("books", 0);
            stream.Add(new EventMessage { Body = bookEvent });
            stream.CommitChanges(Guid.NewGuid());
        }
    }
}