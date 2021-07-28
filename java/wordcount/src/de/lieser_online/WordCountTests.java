package de.lieser_online;

import org.junit.Test;

import static org.junit.Assert.assertArrayEquals;

class WordCountTests {

    @Test
    void splitIntoWords() {
        List<String> result = WordCount.splitIntoWords("Mary had a little lamb.");
        assertArrayEquals(new String[]{"Mary", "had", "a", "little", "lamb"}, result.toArray());
    }
}