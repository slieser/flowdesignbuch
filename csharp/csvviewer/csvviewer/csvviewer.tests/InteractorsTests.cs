using System.IO;
using System.Linq;
using NUnit.Framework;

namespace csvviewer.tests
{
    public class InteractorsTests
    {
        private Interactors _sut;
        private string _filename;

        [SetUp]
        public void Setup() {
            _filename = Path.Combine("testdata", "persons.csv");
            _sut = new Interactors();
        }

        [Test]
        public void Start_with_necessary_parameters() {
            var result = _sut.Start(new[] {_filename}).ToArray();
            Assert.That(result.Length, Is.EqualTo(11));
            Assert.That(result[0].Values, Is.EqualTo(new[]{"Name", "Age", "City"}));
        }

        [Test]
        public void Start_with_optional_PageLength_parameter() {
            var result = _sut.Start(new[] {_filename, "3"}).ToArray();
            Assert.That(result.Length, Is.EqualTo(4));
            Assert.That(result[0].Values, Is.EqualTo(new[]{"Name", "Age", "City"}));
        }
    }
}