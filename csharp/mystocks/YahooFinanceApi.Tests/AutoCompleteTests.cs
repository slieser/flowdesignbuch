using Xunit;

namespace YahooFinanceApi.Tests
{
    public class AutoCompleteTests
    {
        [Fact]
        public async void AutoComplete_finds_some_values() {
            var results = await Yahoo.AutoComplete("apple").SearchAsync();
            Assert.Equal(9, results.Count);
        }
    }
}