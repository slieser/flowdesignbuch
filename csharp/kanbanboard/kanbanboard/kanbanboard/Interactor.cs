using System;

namespace kanbanboard
{
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
}