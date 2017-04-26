namespace Beispiele
{
    public class TicTacToe
    {
        private readonly State<char[,]> _state;

        public TicTacToe(State<char[,]> state) {
            _state = state;
        }

        public char[,] Spielstein_setzen(int x, int y) {
            var spielbrett = _state.Get();
            // Spielbrett manipulieren
            _state.Set(spielbrett);
            return spielbrett;
        }

        public char[,] Neues_Spiel() {
            var spielbrett = Leeres_Spielbrett();
            _state.Set(spielbrett);
            return spielbrett;
        }

        private static char[,] Leeres_Spielbrett() {
            return new char[3, 3];
        }
    }
}