package de.lieser_online;


import org.junit.jupiter.api.Test;
import java.util.Arrays;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

public class LocTests {
    @Test
    public void LocStat_object_is_created_with_correct_values() {
        List<String> lines = Arrays.asList("code", "   ", "   // comment");
        LocStat result = Loc.countLines("xyz", lines);

        assertEquals("xyz", result.Filename);
        assertEquals(3, result.Total);
        assertEquals(1, result.Loc);
    }

    @Test
    public void empty_lines_are_not_counted() {
        assertFalse(Loc.isACodeLine(""));
        assertFalse(Loc.isACodeLine(" "));
        assertFalse(Loc.isACodeLine("  "));
        assertFalse(Loc.isACodeLine("\t"));
        assertFalse(Loc.isACodeLine("\t\t"));
        assertFalse(Loc.isACodeLine("\t\t\t"));
        assertFalse(Loc.isACodeLine(" \t \t"));
    }

    @Test
    public void comment_lines_are_not_counted() {
        assertFalse(Loc.isACodeLine("//"));
        assertFalse(Loc.isACodeLine(" //"));
        assertFalse(Loc.isACodeLine("  //"));
        assertFalse(Loc.isACodeLine("\t//"));
        assertFalse(Loc.isACodeLine("\t\t//"));
        assertFalse(Loc.isACodeLine(" \t \t //"));
    }

    @Test
    public void non_empty_lines_are_counted() {
        assertTrue(Loc.isACodeLine("a"));
    }
}
