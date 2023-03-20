using Avalonia;
using Avalonia.Controls;

namespace mystocks
{
    public static class Program
    {
        public static void Main(string[] args) => BuildAvaloniaApp().Start(AppMain, args);

        private static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace();

        private static void AppMain(Application app, string[] args) {
            var interactors = new Interactors();
            var mainWindow = new MainWindow();

            mainWindow.SuchbegriffGeändert += suchbegriff => {
                var titel = interactors.TitelSuchen(suchbegriff);
                mainWindow.TitelAktualisieren(titel);
            };
            mainWindow.TitelAusgewählt += symbol => {
                var wertpapiere = interactors.TitelHinzufügen(symbol);
                mainWindow.WertpapiereAktualisieren(wertpapiere);
            };
            mainWindow.TitelEntfernen += symbol => {
                var wertpapiere = interactors.TitelEntfernen(symbol);
                mainWindow.WertpapiereAktualisieren(wertpapiere);
            };

            interactors.Start(wertpapiere => {
                mainWindow.WertpapiereAktualisieren(wertpapiere);
            });
            app.Run(mainWindow);
        }
    }
}
