package de.lieser_online;

import java.util.List;

public class Main {

    public static void main(String[] args) {
        ConsoleUi ui = new ConsoleUi();

	    String directory = CommandLine.GetDirectory(args);
        FilesystemProvider.GetSourcecodeFiles(directory,
            filename -> {
                List<String> lines = CodefileProvider.ReadFile(filename);
                LocStat locstat = Loc.CountLoc(filename, lines);
                ui.ShowLoc(locstat);
            },
            () -> {
                ui.ShowSum();
            });
    }
}
