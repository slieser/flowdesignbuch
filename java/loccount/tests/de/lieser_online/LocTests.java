package de.lieser_online;

import org.junit.Test;

import java.util.Arrays;
import java.util.List;

import static org.junit.Assert.assertEquals;

public class LocTests {
    @Test
    public void LocStat_is_created_with_correct_values() {
        List<String> lines = Arrays.asList("code", "   ", "   // comment");
        LocStat result = Loc.CountLines("xyz", lines);

        assertEquals("xyz", result.Filename);
        assertEquals(3, result.Total);
        assertEquals(1, result.Loc);
    }
}
