namespace tictactoe.domain
{
    public class Meldungen
    {
        public static string Meldung_erzeugen(char spieler) {
            return $"Spieler '{spieler}' ist am Zug.";
        }

        public static string Ungültig_Meldung_erzeugen() {
            return "Der Spielzug ist ungültig!";
        }
    }
}
