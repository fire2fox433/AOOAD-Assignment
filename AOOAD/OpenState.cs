using System;
using System.Collections.Generic;
namespace AOOAD
{
	public class OpenState : TicketState
	{
		private Ticket myTicket;
		public OpenState(Ticket ticket)
		{
			myTicket = ticket;
		}
		public void share(ITSupportMember member)
		{
			Console.WriteLine("You cannot share when the ticket is closed.");
		}
		public void reopen()
		{
			myTicket.setStatus(myTicket.oPEN);
			Console.WriteLine("The ticket is opened.");
		}
		public void closeTicket()
		{
			Console.WriteLine("The ticket is already closed!");
		}
		public void commentTicket(string comment)
		{
			Console.WriteLine("You cannot comment on a closed ticket!");
		}
		public void assign(int priority, ITSupportMember member)
		{
			Console.WriteLine("You cannot assign someone to a closed ticket!");
		}
	}
}
