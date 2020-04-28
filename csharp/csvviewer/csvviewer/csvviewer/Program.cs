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

            ui.MoveFirst += () => {
                var records = interactors.FirstPage();
                ui.Display(records);
            };
            ui.MovePrev += () => {
                var records = interactors.PrevPage();
                ui.Display(records);
            };
            ui.MoveNext += () => {
                var records = interactors.NextPage();
                ui.Display(records);
            };
            ui.MoveLast += () => {
                var records = interactors.LastPage();
                ui.Display(records);
            };

            Start();
            ui.Run();
        }
    }
}