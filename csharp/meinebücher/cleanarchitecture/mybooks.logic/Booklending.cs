using System;
using System.Collections.Generic;
using mybooks.contracts;
using mybooks.dbprovider;

namespace mybooks.logic
{
    public class Booklending
    {
        private readonly IBooksRepository _booksRepository;

        public Booklending(IBooksRepository booksRepository) {
            _booksRepository = booksRepository;
        }

        public Book Create_book(string title) {
            var book = new Book {
                Title = title,
                Lender = "",
                LendingDate = DateTime.MinValue,
                CanBeLended = true
            };
            _booksRepository.TryAdd(book);
            return book;
        }

        public Book Lend_book(long id, string name) {
            var book = _booksRepository.GetById(id);
            book.Lender = name;
            book.LendingDate = DateTime.Now;
            book.CanBeLended = false;
            _booksRepository.TryUpdate(book);
            return book;
        }

        public Book Return_book(long id) {
            var book = _booksRepository.GetById(id);
            book.Lender = "";
            book.LendingDate = DateTime.MinValue;
            book.CanBeLended = true;
            _booksRepository.TryUpdate(book);
            return book;
        }

        public IEnumerable<Book> LoadAll() {
            return _booksRepository.LoadAll();
        }

        public void Remove_book(long id) {
            _booksRepository.TryDeleteById(id);
        }
    }
}