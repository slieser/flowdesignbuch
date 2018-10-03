namespace questionnaire.contracts
{
    public class Ergebnis
    {
        public string Frage { get; set; }

        public string GegebeneAntwort { get; set; }

        public string RichtigeAntwort { get; set; }

        public bool IstKorrekt { get; set; }
    }
}