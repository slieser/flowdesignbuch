using System;

namespace fallunterscheidung
{
    public class Abstrakt
    {
        public void f(int z, Action<int> onY, Action<string> onZ) {
            if (z == 42) {
                onY(42);
            }
            else {
                onZ("?");
            }
        }

        public int A(int x) {
            return x;
        }

        public int B(string y) {
            return -1;
        }

        public void C(int k) {
            Console.WriteLine(k);
        }

        public void Integration(int x) {
            var k = 0;
            f(x,
                onY: y => k = A(y),
                onZ: z => k = B(z));
            C(k);
        }
    }
}