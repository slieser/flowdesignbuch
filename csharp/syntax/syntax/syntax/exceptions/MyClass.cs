using System;

namespace syntax.exceptions
{

public class MyClass
{
    public void F(int x) {
        // ...
        if( ... ) {
            throw new Exception("Error");
        }
    }
}
}