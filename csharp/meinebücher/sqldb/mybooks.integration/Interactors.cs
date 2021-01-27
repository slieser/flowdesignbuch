using System.Collections.Generic;
using mybooks.contracts;
using mybooks.dbprovider;
using mybooks.logic;

namespace mybooks.integration
{
    public class Interactors
    {
        private readonly BooksRepository _booksRepository;
        private readonly Booklending _booklending = new Booklending();

        public Interactors(BooksRepository booksRepository) {
            _booksRepository = booksRepository;
        }

        public IEnumerable<Book> Start() {
            var books = _booksRepository.LoadAll();
            return books;
        }

        public IEnumerable<Book> New_book(string title) {
            var book = _booklending.Create_book(title);
            _booksRepository.TryAdd(book);
            var books = _booksRepository.LoadAll();
            return books;
        }

        public IEnumerable<Book> Lend_book(long id, string name) {
            var book = _booksRepository.GetById(id);
            book = _booklending.Lend_book(book, name);
            _booksRepository.TryUpdate(book);
            var books = _booksRepository.LoadAll();
            return books;
        }

        public IEnumerable<Book> Return_book(long id) {
            var book = _booksRepository.GetById(id);
            book = _booklending.Return_book(book);
            _booksRepository.TryUpdate(book);
            var books = _booksRepository.LoadAll();
            return books;
        }

        public IEnumerable<Book> Remove_book(long id) {
            _booksRepository.TryDeleteById(id);
            var books = _booksRepository.LoadAll();
            return books;
        }
    }
}