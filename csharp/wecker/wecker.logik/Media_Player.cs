using System.Media;

namespace wecker.logik
{
    public static class Media_Player
    {
        public static void Alarm_abspielen() {
            var player = new SoundPlayer {
                SoundLocation = @"C:\Windows\media\Alarm02.wav"
            };
            player.Play();
        }
    }
}