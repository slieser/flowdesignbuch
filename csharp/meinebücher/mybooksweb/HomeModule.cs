using System;
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

            Get["/index2.html"] = _ => {
                return View["index2.html"];
            };

            Get["/message"] = _ => {
                Console.WriteLine("Message was requested.");
                return Response.AsJson("Hello world!");
            };
        }
    }
}