package de.lieser_online;

public class Main {

    public static void main(String[] args) {
        ConsoleUi ui = new ConsoleUi();

        Interactors.start(
                args,
                (locstat) -> ui.showLoc(locstat),
                () -> ui.showSum());
    }

}
