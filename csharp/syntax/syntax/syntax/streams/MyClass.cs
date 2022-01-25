using System;
using System.Collections.Generic;

namespace syntax.streams
{
    public class MyClass
    {
        public void F(Action<string> onResult) {
            // ...
            foreach (var s in new[]{"1", "2"}) {
                onResult(s);
            }
            onResult(null); // end-of-stream
        }
    }
}


namespace syntax.streams.events
{
    public class MyClass
    {
        public event Action<string> OnResult;
        
        public void F() {
            // ...
            foreach (var s in new[]{"1", "2"}) {
                OnResult(s);
            }
            OnResult(null); // end-of-stream
        }
    }
}


namespace syntax.streams.enumerator
{
    public class MyClass
    {
        public IEnumerable<string> F() {
            // ...
            foreach (var s in new[]{"1", "2"}) {
                yield return s;
            }
        }
    }
}


namespace syntax.streams2
{
    public class MyClass
    {
        public void F(Action<string> onResult, Action onEndOfStream) {
            // ...
            foreach (var s in new[]{"1", "2"}) {
                onResult(s);
            }
            onEndOfStream();
        }
    }
}