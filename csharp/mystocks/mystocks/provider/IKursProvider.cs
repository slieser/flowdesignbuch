using System.Collections.Generic;
using System.Threading.Tasks;
using mystocks.data;

namespace mystocks.provider
{
    public interface IKursProvider
    {
        IAsyncEnumerable<Wertpapier> KurseErmitteln(IEnumerable<string> symbole);

        IAsyncEnumerable<Titel> TitelSuchen(string suchbegriff);
    }
}