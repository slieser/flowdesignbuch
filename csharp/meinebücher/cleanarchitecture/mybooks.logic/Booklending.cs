using System;
using System.Collections.Generic;
using mybooks.contracts;

namespace mybooks.logic
{
    public class Booklending(IBooksRepository booksRepository)
    {
        public Book Create_book(string title) {
            var book = new Book {
                Title = title,
                Lender = "",
                LendingDate = DateTime.MinValue,
                CanBeLended = true
            };
            booksRepository.TryAdd(book);
            return book;
        }

        public Book Lend_book(long id, string name) {
            var book = booksRepository.GetById(id);
            book.Lender = name;
            book.LendingDate = DateTime.Now;
            book.CanBeLended = false;
            booksRepository.TryUpdate(book);
            return book;
        }

        public Book Return_book(long id) {
            var book = booksRepository.GetById(id);
            book.Lender = "";
            book.LendingDate = DateTime.MinValue;
            book.CanBeLended = true;
            booksRepository.TryUpdate(book);
            return book;
        }

        public IEnumerable<Book> LoadAll() {
            return booksRepository.LoadAll();
        }

        public void Remove_book(long id) {
            booksRepository.TryDeleteById(id);
        }
    }
}