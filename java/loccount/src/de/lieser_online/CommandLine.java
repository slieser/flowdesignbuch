package de.lieser_online;

import java.io.File;

public class CommandLine {
    public static String getDirectory(String[] args) {
        return args.length > 0 ? args[0] : currentDirectory();
    }

    private static String currentDirectory() {
        return "." + File.separator;
    }
}
