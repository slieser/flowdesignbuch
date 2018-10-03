using System;

namespace fallunterscheidung
{
    public class Abstrakt
    {
        public void f(int z, Action<int> onX, Action<string> onY) {
            if (z == 42) {
                onX(42);
            }
            else {
                onY("?");
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

        public void Integration(int z) {
            var k = 0;
            f(z,
                onX: x => k = A(x),
                onY: y => k = B(y));
            C(k);
        }
    }
}