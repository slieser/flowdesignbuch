using System;

namespace meinebücher.contracts
{
    public class GelöschtEvent : Event
    {
        public DateTime Löschdatum { get; set; }
    }
}