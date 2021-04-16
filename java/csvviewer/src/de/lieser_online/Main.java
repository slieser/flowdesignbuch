package de.lieser_online;

public class Main {

    public static void main(String[] args) {
        var interactors = new Interactors();
        var ui = new Ui(interactors);

        var records = interactors.start(args);
        ui.Show(records);

        ui.Run();
    }
}
