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