using System;

namespace mybooks.ui
{
    public class BookEntry
    {
        public string Title { get; set; }

        public string Lender { get; set; }

        public DateTime LendingDate { get; set; }

        public long Id { get; set; }
    }
}