using mybooks;
using Nancy;

namespace mybooksweb
{
    public class BooksApiModule : NancyModule
    {
        public BooksApiModule(Interactors interactors) {
            Get["/books"] = _ => {
                var books = interactors.Start();
                return Response.AsJson(books);
            };
            
            Put["/books?title={title}"] = parms => {
                string title = parms.title;
                var books = interactors.New_book(title);
                return Response.AsJson(books);
            };
        }
    }
}