package de.lieser_online;

import java.util.List;

public class Loc {
    public static LocStat countLines(String filename, List<String> lines) {
        LocStat result = new LocStat();

        result.Filename = filename;
        result.Total = lines.size();
        result.Loc = lines
                .stream()
                .filter(line -> isACodeLine(line))
                .count();

        return result;
    }

    static boolean isACodeLine(String line) {
        String trimmedLine = line.trim();
        return !(trimmedLine.isEmpty() || trimmedLine.startsWith("//"));
    }
}
