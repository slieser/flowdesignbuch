namespace wordcount
{
    internal static class Program
    {
        public static void Main(string[] args) {
            var ui = new Ui();
            var wordCounter = new WordCounter();

            var text = ui.GetText();
            var numberOfWords = wordCounter.CountWords(text);
            ui.ShowNumberOfWords(numberOfWords);
        }
    }
}