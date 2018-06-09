using System;

namespace mybooks.contracts
{
    public class Book
    {
        public Guid CorrelationId { get; set; }

        public string Title { get; set; }

        public string Lender { get; set; }

        public DateTime LendingDate { get; set; }

        public bool CanBeLended { get; set; }
    }
}