package de.lieser_online;

import java.util.List;

public class Loc {
    public static LocStat CountLines(String filename, List<String> lines) {
        LocStat result = new LocStat();

        result.Filename = filename;
        result.Total = lines.size();
        result.Loc = lines
                .stream()
                .filter(line -> isNotACodeLine(line))
                .count();

        return result;
    }

    private static boolean isNotACodeLine(String line) {
        String trimmedLine = line.trim();
        return !(trimmedLine.isEmpty() || trimmedLine.startsWith("//"));
    }
}
