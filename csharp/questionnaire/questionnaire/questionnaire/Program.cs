using System;
using System.Collections.Generic;
using System.Windows;
using questionnaire.contracts;
using questionnaire.ui;

namespace questionnaire
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args) {
            var ui = new FragebogenUi();
            var aufgaben = Interactors.Start();
            ui.Update(aufgaben);

            var app = new Application {MainWindow = ui};
            app.Run(ui);
        }

        private static void Show(IEnumerable<Aufgabe> aufgaben) {
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