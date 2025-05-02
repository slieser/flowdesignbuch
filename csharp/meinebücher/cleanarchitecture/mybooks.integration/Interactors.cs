using System.Collections.Generic;
using mybooks.contracts;
using mybooks.logic;

namespace mybooks.integration
{
    public class Interactors(Booklending booklending)
    {
        public IEnumerable<Book> Start() {
            var books = booklending.LoadAll();
            return books;
        }

        public IEnumerable<Book> New_book(string title) {
            booklending.Create_book(title);
            var books = booklending.LoadAll();
            return books;
        }

        public IEnumerable<Book> Lend_book(long id, string name) {
            booklending.Lend_book(id, name);
            var books = booklending.LoadAll();
            return books;
        }

        public IEnumerable<Book> Return_book(long id) {
            booklending.Return_book(id);
            var books = booklending.LoadAll();
            return books;
        }

        public IEnumerable<Book> Remove_book(long id) {
            booklending.Remove_book(id);
            var books = booklending.LoadAll();
            return books;
        }
    }
}