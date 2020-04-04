package org.example;

import java.time.Duration;
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

    public void StartMitWeckzeit(ZonedDateTime weckzeit, Consumer<Duration> onRestzeit, Consumer<WeckerZustand> onZustand) {
        TimerProvider timerProvider = new TimerProvider();
        UhrzeitProvider uhrzeitProvider = new UhrzeitProvider();
        Wecker wecker = new Wecker();
        AudioProvider audioProvider = new AudioProvider();

        onZustand.accept(wecker.IstGestartet());
        timerProvider.Start(() -> {
            ZonedDateTime uhrzeit = uhrzeitProvider.LeseUhrzeit();
            Duration restzeit = wecker.RestzeitBerechnen(weckzeit,  uhrzeit);
            onRestzeit.accept(restzeit);

            wecker.WennRestZeitAbgelaufen(
                restzeit,
                () -> {
                    timerProvider.Stop();
                    audioProvider.AudioAbspielen();
                    onZustand.accept(wecker.IstGestoppt());
                }
            );
        });
    }
}
