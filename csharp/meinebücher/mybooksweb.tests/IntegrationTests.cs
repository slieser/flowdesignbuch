using System;
using mybooks.contracts;
using Nancy;
using Nancy.Testing;
using Newtonsoft.Json;
using NUnit.Framework;

namespace mybooksweb.tests
{
    [TestFixture]
    public class IntegrationTests
    {
        private Browser _browser;

        [SetUp]
        public void Setup() {
            var bootstrapper = new ConfigurableBootstrapper(with => with.Module<BooksApiModule>());
            _browser = new Browser(bootstrapper);
        }
        
        [Test]
        public void Get_books_is_empty_at_the_beginning() {
            var result = _browser.Get("/books", with => {
                with.HttpRequest();
            });
        
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var books = JsonConvert.DeserializeObject<Book[]>(result.Body.AsString());
            Assert.That(books, Is.Empty);
        }

        [Test]
        public void A_book_can_be_added() {
            var result = _browser.Put("/books?title=Pumuckl", with => {
                with.HttpRequest();
            });

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var books = JsonConvert.DeserializeObject<Book[]>(result.Body.AsString());
            Assert.That(books.Length, Is.EqualTo(1));
            Assert.That(books[0].Title, Is.EqualTo("Pumuckl"));
            Assert.That(books[0].CorrelationId, Is.Not.Null);
            Assert.That(books[0].CanBeLended, Is.True);
            Assert.That(books[0].Lender, Is.Empty);
            Assert.That(books[0].LendingDate, Is.EqualTo(new DateTime()));
        }
    }
}