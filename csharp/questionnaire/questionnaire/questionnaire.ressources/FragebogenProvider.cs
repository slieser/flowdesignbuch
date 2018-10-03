using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using questionnaire.contracts;

namespace questionnaire.ressources
{
    public static class FragebogenProvider
    {
        public static IEnumerable<string> Fragebogendatei_einlesen() {
            return File.ReadAllLines("questionnaire.txt");
        }

        public static IEnumerable<IEnumerable<string>> Nach_Aufgaben_gruppieren(IEnumerable<string> zeilen) {
            var result = new List<string>();
            foreach (var zeile in zeilen) {
                if (zeile.StartsWith("?")) {
                    if (result.Count > 0) {
                        yield return result;
                        result = new List<string>();
                    }
                    result.Add(zeile.Substring(1) + "?");
                }
                else {
                    result.Add(zeile);
                }
            }
            if (result.Count > 0) {
                yield return result;
            }
        }

        public static IEnumerable<Aufgabe> Aufgaben_erstellen(IEnumerable<IEnumerable<string>> gruppierteZeilen) {
            foreach (var gruppe in gruppierteZeilen) {
                yield return Aufgaben_erstellen(gruppe);
            }
        }

        private static Aufgabe Aufgaben_erstellen(IEnumerable<string> zeilenEinerAufgabe) {
            var result = new Aufgabe();
            result.Frage = zeilenEinerAufgabe.First();
            result.Antwortmöglichkeiten = Antwortmöglichkeiten_erstellen(zeilenEinerAufgabe.Skip(1));
            return result;
        }

        private static List<Antwortmöglichkeit> Antwortmöglichkeiten_erstellen(IEnumerable<string> zeilen) {
            var result = new List<Antwortmöglichkeit>();
            foreach (var zeile in zeilen) {
                var antwortmöglichkeit = new Antwortmöglichkeit();
                if (zeile.StartsWith("*")) {
                    antwortmöglichkeit.IstKorrekt = true;
                }
                antwortmöglichkeit.Antwort = zeile.TrimStart('*');
                result.Add(antwortmöglichkeit);
            }
            return result;
        }

        public static void Ids_zuweisen(IEnumerable<Aufgabe> aufgaben) {
            var id = 0;
            foreach (var aufgabe in aufgaben) {
                foreach (var antwortmöglichkeit in aufgabe.Antwortmöglichkeiten) {
                    antwortmöglichkeit.Id = ++id;
                }
            }
        }

        public static void Weiß_nicht_ergänzen(Aufgabe[] aufgaben) {
            foreach (var aufgabe in aufgaben) {
                aufgabe.Antwortmöglichkeiten.Add(new Antwortmöglichkeit{
                    Antwort = "Weiß nicht"
                });
            }
        }
    }
}