namespace tictactoe.domain
{
    public class Interactors
    {
        private char[] _spielbrett;
        private char _spieler;

        public (char[] Spielbrett, string Meldung) Start() {
            var spielbrett = TicTacToe.Leeres_Spielbrett_erzeugen();
            var spieler = TicTacToe.Spieler_festlegen();

            _spielbrett = spielbrett;
            _spieler = spieler;

            var meldung = Meldungen.Meldung_erzeugen(spieler);

            return (spielbrett, meldung);
        }
    }
}
