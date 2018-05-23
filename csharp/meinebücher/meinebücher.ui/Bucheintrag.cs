using System;

namespace meinebücher.ui
{
    public class Bucheintrag
    {
        public string Titel { get; set; }

        public string Ausleiher { get; set; }

        public DateTime Leihdatum { get; set; }

        public Guid Id { get; set; }
    }
}