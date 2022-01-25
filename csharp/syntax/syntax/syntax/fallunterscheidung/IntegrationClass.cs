using System;
using System.ComponentModel.DataAnnotations;

namespace syntax.fallunterscheidung
{
    public class IntegrationClass
    {
        public void Integration(int x) {
            var k = 0;
            f(x,
                onY: y => k = A(y),
                onZ: z => k = B(z));
            C(k);
        }

        public void Caller() {
            Integration(42);
        }
        
        private void f(int x, Func<int, int> onY, Func<int, int> onZ) {
            if (x < 0) {
                onY(-1);
            }
            else {
                onZ(x);
            }
        }

        private int A(int y) {
            return 42 + y;
        }

        private int B(int z) {
            return z + 2;
        }

        private void C(int k) {
            // ...
        }
    }
}