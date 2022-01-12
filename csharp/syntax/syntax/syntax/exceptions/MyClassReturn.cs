using System;

namespace syntax.exceptions.returns
{
public class MyClass
{
    public int F(int x) {
        // ...
        if( ... ) {
            throw new Exception("Error");
        }
        else {
            return 42;
        }
    }
}
}