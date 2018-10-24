namespace Beispiele
{
    public class Abhängigkeiten
    {
        public int f(int x) {
            var y = f1(x);
            var z = f2(y);
            var r = f3(z);
            return r;
        }

        public int f1(int x) {
            var y = x + 2;
            return y;
        }

        public int f2(int y) {
            var z = y * 2;
            return z;
        }

        public int f3(int z) {
            var r = z + 42;
            return r;
        }
    }

    public class Abhängigkeiten2
    {
        public int f(int x) {
            var r = f1(x);
            return r;
        }

        public int f1(int x) {
            var y = x + 2;
            return f2(y);
        }

        public int f2(int y) {
            var z = y * 2;
            return f3(z);
        }

        public int f3(int z) {
            var r = z + 42;
            return r;
        }
    }
}