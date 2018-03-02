using Eto.Forms;
using tictactoe.domain;
using tictactoe.ui;

namespace tictactoe
{
    internal class Program
    {
        public static void Main(string[] args) {
            var app = new Application();
            
            var ui = new Ui();
            var interactors = new Interactors();

            var result = interactors.Start();
            ui.Spielstand_anzeigen(result.Spielbrett, result.Meldung);
            
            app.Run(ui);
        }
    }
}