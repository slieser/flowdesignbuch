using System;
using System.Collections.Generic;
using questionnaire.contracts;

namespace questionnaire
{
    public class Fragebogen
    {
        private  Aufgabe[] _aufgaben;

        public void Aufgaben_setzen(Aufgabe[] aufgaben) {
            _aufgaben = aufgaben;
        }

        public Aufgabe Zugehörige_Aufgabe_finden(int id) {
            foreach (var aufgabe in _aufgaben) {
                foreach (var antwortmöglichkeit in aufgabe.Antwortmöglichkeiten) {
                    if (antwortmöglichkeit.Id == id) {
                        return aufgabe;
                    }
                }
            }
            throw new ArgumentOutOfRangeException($"Keine Antwortmöglichkeit mit Id = {id} gefunden.");
        }

        public void Alle_Antworten_zurücksetzen(Aufgabe aufgabe) {
            foreach (var antwortmöglichkeit in aufgabe.Antwortmöglichkeiten) {
                antwortmöglichkeit.IstGegeben = false;
            }
        }

        public void Antwort_setzen(Aufgabe aufgabe, int id) {
            foreach (var antwortmöglichkeit in aufgabe.Antwortmöglichkeiten) {
                if (antwortmöglichkeit.Id == id) {
                    antwortmöglichkeit.IstGegeben = true;
                }
            }
        }

        public (IEnumerable<Aufgabe> aufgaben, bool) Auswertbarkeit_ermitteln() {
            foreach (var aufgabe in _aufgaben) {
                var aufgabeIstAuswertbar = false;
                foreach (var antwortmöglichkeit in aufgabe.Antwortmöglichkeiten) {
                    if (antwortmöglichkeit.IstGegeben) {
                        aufgabeIstAuswertbar = true;
                    }
                }
                if (!aufgabeIstAuswertbar) {
                    return (_aufgaben, false);
                }
            }
            return (_aufgaben, true);
        }
    }
}