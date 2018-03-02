namespace tictactoe.domain
{
    public class TicTacToe
    {
        public static char[] Leeres_Spielbrett_erzeugen() {
            var spielbrett = new char[9];
            for (int i = 0; i < 9; i++) {
                spielbrett[i] = ' ';
            }
            return spielbrett;
        }

        public static char Spieler_festlegen() {
            return 'X';
        }

    }
}
