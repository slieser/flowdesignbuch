using System;
using System.Collections.Generic;
using mybooks.contracts;
using mybooks.eventstoreprovider;
using mybooks.logic;

namespace mybooks
{
    public class Interactors
    {
        private readonly EventStoreProvider _eventStoreProvider = 
            new EventStoreProvider();
        private readonly Booklending _booklending = 
            new Booklending();

        public IEnumerable<Book> Start() {
            var events = _eventStoreProvider.Read_all_events();
            var books = _booklending.Create_list_of_books(events);
            return books;
        }

        public IEnumerable<Book> New_book(string titel) {
            var bookCreatedEvent = _booklending.Create_book(titel);
            _eventStoreProvider.Save_event(bookCreatedEvent);
            var events = _eventStoreProvider.Read_all_events();
            var books = _booklending.Create_list_of_books(events);
            return books;
        }

        public IEnumerable<Book> Lend_book(Guid id, string name) {
            var bookLendedEvent = _booklending.Lend_book(id, name);
            _eventStoreProvider.Save_event(bookLendedEvent);
            var events = _eventStoreProvider.Read_all_events();
            var books = _booklending.Create_list_of_books(events);
            return books;
        }

        public IEnumerable<Book> Book_got_back(Guid id) {
            var bookReturnedEvent = _booklending.Return_book(id);
            _eventStoreProvider.Save_event(bookReturnedEvent);
            var events = _eventStoreProvider.Read_all_events();
            var books = _booklending.Create_list_of_books(events);
            return books;
        }

        public IEnumerable<Book> Remove_book(Guid id) {
            var bookDeletedEvent = _booklending.Delete_book(id);
            _eventStoreProvider.Save_event(bookDeletedEvent);
            var events = _eventStoreProvider.Read_all_events();
            var books = _booklending.Create_list_of_books(events);
            return books;
        }
    }
}