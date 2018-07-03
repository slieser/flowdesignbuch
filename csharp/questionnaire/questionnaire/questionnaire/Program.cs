using System;

namespace questionnaire
{
    internal class Program
    {
        public static void Main(string[] args) {
            var aufgaben = Interactors.Start();
            foreach (var aufgabe in aufgaben) {
                Console.WriteLine($"Frage: {aufgabe.Frage}");
                foreach (var antwortmöglichkeit in aufgabe.Antwortmöglichkeiten) {
                    var korrekt = antwortmöglichkeit.IstKorrekt ? " (korrekt)" : "";
                    Console.WriteLine($" - {antwortmöglichkeit.Antwort}{korrekt}");
                }
            }
        }
    }
}