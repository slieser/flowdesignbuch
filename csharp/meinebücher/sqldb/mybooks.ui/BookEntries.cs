using System.Collections.Generic;
using System.Linq;
using mybooks.contracts;

namespace mybooks.ui
{
    public class BookEntries : List<BookEntry>
    {
        public void Update(IEnumerable<Book> books) {
            var items = books.Select(book => new BookEntry
                {
                    Id = book.Id,
                    Title = book.Title,
                    Lender = book.Lender,
                    LendingDate = book.LendingDate
                });
            Clear();
            AddRange(items);
        }
    }
}