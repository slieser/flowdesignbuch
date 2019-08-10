using System;

namespace syntax.exceptions.returns
{
    public class MyClass
    {
        public int F(int x) {
            // ...
            if(false /* ... */) {
                throw new Exception("Error");
            }
            else {
                return 42;
            }
        }
    }
}