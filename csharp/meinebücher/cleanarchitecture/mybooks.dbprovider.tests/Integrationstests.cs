using NUnit.Framework;

namespace mybooks.dbprovider.tests
{
    [TestFixture]
    public class Integrationstests : DatabaseTests
    {
        [Test, Explicit]
        public void CreateProductiveDatabase() {
            CreateDatabase("MyBooks");
        }
    }
}