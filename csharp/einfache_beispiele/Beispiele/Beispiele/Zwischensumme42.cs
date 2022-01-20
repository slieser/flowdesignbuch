namespace Beispiele
{
    public class Zwischensumme2
    {
        private int _summe;

        public int Aktuelle_Zwischensumme_berechnen(int wert) {
            _summe += wert;
            return _summe;
        }

        public int Aktuelle_Zwischensumme_berechnen(int wert, State<int> summe) {
            var s = summe.Get();
            s += wert;
            summe.Set(s);
            return s;
        }
    }

    public class Zwischensumme
    {
        internal readonly State<int> _state = new State<int>();
    
        public int Aktuelle_Zwischensumme_berechnen(int wert) {
            var bisherige_Summe = _state.Get();
            var aktuelle_Summe = Aktuelle_Zwischensumme_berechnen(wert, bisherige_Summe);
            _state.Set(aktuelle_Summe);
            return aktuelle_Summe;
        }
    
        public int Aktuelle_Zwischensumme_berechnen(int wert, int summe) {
            return wert + summe;
        }
    }

    public class Verwender
    {
        public void Summiere() {
            var zwischensumme = new Zwischensumme();
            var summe = zwischensumme.Aktuelle_Zwischensumme_berechnen(1);
        }

        public void Summiere_mit_Zustand() {
            var zwischensumme = new Zwischensumme2();
            var state = new State<int>();

            var summe = zwischensumme.Aktuelle_Zwischensumme_berechnen(1, state);
        }
    }

    public class State<T>
    {
        private T _item;
    
        public void Set(T item) {
            _item = item;
        }
    
        public T Get() {
            return _item;
        }
    }

    public class Zwischensumme42
    {
        private int _summe;
        
        public int AktuelleZwischensummeBerechnen(int wert) {
            _summe = ZwischensummeBerechnen(_summe, wert);
            return _summe;
        }

        private int ZwischensummeBerechnen(int summe, int wert) {
            return summe + wert;
        }

        public void Verwender() {
            var summe = AktuelleZwischensummeBerechnen(5);
        }
    }
}