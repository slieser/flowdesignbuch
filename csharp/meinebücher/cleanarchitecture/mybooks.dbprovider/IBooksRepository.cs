using System.Collections.Generic;
using mybooks.contracts;

namespace mybooks.dbprovider;

public interface IBooksRepository
{
    bool TryAdd(Book book);
    bool TryUpdate(Book book);
    bool TryDeleteById(long id);
    Book GetById(in long id);
    IEnumerable<Book> LoadAll();
}