using System.Collections.Generic;

namespace kanbanboard
{
    public class Board
    {
        public Board(IEnumerable<Column> columns, IEnumerable<Ticket> tickets) {
            Columns = columns;
            Tickets = tickets;
        }

        public IEnumerable<Column> Columns { get; }

        public IEnumerable<Ticket> Tickets { get; }
    }
}