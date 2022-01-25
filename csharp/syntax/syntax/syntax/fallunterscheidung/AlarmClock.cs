using System;

namespace syntax.fallunterscheidung
{
    public class AlarmClock
    {
        public static void WhenAlarmTimeIsReached(TimeSpan remainingTime, Action onAlarmTime) {
            if (remainingTime <= new TimeSpan()) {
                onAlarmTime();
            }
        }

        public void Alarm() {
            var remainingTime = GetRemainingTime();
            WhenAlarmTimeIsReached(remainingTime,
                () => {
                    Console.WriteLine("Alarm!");
                });
        }

        private TimeSpan GetRemainingTime() {
            throw new NotImplementedException();
        }
    }

    public class AlarmClock2
    {
        public static bool AlarmTimeIsReached(TimeSpan remainingTime) {
            return remainingTime <= new TimeSpan();
        }

        public void Alarm1() {
            var remainingTime = GetRemainingTime();
            if (AlarmTimeIsReached(remainingTime)) {
                Console.WriteLine("Alarm!");
            }
        }

        public void Alarm() {
            var remainingTime = GetRemainingTime();
            if (remainingTime <= new TimeSpan()) {
                Console.WriteLine("Alarm!");
            }
        }

        private TimeSpan GetRemainingTime() {
            throw new NotImplementedException();
        }
    }
}