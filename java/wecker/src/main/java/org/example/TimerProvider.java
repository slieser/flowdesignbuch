package org.example;

import java.util.Timer;
import java.util.TimerTask;

public class TimerProvider {
    private Timer timer;

    public void Start(Runnable onTimer) {
        timer = new Timer();
        timer.scheduleAtFixedRate(new TimerTask() {
            @Override
            public void run() {
                onTimer.run();
            }
        }, 1000, 1000);
    }
}
