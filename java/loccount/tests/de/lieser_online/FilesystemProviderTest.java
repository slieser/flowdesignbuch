package de.lieser_online;

import org.testng.annotations.Test;

import java.util.ArrayList;
import java.util.List;


import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertTrue;

public class FilesystemProviderTest {
    @Test
    public void example_files_are_found() {
        List<String> result = new ArrayList<String>();
        FilesystemProvider.findSourceFilenames(
                "./tests/de/lieser_online/testdata",
                filename -> { result.add(filename); },
                () -> { result.add("finished");});
        assertEquals(3, result.size());
        assertTrue(result.get(0).endsWith("testdata/subdir1/Test2.java"));
        assertTrue(result.get(1).endsWith("testdata/Test1.java"));
        assertTrue(result.get(2).endsWith("finished"));
    }
}
