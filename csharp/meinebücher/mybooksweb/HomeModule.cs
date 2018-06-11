using mybooks;
using Nancy;

namespace mybooksweb
{
    public class HomeModule : NancyModule
    {
        public HomeModule() {
            var interactors = new Interactors();

            Get["/"] = _ => {
                var books = interactors.Start();
                return View["index.sshtml", books];
            };
        }
    }
}