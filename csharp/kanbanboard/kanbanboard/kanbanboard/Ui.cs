using System;

namespace kanbanboard
{
    public class Ui
    {
        public event Action<string> OnNewTicket;
        public void DisplayBoard(Board board) {
            Console.WriteLine("Columns:");
            foreach (var column in board.Columns) {
                Console.WriteLine($"  {column.Titel} ({column.WIPLimit})");
            }
            Console.WriteLine("Tickets:");
            foreach (var ticket in board.Tickets) {
                Console.WriteLine($"  {ticket.Id}: '{ticket.Text}', {ticket.ColumnIndex}/{ticket.Position}");
            }
        }

        public void Run() {
            do {
                Console.Write("Enter text for new ticket (or <Return> for exit): ");
                var text = Console.ReadLine();
                if (text == "") {
                    break;
                }

                OnNewTicket(text);
            } while (true);
        }
    }
}