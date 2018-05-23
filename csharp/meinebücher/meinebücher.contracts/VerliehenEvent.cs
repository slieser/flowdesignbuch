using System;

namespace meinebücher.contracts
{
    public class VerliehenEvent : Event
    {
        public string Ausleiher { get; set; }

        public DateTime Leihdatum { get; set; }
    }
}