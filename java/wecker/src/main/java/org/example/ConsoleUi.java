package org.example;

import java.time.ZonedDateTime;
import java.util.Scanner;

public class ConsoleUi {
    public void UhrzeitAnzeigen(ZonedDateTime time) {
        System.out.println(time.toLocalTime());
    }

    public void ZustandSetzen(WeckerZustand weckerZustand) {
        System.out.println("Wecker ist " + weckerZustand);
    }

    public void Readline() {
        Scanner s = new Scanner(System.in);
        String string = s.nextLine();
    }
}
