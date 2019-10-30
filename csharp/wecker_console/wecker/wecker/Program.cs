using System;

namespace wecker
{
    class Program
    {
        static void Main(string[] args) {
            var weckzeit = DateTime.Parse(args[0]);

            var interactor = new Interactor();
            var ui = new Ui();

            interactor.Start(uhrzeit => {
                ui.Uhrzeit_anzeigen(uhrzeit);
            });
            
            interactor.Start_mit_Weckzeit(weckzeit, restzeit => {
                ui.Restzeit_anzeigen(restzeit);
            });
            Console.ReadLine();
        }
    }
}