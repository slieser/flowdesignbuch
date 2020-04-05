using System;

namespace tictactoe.ui
{
    public class ConsoleUi
    {
        public event Action<int> Spielstein_setzen;
        
        public void Spielbrett_anzeigen(char[] spielbrett, string meldung) {
            Console.WriteLine("-+-+-");
            for (var i = 0; i < 9; i++) {
                Console.Write(spielbrett[i]);
                if ((i+1) % 3 == 0) {
                    Console.WriteLine();
                    Console.WriteLine("-+-+-");
                }
                else {
                    Console.Write("|");
                }
            }
            Console.WriteLine();
            Console.WriteLine(meldung);
        }

        public void Run() {
            var running = true;
            do {
                var s = Console.ReadLine();
                if (string.IsNullOrEmpty(s)) {
                    running = false;
                }
                else {
                    var field = int.Parse(s);
                    Spielstein_setzen(field);
                }
            } while (running);
        }
    }
}