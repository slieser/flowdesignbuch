package de.lieser_online;

public class CommandLine {
    public static String GetPath(String[] args) {
        return args.length > 0 ? args[0] : "./";
    }
}
