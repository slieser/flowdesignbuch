using System;
using System.Windows;
using wecker.gui;

namespace wecker.app
{
    public static class Program
    {
        [STAThread]
        public static void Main() {
            var mainWindow = new MainWindow();
            var interactors = new Interactors();

            interactors.Start(
                istGestartet => mainWindow.Neuer_Zustand(istGestartet),
                uhrzeit => mainWindow.Neue_Uhrzeit(uhrzeit));

            mainWindow.Start_mit_Weckzeit += weckzeit => {
                interactors.Start_mit_Weckzeit(weckzeit,
                    istGestartet => mainWindow.Neuer_Zustand(istGestartet),
                    restzeit => mainWindow.Neue_Restzeit(restzeit));
            };

            mainWindow.Start_mit_Restzeit += restzeit => {
                interactors.Start_mit_Restzeit(restzeit,
                    istGestartet => mainWindow.Neuer_Zustand(istGestartet),
                    restzeit2 => mainWindow.Neue_Restzeit(restzeit2));
            };

            mainWindow.Stopp += () => {
                interactors.Stopp(
                    istGestartet => mainWindow.Neuer_Zustand(istGestartet));
            };
            
            var app = new Application { MainWindow = mainWindow };
            app.Run(mainWindow);
        }
    }
}