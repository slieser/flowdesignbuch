using System;

namespace mybooks.contracts
{
    public class DeletedEvent : Event
    {
        public DateTime DeletionDate { get; set; }
    }
}