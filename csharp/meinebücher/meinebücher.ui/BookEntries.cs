using System.Collections.Generic;
using System.Linq;
using meinebücher.contracts;

namespace meinebücher.ui
{
    public class BookEntries : List<BookEntry>
    {
        public void Update(IEnumerable<Book> books) {
            var items = books.Select(book => new BookEntry
                {
                    Id = book.CorrelationId,
                    Title = book.Title,
                    Lender = book.Lender,
                    LendingDate = book.LendingDate
                });
            Clear();
            AddRange(items);
        }
    }
}