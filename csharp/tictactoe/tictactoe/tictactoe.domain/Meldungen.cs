namespace tictactoe.domain
{
    public class Meldungen
    {
        public static string Meldung_erzeugen(char spieler) {
            return $"Spieler '{spieler}' ist am Zug.";
        }
    }
}
