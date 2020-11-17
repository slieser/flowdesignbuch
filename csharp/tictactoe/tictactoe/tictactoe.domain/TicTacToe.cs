using System;

namespace tictactoe.domain
{
    public static class TicTacToe
    {
        private const char Leeres_Feld = ' ';

        public static char[] Leeres_Spielbrett_erzeugen() {
            var spielbrett = new char[9];
            for (int i = 0; i < 9; i++) {
                spielbrett[i] = Leeres_Feld;
            }
            return spielbrett;
        }

        public static char Spieler_festlegen() {
            return 'X';
        }

        public static void Ist_Zug_gültig(char[] spielbrett, int feld, Action onUngültig, Action onGültig) {
            if (spielbrett[feld] == Leeres_Feld) {
                onGültig();
            }
            else {
                onUngültig();
            }
        }

        public static char[] Spielstein_setzen(char[] spielbrett, char spieler, int feld) {
            spielbrett[feld] = spieler;
            return spielbrett;
        }

        public static char Spieler_wechseln(char spieler) {
            return spieler == 'X' ? 'O' : 'X';
        }
    }
}
