package de.lieser_online;

public class Main {

    public static void main(String[] args) {
        ConsoleUi ui = new ConsoleUi();
        Interactors.start(args, ui::showLoc, ui::showSum);
    }

    public static void demo(String[] args) {
        FilesystemProvider.findSourceFilenames("./",
                filename -> System.out.println(filename),
                () -> System.out.println("Finished!"));
    }

}
