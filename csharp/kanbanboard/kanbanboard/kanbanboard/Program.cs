using System;
using System.Collections.Generic;
using System.Linq;

namespace kanbanboard
{
    class Program
    {
        static void Main(string[] args) {
            var interactor = new Interactor();
            var ui = new Ui();

            ui.OnNewTicket += text => {
                interactor.NewTicket(text);
            };
            
            interactor.Start(board => { ui.DisplayBoard(board); });
            ui.Run();
        }
    }

    public class Interactor
    {
        private readonly PublishSubscribe _publishSubscribe = new PublishSubscribe();
        private readonly TicketProvider _ticketProvider = new TicketProvider();

        public void Start(Action<Board> onUpdate) {
            var columns = BoardConfig.Read();
            _publishSubscribe.Subscribe(() => {
                var tickets = _ticketProvider.ReadAllTickets();
                var board = new Board(columns, tickets);
                onUpdate(board);
            });
        }

        public void NewTicket(string text) {
            var id = Id.New();
            var column = Kanban.GetColumnIndexForNewTicket();
            var tickets = _ticketProvider.ReadAllTickets();
            var position = Kanban.GetPositionForNewTicket(column, tickets);
            var ticket = new Ticket {
                Id = id,
                ColumnIndex = column,
                Position = position,
                Text = text
            };
            _ticketProvider.Insert(ticket);
            _publishSubscribe.Publish();
        }
    }

    public class Kanban
    {
        public static int GetColumnIndexForNewTicket() {
            return 0;
        }

        public static int GetPositionForNewTicket(int column, IEnumerable<Ticket> tickets) {
            var numberOfTickets =
                (from ticket in tickets
                where ticket.ColumnIndex == column
                select ticket).Count();
            return numberOfTickets + 1;
        }
    }

    public class Id
    {
        public static string New() {
            return Guid.NewGuid().ToString();
        }
    }

    public class TicketProvider
    {
        private readonly List<Ticket> _tickets = new List<Ticket>();

        public IEnumerable<Ticket> ReadAllTickets() {
            return _tickets;
        }

        public void Insert(Ticket newTicket) {
            _tickets.Add(newTicket);
        }
    }

    public class PublishSubscribe
    {
        private Action _onPublish;

        public void Subscribe(Action onPublish) {
            _onPublish = onPublish;
            _onPublish();
        }

        public void Publish() {
            _onPublish();
        }
    }

    public class BoardConfig
    {
        public static IEnumerable<Column> Read() {
            yield return new Column { Titel = "ready", WIPLimit = 0};
            yield return new Column { Titel = "doing", WIPLimit = 3};
            yield return new Column { Titel = "done", WIPLimit = 0};
        }
    }

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

    public class Board
    {
        public Board(IEnumerable<Column> columns, IEnumerable<Ticket> tickets) {
            Columns = columns;
            Tickets = tickets;
        }

        public IEnumerable<Column> Columns { get; }

        public IEnumerable<Ticket> Tickets { get; }
    }

    public class Column
    {
        public string Titel { get; set; }

        public int WIPLimit { get; set; }
    }

    public class Ticket
    {
        public string Text { get; set; }

        public string Id { get; set; }

        public int ColumnIndex { get; set; }

        public int Position { get; set; }
    }
}