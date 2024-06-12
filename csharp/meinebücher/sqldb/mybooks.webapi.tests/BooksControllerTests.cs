using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using mybooks.contracts;
using mybooks.dbprovider;
using mybooks.dbprovider.tests;
using mybooks.integration;
using Newtonsoft.Json;
using NUnit.Framework;

namespace mybooks.webapi.tests
{
    [TestFixture]
    public class BooksControllerTests : DatabaseTests
    {
        private HttpClient _client;
        
        [SetUp]
        public void Setup() {
            var factory = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder => {
                builder.ConfigureTestServices(services => {
                    services.AddSingleton(typeof(BooksRepository), _booksRepository);
                    services.AddSingleton(typeof(Interactors), new Interactors(_booksRepository));
                });
            });
            _client = factory.CreateClient();
        }

        [Test]
        public async Task Root_smoke_Test() {
            var response = await _client.GetAsync("/books");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            Assert.That(responseString, Is.EqualTo("[]"));
        }

        [Test]
        public async Task Book_can_be_created() {
            var response = await _client.PutAsync("/books?title=Flow Design", null);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var books = JsonConvert.DeserializeObject<List<Book>>(responseString);
            Assert.That(books.Count, Is.EqualTo(1));
            Assert.That(books[0].Id, Is.Not.EqualTo(0));
            Assert.That(books[0].Title, Is.EqualTo("Flow Design"));
            Assert.That(books[0].Lender, Is.EqualTo(""));
            Assert.That(books[0].LendingDate, Is.EqualTo(new DateTime()));
            Assert.That(books[0].CanBeLended, Is.True);
        }

        [Test]
        public async Task Book_can_be_deleted() {
            var response = await _client.PutAsync("/books?title=Flow Design", null);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var books = JsonConvert.DeserializeObject<List<Book>>(responseString);
            var id = books.First().Id;
            
            response = await _client.DeleteAsync($"/books?id={id}");
            response.EnsureSuccessStatusCode();
            responseString = await response.Content.ReadAsStringAsync();
            books = JsonConvert.DeserializeObject<List<Book>>(responseString);
            Assert.That(books.Count, Is.EqualTo(0));
        }
    }
}