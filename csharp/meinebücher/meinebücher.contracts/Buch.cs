using System;

namespace meinebücher.contracts
{
    public class Buch
    {
        public Guid CorrelationId { get; set; }

        public string Titel { get; set; }

        public string Ausleiher { get; set; }

        public DateTime Leihdatum { get; set; }

        public bool IstAusleihbar { get; set; }
    }
}