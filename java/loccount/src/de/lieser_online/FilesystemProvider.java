package de.lieser_online;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.function.Consumer;

public class FilesystemProvider {
    public static void findSourceFilenames(String directory, Consumer<String> onFilename, Runnable onFinished) {
        walk(directory, onFilename);
        onFinished.run();
    }

    private static void walk(String directory, Consumer<String> onFilename) {
        File root = new File(directory);
        File[] list = root.listFiles();

        if (list == null) return;

        for (File file : list) {
            if (file.isDirectory()) {
                walk(file.getAbsolutePath(), onFilename);
            } else if (file.getAbsolutePath().endsWith(".java")){
                try {
                    onFilename.accept(file.getCanonicalPath());
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            }
        }
    }

    public static void findSourcecodeFiles(String directory, Consumer<String> onFilename, Runnable onFinished) {
        try {
            Files.walk(Paths.get(directory))
                .filter(path -> Files.isRegularFile(path) && path.toString().endsWith(".java"))
                .forEach((filename) -> onFilename.accept(filename.toAbsolutePath().toString()));
            onFinished.run();
        } catch (Exception e) {
            throw new RuntimeException();
        }
    }
}
