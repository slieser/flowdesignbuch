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
            var app = new Application { MainWindow = mainWindow };
            var interactors = new Interactors();

            interactors.Start(
                (startbar, stoppbar) => mainWindow.Neuer_Zustand(startbar, stoppbar),
                uhrzeit => mainWindow.Neue_Uhrzeit(uhrzeit));

            mainWindow.Start_mit_Weckzeit += weckzeit => {
                interactors.Start_mit_Weckzeit(weckzeit,
                    (startbar, stoppbar) => mainWindow.Neuer_Zustand(startbar, stoppbar),
                    restzeit => mainWindow.Neue_Restzeit(restzeit));
            };

            mainWindow.Start_mit_Restzeit += restzeit => {
                interactors.Start_mit_Restzeit(restzeit,
                    (startbar, stoppbar) => mainWindow.Neuer_Zustand(startbar, stoppbar),
                    restzeit2 => mainWindow.Neue_Restzeit(restzeit2));
            };

            mainWindow.Stopp += () => {
                interactors.Stopp(
                    (startbar, stoppbar) => mainWindow.Neuer_Zustand(startbar, stoppbar));
            };
            
            app.Run(mainWindow);
        }
    }
}