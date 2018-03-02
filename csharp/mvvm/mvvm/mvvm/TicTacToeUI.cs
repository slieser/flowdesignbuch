using System;

namespace mvvm
{
    public class TicTacToeUI
    {
        public event Action<int, int> Spielstein_setzen;

        public event Action Neues_Spiel;

        public void Spielfeld_anzeigen(char[,] spielfeld) {
            // ...
            spielfeld = spielfeld;
        }
    }

    public class Verwender
    {
        public void DoSomething() {
            var sut = new TicTacToeUI();
            sut.Spielstein_setzen += (x, y) => { };
            sut.Neues_Spiel += () => { };
            sut.Spielfeld_anzeigen(new char[3,3]);
        }
    }
}
