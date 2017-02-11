using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOOAD
{
    class TicketIterator
    {
        TicketList myList;
        int position = 0;
        bool solved;

        public TicketIterator(TicketList List, bool solved)
        {
            myList = List;
            while ((position < myList.NumberOfTickets) && (myList.getInfo(position).Solved == solved))
            {
                position++;
            }
        }
        public bool hasNext()
        {
            if (position < myList.NumberOfTickets)
                return true;
            return false;
        }

        public object next()
        {
            Ticket tick = myList.getInfo(position);
            position++;
            while ((position < myList.NumberOfTickets) && (myList.getInfo(position).Solved == solved))
            {
                position++;
            }
            return tick;
        }
    }
}
