package org.example;

public class App
{
    public static void main( String[] args )
    {
        Interactors interactors = new Interactors();
        ConsoleUi consoleUi = new ConsoleUi();

        interactors.Start(
            time -> {
                consoleUi.UhrzeitAnzeigen(time);
            },
            weckerZustand -> {
                consoleUi.ZustandSetzen(weckerZustand);
            }
        );

        consoleUi.Readline();
    }
}
