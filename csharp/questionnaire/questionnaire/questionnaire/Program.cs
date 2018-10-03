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
            var interactors = new Interactors();

            void Start() {
                var (aufgaben, auswertbar) = interactors.Start();
                ui.Update(aufgaben, auswertbar);
            }

            ui.Antwort_gegeben += id => {
                var (aufgaben, auswertbar) = interactors.Antwort_gegeben(id);
                ui.Update(aufgaben, auswertbar);
            };

            ui.Auswerten += () => {
                var auswertung = interactors.Auswerten();

            };

            Start();
            var app = new Application{MainWindow = ui};
            app.Run(ui);
        }

        private static void Show(IEnumerable<Aufgabe> aufgaben, bool auswertbar) {
            foreach (var aufgabe in aufgaben) {
                Console.WriteLine($"Frage: {aufgabe.Frage}");
                foreach (var antwortmöglichkeit in aufgabe.Antwortmöglichkeiten) {
                    var korrekt = antwortmöglichkeit.IstKorrekt ? " (korrekt)" : "";
                    Console.WriteLine($" - {antwortmöglichkeit.Antwort}{korrekt}");
                }
            }
            Console.WriteLine(auswertbar ? "Auswertbar" : "Nicht auswertbar");
        }
    }
}