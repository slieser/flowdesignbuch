using NUnit.Framework;

namespace csvviewer.tests
{
    [TestFixture]
    public class UiTests
    {
        [Test]
        public void Formatting_very_simple() {
            var sut = new Ui();
            var result = sut.CreateLines(new[] {
                new Record { Values = new[]{"a", "b", "c"}},
                new Record { Values = new[]{"1", "2", "3"}}
            });
            Assert.That(result, Is.EqualTo(new[]{"a|b|c", "1|2|3"}));
        }

        [Test]
        public void Formatting_of_different_widths() {
            var sut = new Ui();
            var result = sut.CreateLines(new[] {
                new Record { Values = new[]{"a", "bb", "ccc"}},
                new Record { Values = new[]{"111", "22", "3"}}
            });
            Assert.That(result, Is.EqualTo(new[]{"a  |bb|ccc", "111|22|3  "}));
        }
    }
}