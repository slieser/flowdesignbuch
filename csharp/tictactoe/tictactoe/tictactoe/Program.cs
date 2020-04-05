using System;
using Eto.Forms;
using tictactoe.domain;
using tictactoe.ui;

namespace tictactoe
{
    internal class Program
    {
        public static void Main(string[] args) {
            AppDomain.CurrentDomain.UnhandledException += (o, e) => {
                MessageBox.Show(Environment.StackTrace);
            };
            
            var app = new Application();
            
            var ui = new Ui();
            var interactors = new Interactors();

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