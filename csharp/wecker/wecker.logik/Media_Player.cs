using System.Media;

namespace wecker.logik
{
    public class Media_Player
    {
        public void Alarm_abspielen() {
            var player = new SoundPlayer {
                SoundLocation = @"C:\Windows\media\Alarm02.wav"
            };
            player.Play();
        }
    }
}