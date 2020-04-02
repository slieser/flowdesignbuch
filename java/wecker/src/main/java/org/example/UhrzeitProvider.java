package org.example;

import java.time.ZonedDateTime;

public class UhrzeitProvider {
    public ZonedDateTime LeseUhrzeit() {
        return ZonedDateTime.now();
    }
}
