package de.lieser_online;

public class Interactors {
    public int countWords(String text) {
        var words = WordCount.splitIntoWords(text);
        var numberOfWords = WordCount.count(words);
        return numberOfWords;
    }
}
