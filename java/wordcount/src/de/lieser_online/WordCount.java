package de.lieser_online;

import java.util.ArrayList;
import java.util.List;
import java.util.regex.Pattern;

public class WordCount {
    public static List<String> splitIntoWords(String text) {
        var pattern = Pattern.compile("[a-zA-Z]+");
        var words = new ArrayList<String>();
        var matcher = pattern.matcher(text);
        while (matcher.find()) {
            words.add(matcher.group());
        }
        return words;
    }

    public static int count(List<String> words) {
        return words.size();
    }
}
