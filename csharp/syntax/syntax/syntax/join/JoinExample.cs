using System;

namespace syntax.join
{
    public class JoinExample
    {
        public int f1(int a) {
            return 0;
        }

        public int f2(int b) {
            return 0;
        }

        public int f3(int x, int y) {
            return 0;
        }

        public int f_implizit() {
            var a = 1;
            var b = 2;

            var x = f1(a);
            var y = f2(b);
            var z = f3(x, y);
            return z;
        }

        public int f_explizit() {
            var a = 1;
            var b = 2;

            var z = Join(a, b, f1, f2, f3);
            return z;
        }

        public int f_explizit2() {
            var a = 1;
            var b = 2;
            var joiner = new Joiner<int, int, int>();

            var z1 = joiner.Join(a, b, f1, f2, f3);
            var z2 = joiner.Join(a, b, f1, f2, f3);
            return z2;
        }

        private T3 Join<T1, T2, T3>(
                T1 a, T2 b, 
                Func<T1, T1> f1, 
                Func<T2, T2> f2, 
                Func<T1, T2, T3> f3) {
            var x = f1(a);
            var y = f2(b);
            var z = f3(x, y);
            return z;
        }
    }

    public class Joiner<T1, T2, T3>
    {
        private T1 _x;
        private bool _xHasValue;
        private T2 _y;
        private bool _yHasValue;
        
        public T3 Join(
                T1 a, T2 b, 
                Func<T1, T1> f1, 
                Func<T2, T2> f2, 
                Func<T1, T2, T3> f3) {
            var x = _xHasValue ? _x : f1(a);
            var y = _yHasValue ? _y : f2(b);
            var z = f3(x, y);
            return z;
        }
        
    }
}