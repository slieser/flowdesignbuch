using System;

namespace fallunterscheidung
{
    public class AlarmClock
    {
        public void WhenAlarmTimeArrives(TimeSpan remainingTime, Action onAlarmTime) {
            if (remainingTime.TotalSeconds <= 0) {
                onAlarmTime();
            }
        }

        public bool AlarmTimeArrives(TimeSpan remainingTime) {
            return remainingTime.TotalSeconds <= 0;
        }
        
        public void Alarm() {
            var remainingTime = GetRemainingTime();
            WhenAlarmTimeArrives(remainingTime,
                () => {
                    Console.WriteLine("Alarm!");
                });
        }

        public void Alarm2() {
            var remainingTime = GetRemainingTime();
            if (AlarmTimeArrives(remainingTime)) {
                 Console.WriteLine("Alarm!");
            }
        }

        private static TimeSpan GetRemainingTime() {
            return new TimeSpan();
        }
    }
}