package org.example;

import java.time.ZonedDateTime;
import java.util.function.Consumer;

public class Interactors {
    public void Start(Consumer<ZonedDateTime> onTime, Consumer<WeckerZustand> onZustand) {
        TimerProvider timerProvider = new TimerProvider();
        UhrzeitProvider uhrzeitProvider = new UhrzeitProvider();
        Wecker wecker = new Wecker();

        timerProvider.Start(() -> {
            ZonedDateTime uhrzeit = uhrzeitProvider.LeseUhrzeit();
            onTime.accept(uhrzeit);
        });
        onZustand.accept(wecker.IstGestoppt());
    }
}
