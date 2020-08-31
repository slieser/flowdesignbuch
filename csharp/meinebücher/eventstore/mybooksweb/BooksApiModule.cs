using System;
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
            
            Delete["/books?id={id}"] = parms => {
                string id = parms.id;
                var books = interactors.Remove_book(new Guid(id));
                return Response.AsJson(books);
            };
            
            Put["/books/{id}/lend?name={name}"] = parms => {
                string id = parms.id;
                string name = parms.name;
                var books = interactors.Lend_book(new Guid(id), name);
                return Response.AsJson(books);
            };
            
            Put["/books/{id}/back"] = parms => {
                string id = parms.id;
                var books = interactors.Book_got_back(new Guid(id));
                return Response.AsJson(books);
            };
        }
    }
}