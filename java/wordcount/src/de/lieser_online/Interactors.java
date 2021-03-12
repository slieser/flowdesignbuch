package de.lieser_online;

import java.util.List;

public class Interactors {
    public int CountWords(String text) {
        List<String> words = WordCount.splitIntoWords(text);
        int numberOfWords = WordCount.count(words);
        return numberOfWords;
    }
}
