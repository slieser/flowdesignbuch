using System;
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
            var bootstrapper = new Bootstrapper();
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

        [Test]
        public void A_new_book_can_be_retrieved() {
            var result = _browser.Put("/books?title=Pumuckl", with => {
                with.HttpRequest();
            });
            result = _browser.Get("/books", with => {
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

        [Test]
        public void Multiple_books_can_be_added() {
            var result = _browser.Put("/books?title=Pumuckl", with => {
                with.HttpRequest();
            });
            _browser.Put("/books?title=Book 2", with => {
                with.HttpRequest();
            });
            result = _browser.Put("/books?title=Book 3", with => {
                with.HttpRequest();
            });

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var books = JsonConvert.DeserializeObject<Book[]>(result.Body.AsString());
            Assert.That(books.Length, Is.EqualTo(3));
            Assert.That(books[0].Title, Is.EqualTo("Pumuckl"));
            Assert.That(books[1].Title, Is.EqualTo("Book 2"));
            Assert.That(books[2].Title, Is.EqualTo("Book 3"));
        }
        
        [Test]
        public void A_book_can_be_deleted() {
            var result = _browser.Put("/books?title=Pumuckl", with => {
                with.HttpRequest();
            });
            var books = JsonConvert.DeserializeObject<Book[]>(result.Body.AsString());
            result = _browser.Delete($"/books?id={books[0].CorrelationId}", with => {
                with.HttpRequest();
            });

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            books = JsonConvert.DeserializeObject<Book[]>(result.Body.AsString());
            Assert.That(books.Length, Is.EqualTo(0));
        }
        
        [Test]
        public void A_book_can_be_lended() {
            var result = _browser.Put("/books?title=Pumuckl", with => {
                with.HttpRequest();
            });
            var books = JsonConvert.DeserializeObject<Book[]>(result.Body.AsString());
            result = _browser.Put($"/books/{books[0].CorrelationId}/lend?name=Paul", with => {
                with.HttpRequest();
            });

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            books = JsonConvert.DeserializeObject<Book[]>(result.Body.AsString());
            Assert.That(books.Length, Is.EqualTo(1));
            Assert.That(books[0].Title, Is.EqualTo("Pumuckl"));
            Assert.That(books[0].CorrelationId, Is.Not.Null);
            Assert.That(books[0].CanBeLended, Is.False);
            Assert.That(books[0].Lender, Is.EqualTo("Paul"));
            Assert.That(books[0].LendingDate.ToShortDateString(), Is.EqualTo(DateTime.Now.ToShortDateString()));
        }
        
        [Test]
        public void A_lended_book_can_be_given_back() {
            var result = _browser.Put("/books?title=Pumuckl", with => {
                with.HttpRequest();
            });
            var books = JsonConvert.DeserializeObject<Book[]>(result.Body.AsString());
            _browser.Put($"/books/{books[0].CorrelationId}/lend?name=Paul", with => {
                with.HttpRequest();
            });
            result = _browser.Put($"/books/{books[0].CorrelationId}/back", with => {
                with.HttpRequest();
            });

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            books = JsonConvert.DeserializeObject<Book[]>(result.Body.AsString());
            Assert.That(books.Length, Is.EqualTo(1));
            Assert.That(books[0].Title, Is.EqualTo("Pumuckl"));
            Assert.That(books[0].CorrelationId, Is.Not.Null);
            Assert.That(books[0].CanBeLended, Is.True);
            Assert.That(books[0].Lender, Is.Empty);
            Assert.That(books[0].LendingDate, Is.EqualTo(new DateTime()));
        }
    }
}