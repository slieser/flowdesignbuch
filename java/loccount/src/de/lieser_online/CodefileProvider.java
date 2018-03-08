package de.lieser_online;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.List;

public class CodefileProvider {
    public static List<String> ReadFile(String filename) {
        try {
            return Files.readAllLines(Paths.get(filename));
        } catch (IOException e) {
            throw new RuntimeException();
        }
    }
}
