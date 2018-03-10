package de.lieser_online;

import java.util.List;

public class Loc {
    public static LocStat CountLocStat(String filename, List<String> lines) {
        LocStat result = new LocStat();

        result.Filename = filename;
        result.Total = lines.size();
        result.Loc = lines
                .stream()
                .filter(line -> !isLoc(line))
                .count();

        return result;
    }

    private static boolean isLoc(String line) {
        String trimmedLine = line.trim();
        return trimmedLine.isEmpty() || trimmedLine.startsWith("//");
    }
}
