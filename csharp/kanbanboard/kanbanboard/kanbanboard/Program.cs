namespace kanbanboard
{
    public static class Program
    {
        static void Main(string[] args) {
            var interactor = new Interactor();
            var ui = new Ui();

            ui.OnNewTicket += text => {
                interactor.NewTicket(text);
            };
            
            interactor.Start(
                board =>  ui.DisplayBoard(board) 
            );
            
            ui.Run();
        }
    }
}