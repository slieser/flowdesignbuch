package de.lieser_online;

import java.util.List;
import java.util.function.Consumer;

public class Interactors {
    public static void Start(String[] args, Consumer<LocStat> onLocStat, Runnable onFinished) {
        String path = CommandLine.GetPath(args);
        FilesystemProvider.FindSourceFilenames(path,
            filename -> {
                List<String> lines = CodefileProvider.ReadFile(filename);
                LocStat locstat = Loc.CountLines(filename, lines);
                onLocStat.accept(locstat);
            },
            () -> {
                onFinished.run();
            });
    }
}
