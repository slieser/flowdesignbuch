package org.example;

import java.time.Duration;
import java.time.ZonedDateTime;

public class Wecker {
    public WeckerZustand IstGestoppt() {
        return WeckerZustand.Gestoppt;
    }

    public WeckerZustand IstGestartet() {
        return WeckerZustand.Geatartet;
    }

    public Duration RestzeitBerechnen(ZonedDateTime weckzeit, ZonedDateTime uhrzeit) {
        return Duration.between(uhrzeit, weckzeit);
    }

    public void WennRestZeitAbgelaufen(Duration restzeit, Runnable onAlarm) {
        if(restzeit.getSeconds() <= 0) {
            onAlarm.run();
        }
    }
}
