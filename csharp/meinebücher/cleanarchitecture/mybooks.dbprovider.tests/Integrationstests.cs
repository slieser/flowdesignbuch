using NUnit.Framework;

namespace mybooks.dbprovider.tests
{
    [TestFixture]
    public class Integrationstests : DatabaseTests
    {
        [Test, Explicit]
        public void Create_Database_and_Tables() {
            CreateDatabase("MyBooks");
        }
    }
}