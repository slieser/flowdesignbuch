using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace YahooFinanceApi
{
    public sealed partial class Yahoo
    {
        private string searchText;

        public static Yahoo AutoComplete(string search) {
            return new Yahoo {searchText = search};
        }

        public async Task<List<AutoCompletion>> SearchAsync(CancellationToken token = default) {
            if (string.IsNullOrWhiteSpace(searchText))
                throw new ArgumentException("No search string given.");


            var url = "https://s.yimg.com/xb/v6/finance/autocomplete?&lang=en-US&region=US&corsDomain=finance.yahoo.com"
                .SetQueryParam("query", searchText);


            dynamic expando = null;

            try {
                expando = await url
                    .GetAsync(token)
                    .ReceiveJson() // ExpandoObject
                    .ConfigureAwait(false);
            }
            catch (FlurlHttpException ex) {
                if (ex.Call.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return new List<AutoCompletion>(); // When there are no valid results
                throw;
            }

            var resultSetExpando = expando.ResultSet;
            var autoCompletes = new List<AutoCompletion>();

            foreach (IDictionary<string, dynamic> dictionary in resultSetExpando.Result) {
                var autocompletion = new AutoCompletion {
                    Symbol = dictionary["symbol"],
                    Name = dictionary["name"],
                    ExchangeShort = dictionary["exch"],
                    ExchangeLong = dictionary["exchDisp"],
                    TypeShort = dictionary["type"],
                    TypeLong = dictionary["typeDisp"]
                };
                autoCompletes.Add(autocompletion);
            }

            return autoCompletes;
        }
    }
}