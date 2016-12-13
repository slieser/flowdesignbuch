using System;

namespace csvviewer
{
    public class Program
    {
        public static void Main(string[] args) {
            var interactors = new Interactors();
            var ui = new Ui();

            Action start = () => {
                var records = interactors.Start(args);
                ui.Display(records);
            };

            start();
        }
    }
}