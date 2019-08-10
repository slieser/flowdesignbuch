namespace syntax.split
{
    public class MyClass
    {
        public void F() {
            var x = A();
            B(x);
            C(x);
        }

        private void C(int x) {
            throw new System.NotImplementedException();
        }

        private void B(int x) {
            throw new System.NotImplementedException();
        }

        private int A() {
            throw new System.NotImplementedException();
        }
    }
}