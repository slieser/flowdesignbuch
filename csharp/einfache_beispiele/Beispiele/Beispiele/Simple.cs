using System;

namespace Beispiele
{
    public class Simple
    {
        public int f(int x) {
            var y = x + 42;   // Calculate value of y
            return y;
        }

        private void UsingF() {
            var y = f(8);
        }
    }

    public class F
    {
        public event Action<int> Result;
        
        public void OnX(int x) {
            var z = x + 42;  // Calculate value of z
            Result(z);
        }
        
        public void OnY(int y) {
            var z = y + 42;  // Calculate value of z
            Result(z);
        }
    }

    public class UsingF
    {

        private void Using() {
            var f = new F();
            f.Result += i => { };
            f.OnX(1);
            f.OnY(2);
        }
    }
}