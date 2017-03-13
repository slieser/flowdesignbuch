using System;
using System.Text;

namespace csvviewer
{
    public class Program
    {
        public static void Main(string[] args) {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var interactors = new Interactors();
            var ui = new Ui();

            Action start = () => {
                var records = interactors.Start(args);
                ui.Display(records);
            };

            ui.MoveNext += () => {
                var records = interactors.MoveNext();
                ui.Display(records);
            };
            ui.MovePrev += () => {
                var records = interactors.MovePrev();
                ui.Display(records);
            };

            start();
            ui.Run();
        }
    }
}