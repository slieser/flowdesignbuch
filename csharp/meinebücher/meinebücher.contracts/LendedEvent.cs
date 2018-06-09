using System;

namespace mybooks.contracts
{
    public class LendedEvent : Event
    {
        public string Lender { get; set; }

        public DateTime LendingDate { get; set; }
    }
}