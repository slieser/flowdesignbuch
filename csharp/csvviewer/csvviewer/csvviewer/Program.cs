namespace csvviewer
{
    public class Program
    {
        public static void Main(string[] args) {
            var interactors = new Interactors();
            var ui = new Ui();

            void Start() {
                var records = interactors.Start(args);
                ui.Display(records);
            }

            ui.MoveNext += () => {
                var records = interactors.MoveNext();
                ui.Display(records);
            };
            ui.MovePrev += () => {
                var records = interactors.MovePrev();
                ui.Display(records);
            };

            Start();
            ui.Run();
        }
    }
}