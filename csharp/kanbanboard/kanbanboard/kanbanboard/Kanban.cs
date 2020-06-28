using System.Collections.Generic;
using System.Linq;

namespace kanbanboard
{
    public static class Kanban
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
}