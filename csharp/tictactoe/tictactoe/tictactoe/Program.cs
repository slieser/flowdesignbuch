using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Logging.Serilog;
using tictactoe.domain;
using tictactoe.ui;

namespace tictactoe
{
    class Program
    {
        public static void Main(string[] args) => BuildAvaloniaApp().Start(AppMain, args);

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToDebug();

        private static void AppMain(Application app, string[] args) {
            var interactors = new Interactors();
            var ui = new MainWindow();

            var start = new Action(() => {
                var result = interactors.Start();
                ui.Show_score(result.Spielbrett, result.Meldung);
            });            
 
            ui.Token_set += feld => {
                var result = interactors.Spielstein_setzen(feld);
                ui.Show_score(result.Spielbrett, result.Meldung);
            };

            start();
            app.Run(ui);
        }
    }
}