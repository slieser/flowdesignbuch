using System.Collections.Generic;

namespace kanbanboard
{
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
}