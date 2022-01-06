package de.lieser_online;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class CommandLineTests {
    @Test
    public void first_argument_is_returned_as_directory() {
        assertEquals("1", CommandLine.getDirectory(new String[] {"1", "2"}));
    }

    @Test
    public void current_directory_is_returned_if_args_is_empty() {
        assertEquals("./", CommandLine.getDirectory(new String[] {}));
    }
}
