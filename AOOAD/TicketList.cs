using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOOAD
{
    class TicketList
    {
        private int numberofTickets = 0;
        Ticket[] tickets;

        public TicketList(int size)
        {
            tickets = new Ticket[size];
        }

        public TicketIterator createIterator(bool solved)
        {
            return new TicketIterator(this, solved);
        }
        public int NumberOfTickets
        {
            get { return numberofTickets; }
        }

        public void add(Ticket tick)
        {
            tickets[numberofTickets] = tick;
            numberofTickets++;
        }

        public Ticket getInfo(int index)
        {
            return tickets[index];
        }
    }
}
