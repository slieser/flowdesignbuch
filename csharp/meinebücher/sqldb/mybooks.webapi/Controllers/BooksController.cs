using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mybooks.contracts;
using mybooks.integration;

namespace mybooks.webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController(ILogger<BooksController> logger, Interactors interactors) : ControllerBase
    {
        private readonly ILogger<BooksController> _logger = logger;

        [HttpGet]
        public IEnumerable<Book> GetBooks() {
            var books = interactors.Start();
            return books;
        }

        [HttpPut]
        public IEnumerable<Book> PutNewBook([FromQuery]string title) {
            var books = interactors.New_book(title);
            return books;
        }

        [HttpDelete]
        public IEnumerable<Book> RemoveBook([FromQuery]string id) {
            var books = interactors.Remove_book(long.Parse(id));
            return books;
        }

        [HttpPut("{id}/lend")]
        public IEnumerable<Book> PutLendBook([FromRoute]string id, [FromQuery]string name) {
            var books = interactors.Lend_book(long.Parse(id), name);
            return books;
        }

        [HttpPut("{id}/return")]
        public IEnumerable<Book> PutReturnBook(string id) {
            var books = interactors.Return_book(long.Parse(id));
            return books;
        }
    }
}