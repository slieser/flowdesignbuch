using System;
using System.Collections.Generic;
using System.Linq;
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

public IEnumerable<Aufgabe> Aufgaben_holen() {
    return _aufgaben;
}

public IEnumerable<Ergebnis> Ergebnisse_erstellen(IEnumerable<Aufgabe> aufgaben) {
    foreach (var aufgabe in aufgaben) {
        yield return Ergebnis_erstellen(aufgabe);
    }
}

private Ergebnis Ergebnis_erstellen(Aufgabe aufgabe) {
    return new Ergebnis {
        Frage = aufgabe.Frage,
        GegebeneAntwort = GegebeneAntwort(aufgabe),
        RichtigeAntwort = RichtigeAntwort(aufgabe),
        IstKorrekt = IstKorrekt(aufgabe)
    };
}

private static string GegebeneAntwort(Aufgabe aufgabe) {
    return aufgabe.Antwortmöglichkeiten.Find(a => a.IstGegeben).Antwort;
}

private static string RichtigeAntwort(Aufgabe aufgabe) {
    return aufgabe.Antwortmöglichkeiten.Find(a => a.IstKorrekt).Antwort;
}

private static bool IstKorrekt(Aufgabe aufgabe) {
    return aufgabe.Antwortmöglichkeiten.FirstOrDefault(a => a.IstKorrekt && a.IstGegeben) != null;
}

public (int anzahl, int richtig) Ergebnisse_zählen(IEnumerable<Ergebnis> ergebnisse) {
    var anzahl = ergebnisse.Count();
    var richtig = ergebnisse.Count(e => e.IstKorrekt);
    return (anzahl, richtig);
}

public Auswertung Auswertung_erstellen(IEnumerable<Ergebnis> ergebnisse, int anzahl, int richtig) {
    return new Auswertung {
        AnzahlAufgaben = anzahl,
        RichtigeAufgaben = richtig,
        Ergebnisse = ergebnisse.ToArray()
    };
}
    }
}