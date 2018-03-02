using System;

namespace tictactoe.ui
{
    public class ConsoleUi
    {
        public void Spielstand_anzeigen(char[] spielbrett, string meldung) {
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
    }
}