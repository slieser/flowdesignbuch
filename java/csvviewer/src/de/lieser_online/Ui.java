package de.lieser_online;

import java.util.*;

public class Ui {
    private Interactors interactors;

    public Ui(Interactors interactors) {
        this.interactors = interactors;
    }

    public void Show(List<Record> records) {
        for (var record: records) {

        }
    }

    public void Run() {
        var exit = false;

        while(!exit) {
            var ch = ReadKey();
            switch(ch) {
                case 'e':
                    exit = true;
                    break;
                case 'f': {
                    var records = interactors.FirstPage();
                    Show(records);
                    break;
                }
                case 'p': {
                    var records = interactors.PrevPage();
                    Show(records);
                    break;
                }
                case 'n': {
                    var records = interactors.NextPage();
                    Show(records);
                    break;
                }
                case 'l': {
                    var records = interactors.LastPage();
                    Show(records);
                    break;
                }
            }
        }
    }

    private char ReadKey() {
        return 'e';
    }
}
