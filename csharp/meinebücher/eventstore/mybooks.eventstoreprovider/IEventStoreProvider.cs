using System.Collections.Generic;
using mybooks.contracts;

namespace mybooks.eventstoreprovider
{
    public interface IEventStoreProvider
    {
        IEnumerable<Event> Read_all_events();
        void Save_event(Event bookEvent);
    }
}