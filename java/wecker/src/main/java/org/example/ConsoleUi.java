package org.example;

import java.time.Duration;
import java.time.LocalTime;
import java.time.ZoneId;
import java.time.ZonedDateTime;
import java.time.format.DateTimeFormatter;
import java.util.Scanner;

public class ConsoleUi {
    public static void ClearScreen() {
        System.out.print("\033[H\033[2J");
        System.out.flush();
    }

    public void UhrzeitAnzeigen(ZonedDateTime time) {
        Gotoxy(0, 2);
        String result = DateTimeFormatter.ofPattern("HH:mm:ss").format(time);
        System.out.println(result);
    }

    public void RestzeitAnzeigen(Duration duration) {
        Gotoxy(0, 3);
        String result = DateTimeFormatter.ofPattern("HH:mm:ss").format(duration.addTo(LocalTime.of(0, 0)));
        System.out.println(result);
    }

    public void ZustandSetzen(WeckerZustand weckerZustand) {
        Gotoxy(0, 1);
        System.out.println("Wecker ist " + weckerZustand);
    }

    public ZonedDateTime WeckzeitLesen() {
        Scanner scanner = new Scanner(System.in);
        String eingabe = scanner.nextLine();

        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss").withZone(ZoneId.systemDefault());
        eingabe = ZonedDateTime.now().toLocalDate() + " " + eingabe;
        return ZonedDateTime.parse(eingabe, formatter);
    }

    private void Gotoxy(int x, int y) {
        char escCode = 0x1B;
        System.out.print(String.format("%c[%d;%df", escCode, y, x));
    }
}
