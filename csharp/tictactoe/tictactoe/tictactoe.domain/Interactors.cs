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

        public (char[] Spielbrett, string Meldung) Spielstein_setzen(int feld) {
            var spielbrett = _spielbrett;
            var spieler = _spieler;
            var meldung = "";
            
            TicTacToe.Ist_Zug_gültig(spielbrett, feld,
                onUngültig: () => {
                    meldung = Meldungen.Ungültig_Meldung_erzeugen();
                },
                onGültig: () => {
                    spielbrett = TicTacToe.Stein_setzen(spielbrett, spieler, feld);
                    spieler = TicTacToe.Spieler_wechseln(spieler);
                    _spielbrett = spielbrett;
                    _spieler = spieler;
                    meldung = Meldungen.Meldung_erzeugen(spieler);
                });

            return (spielbrett, meldung);
        }
    }
}
