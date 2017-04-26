using System.Xml;

namespace Beispiele
{
    public class Zwischensumme
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

    public class Verwender
    {
        public void Summiere() {
            var zwischensumme = new Zwischensumme();
            var summe = zwischensumme.Aktuelle_Zwischensumme_berechnen(1);
        }

        public void Summiere_mit_Zustand() {
            var zwischensumme = new Zwischensumme();
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
}