using System;
using tictactoe.domain;
using tictactoe.ui;

namespace tictactoe.console
{
    class Program
    {
        static void Main(string[] args) {
            var interactors = new Interactors();
            var consoleUi = new ConsoleUi();

            var start = new Action(() => {
                var result = interactors.Start();
                consoleUi.Spielbrett_anzeigen(result.Spielbrett, result.Meldung);
            });            
 
            consoleUi.Spielstein_setzen += feld => {
                var result = interactors.Spielstein_setzen(feld);
                consoleUi.Spielbrett_anzeigen(result.Spielbrett, result.Meldung);
            };

            start();
            consoleUi.Run();
        }
    }
}