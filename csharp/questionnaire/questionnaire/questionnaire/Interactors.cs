using System.Collections.Generic;
using System.Linq;
using questionnaire.contracts;
using questionnaire.ressources;

namespace questionnaire
{
    public class Interactors
    {
        private Fragebogen _fragebogen = new Fragebogen();

        public (IEnumerable<Aufgabe> aufgaben, bool auswertbar) Start() {
            var zeilen = FragebogenProvider.Fragebogendatei_einlesen();
            var gruppierteZeilen = FragebogenProvider.Nach_Aufgaben_gruppieren(zeilen);
            var aufgaben = FragebogenProvider.Aufgaben_erstellen(gruppierteZeilen).ToArray();
            FragebogenProvider.Weiß_nicht_ergänzen(aufgaben);
            FragebogenProvider.Ids_zuweisen(aufgaben);
            _fragebogen.Aufgaben_setzen(aufgaben);
            return (aufgaben, false);
        }

        public (IEnumerable<Aufgabe> aufgaben, bool auswertbar) Antwort_gegeben(int id) {
            var aufgabe = _fragebogen.Zugehörige_Aufgabe_finden(id);
            _fragebogen.Alle_Antworten_zurücksetzen(aufgabe);
            _fragebogen.Antwort_setzen(aufgabe, id);
            var (aufgaben, auswertbar) = _fragebogen.Auswertbarkeit_ermitteln();
            return (aufgaben, auswertbar);
        }

        public Auswertung Auswerten() {
            var aufgaben = _fragebogen.Aufgaben_holen();
            var ergebnisse = _fragebogen.Ergebnisse_erstellen(aufgaben);
            var (anzahl, richtig) = _fragebogen.Ergebnisse_zählen(ergebnisse);
            return _fragebogen.Auswertung_erstellen(ergebnisse, anzahl, richtig);
        }
    }
}