package de.lieser_online;

import java.util.Scanner;

public class ConsoleUi {
    public String getText() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter your text: ");
        String result = scanner.nextLine();
        return result;
    }

    public void showResult(int numberOfWords) {
        System.out.println("Number of words: " + numberOfWords);
    }
}
