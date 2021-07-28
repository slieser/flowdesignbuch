using System;
using System.Collections.Generic;

namespace wordwrap
{
    public class Interactors
    {
        public string Wrap(string text, int width) {
            var paragraphs = SplitIntoParagraphs(text);
            paragraphs = WrapParagraphs(paragraphs, width);
            return CreateText(paragraphs);
        }

        private IEnumerable<string> SplitIntoParagraphs(string text) {
            return text.Split(new[]{ Environment.NewLine + Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
        }

        private IEnumerable<string> WrapParagraphs(IEnumerable<string> paragraphs, int width) {
            foreach (var paragraph in paragraphs) {
                yield return WrapParagraph(paragraph, width);
            }
        }

        private string WrapParagraph(string paragraph, int width) {
            var words = SplitIntoWords(paragraph);
            var lines = CreateLines(words, width);
            return CreateParagraph(lines);
        }

        private string CreateParagraph(IEnumerable<string> lines) {
            return string.Join(Environment.NewLine, lines);
        }

        private IEnumerable<string> SplitIntoWords(string paragraph) {
            return paragraph.Split(new []{ " ", "\t", Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
        }

        private IEnumerable<string> CreateLines(IEnumerable<string> words, int width) {
            var line = "";
            foreach (var word in words) {
                if (line == "") {
                    line = word;
                }
                else {
                    var newLine = line + " " + word;
                    if (newLine.Length <= width) {
                        line = newLine;
                    }
                    else {
                        yield return line;
                        line = word;
                    }
                }
            }
            if (line.Length > 0) {
                yield return line;
            }
        }

        private string CreateText(IEnumerable<string> paragraphs) {
            return string.Join(Environment.NewLine + Environment.NewLine, paragraphs);
        }
    }
}