package de.lieser_online;

import java.util.List;
import java.util.function.BiConsumer;
import java.util.function.Consumer;

public class Interactors {
    public static void start(String[] args, Consumer<LocStat> onLocStat, Runnable onFinished) {
        String path = CommandLine.getDirectory(args);
        FilesystemProvider.findSourceFilenames(path,
            filename -> {
                List<String> lines = CodefileProvider.readFile(filename);
                LocStat locstat = Loc.countLines(filename, lines);
                onLocStat.accept(locstat);
            },
            () -> {
                onFinished.run();
            });
    }
}
