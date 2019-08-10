using System;

namespace syntax.exceptions
{

    public class MyClass
    {
        public void F(int x) {
            // ...
            if(true /* ... */) {
                throw new Exception("Error");
            }
        }
    }
}