package org.example;

import java.time.ZonedDateTime;

public class App
{
    public static void main( String[] args )
    {
        Interactors interactors = new Interactors();
        ConsoleUi consoleUi = new ConsoleUi();

        consoleUi.ClearScreen();
        interactors.Start(
            time -> {
                consoleUi.UhrzeitAnzeigen(time);
            },
            weckerZustand -> {
                consoleUi.ZustandSetzen(weckerZustand);
            }
        );

        ZonedDateTime weckzeit = consoleUi.WeckzeitLesen();
        interactors.StartMitWeckzeit(
            weckzeit,
            duration -> {
                consoleUi.RestzeitAnzeigen(duration);
            },
            weckerZustand -> {
                consoleUi.ZustandSetzen(weckerZustand);
            }
        );
    }
}
