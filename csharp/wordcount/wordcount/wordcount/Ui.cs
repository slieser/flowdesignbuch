using System;

namespace wordcount
{
    public class Ui
    {
        public string GetText() {
            Console.Write("Enter your text: ");
            var text = Console.ReadLine();
            return text;
        }

        public void ShowNumberOfWords(int numberOfWords) {
            var message = $"Number of words: {numberOfWords}";
            Console.WriteLine(message);
        }
    }
}