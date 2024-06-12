using mybooks.dbprovider.tests;
using mybooks.logic;

namespace mybooks.integration.tests;

[TestFixture]
public class InteractorsTests : DatabaseTests
{
    private Interactors _sut;

    [SetUp]
    public void Setup2() {
        var bookLending = new Booklending(_booksRepository);
        _sut = new Interactors(bookLending);
    }

    [Test]
    public void Start_returns_no_books_on_initial_database() {
        var result = _sut.Start();
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void New_book_adds_a_book() {
        var result = _sut.New_book("The Hobbit");
        Assert.That(result.Count(), Is.EqualTo(1));
    }
}