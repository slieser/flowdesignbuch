using System;
using System.Collections.Generic;
using mybooks.contracts;
using mybooks.eventstoreprovider;
using mybooks.logic;

namespace mybooks
{
    public class Interactors
    {
        private readonly EventStoreProvider eventStoreProvider = new EventStoreProvider();
        private readonly Booklending _booklending = new Booklending();

        public IEnumerable<Book> Start() {
            var events = eventStoreProvider.Read_all_events();
            var bücher = _booklending.Create_list_of_books(events);
            return bücher;
        }

        public IEnumerable<Book> New_book(string titel) {
            var buchAngelegtEvent = _booklending.Create_book(titel);
            eventStoreProvider.Save_event(buchAngelegtEvent);
            var events = eventStoreProvider.Read_all_events();
            var bücher = _booklending.Create_list_of_books(events);
            return bücher;
        }

        public IEnumerable<Book> Lend_book(Guid id, string name) {
            var buchVerliehenEvent = _booklending.Lend_book(id, name);
            eventStoreProvider.Save_event(buchVerliehenEvent);
            var events = eventStoreProvider.Read_all_events();
            var bücher = _booklending.Create_list_of_books(events);
            return bücher;
        }

        public IEnumerable<Book> Book_got_back(Guid id) {
            var buchZurückgegebenEvent = _booklending.Return_book(id);
            eventStoreProvider.Save_event(buchZurückgegebenEvent);
            var events = eventStoreProvider.Read_all_events();
            var bücher = _booklending.Create_list_of_books(events);
            return bücher;
        }

        public IEnumerable<Book> Remove_book(Guid id) {
            var buchGelöschtEvent = _booklending.Delete_book(id);
            eventStoreProvider.Save_event(buchGelöschtEvent);
            var events = eventStoreProvider.Read_all_events();
            var bücher = _booklending.Create_list_of_books(events);
            return bücher;
        }
    }
}