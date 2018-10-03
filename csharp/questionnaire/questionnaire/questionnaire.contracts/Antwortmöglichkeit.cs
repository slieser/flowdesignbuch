namespace questionnaire.contracts
{
    public class Antwortmöglichkeit
    {
        public bool IstKorrekt { get; set; }

        public bool IstGegeben { get; set; }

        public string Antwort { get; set; }

        public int Id { get; set; }
    }
}