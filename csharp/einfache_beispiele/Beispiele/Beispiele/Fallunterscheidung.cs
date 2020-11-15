using System;

namespace Beispiele
{
    public class Entscheidung
    {
        public void f(int x, Action<string> onY, Action<int> onZ) {
            if (x < 0) {
                onY("negativ");
            }
            else {
                onZ(x);
            }
        }

        public void Verwendung_von_f() {
            f(42,
                onY : Weiter_mit_Y,
                onZ : z => Console.WriteLine(z)
            );
        }

        private static void Weiter_mit_Y(string y) {
            Console.WriteLine(y);
        }

        public void g(int x, out string y, out int z) {
            if (x < 0) {
                y = "negativ";
            }
            else {
                z = x;
            }
            // syntaktisch falsch, da beim Verlassen beide
            // out Parameter zugewiesen sein müssen
            y = null;
            z = 0;
        }
    }
}