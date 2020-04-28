package de.lieser_online;

public class Main {

    public static void main(String[] args) {
        ConsoleUi ui = new ConsoleUi();

        Interactors.Start(
                args,
                locstat -> ui.ShowLoc(locstat),
                () -> ui.ShowSum());
    }

}
