package de.lieser_online;

import java.io.File;
import java.util.function.Consumer;

public class FilesystemProvider {
    public static void GetSourcecodeFiles(String directory, Consumer<String> onFilename, Runnable onFinished) {
        Walk(directory, onFilename);
        onFinished.run();
    }

    private static void Walk(String directory, Consumer<String> onFilename) {
        File root = new File(directory);
        File[] list = root.listFiles();

        if (list == null) return;

        for (File file : list) {
            if (file.isDirectory()) {
                Walk(file.getAbsolutePath(), onFilename);
            } else if (file.getAbsolutePath().endsWith(".java")){
                onFilename.accept(file.getAbsolutePath());
            }
        }
    }
/*
    public static void GetSourcecodeFiles(String directory, Consumer<String> onFilename, Runnable onFinished) {
        try {
            Files.walk(Paths.get(directory))
                .filter(path -> Files.isRegularFile(path) && path.toString().endsWith(".java"))
                .forEach((path) -> onFilename.accept(path.toAbsolutePath().toString()));
            onFinished.run();
        } catch (Exception e) {
            throw new RuntimeException();
        }
    }
*/
}
