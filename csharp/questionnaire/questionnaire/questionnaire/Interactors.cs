using System.Collections.Generic;
using questionnaire.contracts;
using questionnaire.ressources;

namespace questionnaire
{
    public class Interactors
    {
        public static IEnumerable<Aufgabe> Start() {
            var zeilen = FragebogenProvider.Fragebogendatei_einlesen();
            var gruppierteZeilen = FragebogenProvider.Nach_Aufgaben_gruppieren(zeilen);
            var aufgaben = FragebogenProvider.Aufgaben_erstellen(gruppierteZeilen);
            return aufgaben;
        }
    }
}