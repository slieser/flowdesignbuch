package de.lieser_online;

import org.junit.Test;

import static org.junit.Assert.assertEquals;

public class CommandLineTests {
    @Test
    public void First_argument_is_given_as_path() {
        assertEquals("1", CommandLine.GetDirectory(new String[] {"1", "2"}));
    }

    @Test
    public void This_parth_is_given_if_args_is_empty() {
        assertEquals("./", CommandLine.GetDirectory(new String[] {}));
    }
}
