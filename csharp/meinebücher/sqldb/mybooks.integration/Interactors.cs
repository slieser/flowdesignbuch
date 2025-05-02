using System.Collections.Generic;
using mybooks.contracts;
using mybooks.dbprovider;
using mybooks.logic;

namespace mybooks.integration
{
    public class Interactors(BooksRepository booksRepository, Booklending booklending)
    {
        public IEnumerable<Book> Start() {
            var books = booksRepository.LoadAll();
            return books;
        }

        public IEnumerable<Book> New_book(string title) {
            var book = booklending.Create_book(title);
            booksRepository.TryAdd(book);
            var books = booksRepository.LoadAll();
            return books;
        }

        public IEnumerable<Book> Lend_book(long id, string name) {
            var book = booksRepository.GetById(id);
            book = booklending.Lend_book(book, name);
            booksRepository.TryUpdate(book);
            var books = booksRepository.LoadAll();
            return books;
        }

        public IEnumerable<Book> Return_book(long id) {
            var book = booksRepository.GetById(id);
            book = booklending.Return_book(book);
            booksRepository.TryUpdate(book);
            var books = booksRepository.LoadAll();
            return books;
        }

        public IEnumerable<Book> Remove_book(long id) {
            booksRepository.TryDeleteById(id);
            var books = booksRepository.LoadAll();
            return books;
        }
    }
}