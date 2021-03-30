package de.lieser_online;

import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.assertArrayEquals;

class WordCountTests {

    @Test
    void splitIntoWords() {
        var result = WordCount.splitIntoWords("Mary had a little lamb.");
        assertArrayEquals(new String[]{"Mary", "had", "a", "little", "lamb"}, result.toArray());
    }
}