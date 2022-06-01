using System.Collections.Generic;
using mystocks.data;

namespace mystocks.provider
{
    public interface IKursProvider
    {
        IEnumerable<Wertpapier> KurseErmitteln(IEnumerable<string> symbole);
        IEnumerable<Titel> TitelSuchen(string suchbegriff);
    }
}