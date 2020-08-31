using System;
using System.Collections.Generic;
using mybooks.contracts;
using NEventStore;

namespace mybooks.eventstoreprovider
{
    public class EventStoreProvider : IEventStoreProvider
    {
        private readonly IStoreEvents store;

        public EventStoreProvider() {
            store = Wireup.Init()
                .UsingInMemoryPersistence()
                .UsingJsonSerialization()
                .Build();
        }

        public IEnumerable<Event> Read_all_events() {
            using (var stream = store.OpenStream("books", 0)) {
                foreach (var e in stream.CommittedEvents) {
                    yield return (Event)e.Body;
                }
            }
        }

        public void Save_event(Event bookEvent) {
            using (var stream = store.OpenStream("books", 0)) {
                stream.Add(new EventMessage { Body = bookEvent });
                stream.CommitChanges(Guid.NewGuid());
            }
        }
    }
}