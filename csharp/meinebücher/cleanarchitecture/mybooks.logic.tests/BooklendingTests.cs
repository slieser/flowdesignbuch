using Moq;
using mybooks.contracts;
using mybooks.dbprovider;

namespace mybooks.logic.tests;

[TestFixture]
public class BooklendingTests
{
    private Booklending _sut;
    private Mock<IBooksRepository> _booksRepository;

    [SetUp]
    public void Setup() {
        _booksRepository = new Mock<IBooksRepository>();
        _sut = new Booklending(_booksRepository.Object);
    }
    
    [Test]
    public void New_book_can_be_lended() {
        var result = _sut.Create_book("new");
        
        Assert.That(result.CanBeLended, Is.True);
        
        Assert.That(result.Title, Is.EqualTo("new"));
        Assert.That(result.Lender, Is.EqualTo(""));
        Assert.That(result.LendingDate, Is.EqualTo(new DateTime()));
    }
    
    [Test]
    public void Lend_book_updates_lender_and_date() {
        var book = _sut.Create_book("Test Book");
        var lenderName = "John Doe";

        _booksRepository.Setup(x => x.GetById(book.Id)).Returns(book);
        var lentBook = _sut.Lend_book(book.Id, lenderName);

        Assert.That(lentBook.Lender, Is.EqualTo(lenderName));
        Assert.That(lentBook.LendingDate, Is.Not.EqualTo(DateTime.MinValue));
        Assert.That(lentBook.CanBeLended, Is.False);
    }

    [Test]
    public void Returned_book_can_be_lended() {
        var book = _sut.Create_book("Test Book");
        var lenderName = "John Doe";
        _booksRepository.Setup(x => x.GetById(book.Id)).Returns(book);
        var lentBook = _sut.Lend_book(book.Id, lenderName);
        
        _booksRepository.Setup(x => x.GetById(lentBook.Id)).Returns(book);
        var returnedBook = _sut.Return_book(lentBook.Id);

        Assert.That(returnedBook.Lender, Is.EqualTo(""));
        Assert.That(returnedBook.LendingDate, Is.EqualTo(DateTime.MinValue));
        Assert.That(returnedBook.CanBeLended, Is.True);
    }
}