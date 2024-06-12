using System.Collections.Generic;
using mybooks.contracts;
using mybooks.logic;

namespace mybooks.integration
{
    public class Interactors
    {
        private readonly Booklending _booklending;

        public Interactors(Booklending booklending) {
            _booklending = booklending;
        }


        public IEnumerable<Book> Start() {
            var books = _booklending.LoadAll();
            return books;
        }

        public IEnumerable<Book> New_book(string title) {
            _booklending.Create_book(title);
            var books = _booklending.LoadAll();
            return books;
        }

        public IEnumerable<Book> Lend_book(long id, string name) {
            _booklending.Lend_book(id, name);
            var books = _booklending.LoadAll();
            return books;
        }

        public IEnumerable<Book> Return_book(long id) {
            _booklending.Return_book(id);
            var books = _booklending.LoadAll();
            return books;
        }

        public IEnumerable<Book> Remove_book(long id) {
            _booklending.Remove_book(id);
            var books = _booklending.LoadAll();
            return books;
        }
    }
}