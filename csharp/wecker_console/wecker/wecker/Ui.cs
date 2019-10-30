using System;

namespace wecker
{
    public class Ui
    {
        private int _x;
        private int _y;

        public Ui() {
            Console.WriteLine();
            _x = Console.CursorLeft;
            _y = Console.CursorTop;
        }

        public void Uhrzeit_anzeigen(DateTime uhrzeit) {
            Console.SetCursorPosition(_x, _y);
            Console.WriteLine($"Uhrzeit:  {uhrzeit:hh\\:mm\\:ss}");
            
        }

        public void Restzeit_anzeigen(TimeSpan restzeit) {
            Console.SetCursorPosition(_x, _y + 1);
            Console.WriteLine($"Restzeit: {restzeit:hh\\:mm\\:ss}");
        }
    }
}