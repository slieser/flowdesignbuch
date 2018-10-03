namespace questionnaire.contracts
{
    public class Auswertung
    {
        public int AnzahlAufgaben { get; set; }

        public int RichtigeAufgaben { get; set; }

        public Ergebnis[] Ergebnisse { get; set; }
    }
}