using System.Collections.Generic;

namespace questionnaire.contracts
{
    public class Aufgabe
    {
        public string Frage { get; set; }
        public List<Antwortmöglichkeit> Antwortmöglichkeiten { get; set; }
    }
}