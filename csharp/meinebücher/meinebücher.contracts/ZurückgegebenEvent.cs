using System;

namespace meinebücher.contracts
{
    public class ZurückgegebenEvent : Event
    {
        public DateTime Rückgabedatum { get; set; }
    }
}