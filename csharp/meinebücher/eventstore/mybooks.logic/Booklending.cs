using System;
using System.Collections.Generic;
using mybooks.contracts;

namespace mybooks.logic
{
    public class Booklending
    {
        public IEnumerable<Book> Create_list_of_books(IEnumerable<Event> events) {
            var result = new List<Book>();
            foreach (var bookEvent in events) {
                ExecuteEvent(bookEvent, result);
            }
            return result;
        }

        private void ExecuteEvent(Event bookEvent, List<Book> books) {
            if (bookEvent.GetType() == typeof(CreatedEvent)) {
                var e = (CreatedEvent)bookEvent;
                var newBook = new Book {
                    CorrelationId = e.CorrelationId,
                    Title = e.Title,
                    Lender = "",
                    CanBeLended = true
                };
                books.Add(newBook);
            }
            if (bookEvent.GetType() == typeof(LendedEvent)) {
                var e = (LendedEvent)bookEvent;
                var book = books.Find(b => b.CorrelationId == e.CorrelationId);
                book.Lender = e.Lender;
                book.LendingDate = e.LendingDate;
                book.CanBeLended = false;
            }
            if (bookEvent.GetType() == typeof(ReturnedEvent)) {
                var e = (ReturnedEvent)bookEvent;
                var book = books.Find(b => b.CorrelationId == e.CorrelationId);
                book.Lender = "";
                book.LendingDate = DateTime.MinValue;
                book.CanBeLended = true;
            }
            if (bookEvent.GetType() == typeof(DeletedEvent)) {
                var e = (DeletedEvent)bookEvent;
                books.RemoveAll(b => b.CorrelationId == e.CorrelationId);
            }
        }

        public CreatedEvent Create_book(string title) {
            return new CreatedEvent {
                CorrelationId = Guid.NewGuid(),
                Timestamp = DateTime.Today,
                Title = title
            };
        }

        public LendedEvent Lend_book(Guid id, string lenderName) {
            return new LendedEvent {
                CorrelationId = id,
                Lender = lenderName,
                Timestamp = DateTime.Today,
                LendingDate = DateTime.Today
            };
        }

        public ReturnedEvent Return_book(Guid id) {
            return new ReturnedEvent {
                CorrelationId = id,
                Timestamp = DateTime.Today,
                ReturnedDate = DateTime.Today
            };
        }

        public DeletedEvent Delete_book(Guid id) {
            return new DeletedEvent {
                CorrelationId = id,
                Timestamp = DateTime.Today,
                DeletionDate = DateTime.Today
            };
        }
    }
}