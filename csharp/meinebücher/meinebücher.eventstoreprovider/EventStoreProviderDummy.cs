using System;
using System.Collections.Generic;
using mybooks.contracts;

namespace mybooks.eventstoreprovider
{
    public class EventStoreProviderDummy
    {
        private readonly List<Event> _events = new List<Event> {
            new CreatedEvent {
                CorrelationId = Guid.NewGuid(),
                Timestamp = new DateTime(2010, 1, 1),
                Title = "Visual C# 2010"
            },
            new CreatedEvent {
                CorrelationId = Guid.NewGuid(),
                Timestamp = new DateTime(2008, 2, 4),
                Title = "Visual C# 2008"
            }
        };

        public IEnumerable<Event> Read_all_events() {
            return _events;
        }

        public void Save_event(Event bookEvent) {
            _events.Add(bookEvent);
        }
    }
}