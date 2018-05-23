using System;
using System.Windows;
using meinebücher.ui;

namespace meinebücher
{
    public static class Program
    {
        [STAThread]
        public static void Main() {
            var mainWindow = new MainWindow();
            var interactors = new Interactors();
            var app = new Application { MainWindow = mainWindow };

            void start() {
                var bücher = interactors.Start();
                mainWindow.Aktualisiere_Bücher(bücher);
            }

            mainWindow.Neues_Buch += titel => {
                var bücher = interactors.Neues_Buch(titel);
                mainWindow.Aktualisiere_Bücher(bücher);
            };
            mainWindow.Buch_verleihen += (id, name) => {
                var bücher = interactors.Buch_verleihen(id, name);
                mainWindow.Aktualisiere_Bücher(bücher);
            };
            mainWindow.Buch_zurückgeben += (id) => {
                var bücher = interactors.Buch_zurückgegeben(id);
                mainWindow.Aktualisiere_Bücher(bücher);
            };
            mainWindow.Buch_löschen += (id) => {
                var bücher = interactors.Buch_löschen(id);
                mainWindow.Aktualisiere_Bücher(bücher);
            };

            start();
            app.Run(mainWindow);
        }
    }
}