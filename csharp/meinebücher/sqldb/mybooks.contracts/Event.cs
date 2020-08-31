using System;

namespace mybooks.contracts
{
    public class Event
    {
        public Guid CorrelationId { get; set; }

        public DateTime Timestamp { get; set; }
    }
}