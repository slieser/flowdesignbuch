using System;
using mybooks.contracts;

namespace mybooks.logic
{
    public class Booklending
    {
        public Book Create_book(string title) {
            return new Book {
                Title = title,
                Lender = "",
                LendingDate = DateTime.MinValue,
                CanBeLended = true
            };
        }

        public Book Lend_book(Book book, string name) {
            book.Lender = name;
            book.LendingDate = DateTime.Now;
            book.CanBeLended = false;
            return book;
        }

        public Book Return_book(Book book) {
            book.Lender = "";
            book.LendingDate = DateTime.MinValue;
            book.CanBeLended = true;
            return book;
        }
    }
}