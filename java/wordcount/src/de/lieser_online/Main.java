package de.lieser_online;

public class Main {

    public static void main(String[] args) {
	  var consoleUi = new ConsoleUi();
	  var interactors = new Interactors();

	  var text = consoleUi.getText();
	  var numberOfWords = interactors.countWords(text);
	  consoleUi.showResult(numberOfWords);
    }
}
