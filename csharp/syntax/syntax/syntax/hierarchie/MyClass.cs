using System;

namespace syntax.hierarchie
{
    public class MyClass
    {
        public int H(int x) {
            var y = F(x);
            var z = G(y);
            return z;
        }

        private int F(int x) {
            return x + 1;
        }

        private int G(int y) {
            return y * 2;
        }
    }
}

namespace syntax.hierarchie.noX
{
    public class MyClass
    {
        public int F(int x) {
            var q = F1(x);
            var r = F2(q);
            var y = F3(r);
            return y;
        }

        private int F1(int x) {
            return x + 1;
        }

        private int F2(int q) {
            return q * 2;
        }
        private int F3(int r) {
            return r - 3;
        }
    }
}

namespace syntax.hierarchie.noY
{
    public class MyClass
    {
        private MyClass1 _myClass1;
        private MyClass2 _myClass2;
        private MyClass3 _myClass3;

        public MyClass() {
            _myClass1 = new MyClass1();
            _myClass2 = new MyClass2();
            _myClass3 = new MyClass3();
        }

        public int F(int x) {
            var q = _myClass1.F1(x);
            var r = _myClass2.F2(q);
            var y = _myClass3.F3(r);
            return y;
        }
    }

    public class MyClass1 {
        public int F1(int x) {
            return x + 1;
        }
    }

    public class MyClass2 {
        public int F2(int q) {
            return q * 2;
        }
    }

    public class MyClass3 {
        public int F3(int r) {
            return r - 3;
        }
    }
}
namespace syntax.hierarchie.no2
{
    public class MyClass
    {
        public void H(int x, Action<int> continueWith) {
            F(x, y => G(y, continueWith));
        }
    
        private void F(int x, Action<int> continueWith) {
            var y = x + 1;
            continueWith(y);
        }
    
        private void G(int y, Action<int> continueWith) {
            var z = y * 2;
            continueWith(z);
        }
    }
}

namespace syntax.hierarchie.no3 {
public class Integration
{
	public void H(int x) {
		var operations = new Operations();
 
		operations.Result_of_F += operations.G;
		operations.Result_of_G += z => Result_of_H(z);
 
		operations.F(x);
	}
 
	public event Action<int> Result_of_H;
}
 
 
public class Operations {
	public void F(int x) {
		var y = x + 1;
		Result_of_F(y);
	}
 
	public event Action<int> Result_of_F;
 
	public void G(int y) {
		var z = y * 2;
		Result_of_G(z);
	}
 
	public event Action<int> Result_of_G;
}
}