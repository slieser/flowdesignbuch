namespace zustand
{
public class Zwischensumme
{
    private int _summe;

    public int AktuelleZwishensummeBerechnen(int wert) {
        _summe = ZwischensummeBerechnen(_summe, wert);
        return _summe;
    }

    internal int ZwischensummeBerechnen(int summe, int wert) {
        return summe + wert;
    }
}

    public class Verwender
    {
        public void Example() {
            var zw = new Zwischensumme();
            var i = zw.AktuelleZwishensummeBerechnen(42);
        }
    }
}