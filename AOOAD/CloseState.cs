using System;
using System.Collections.Generic;
namespace AOOAD
{
	public class CloseState : TicketState
	{
		private Ticket myTicket;
		public CloseState(Ticket ticket)
		{
			myTicket = ticket;
		}
		public void share(ITSupportMember member)
		{
			Console.WriteLine("You cannot share when the ticket is closed.");
		}
		public void reopen()
		{
			if (myTicket.Solved == false)
			{
				myTicket.setStatus(myTicket.oPEN);
				Console.WriteLine("The ticket is opened.");
			}
			else
			{
				Console.WriteLine("The ticket is already solved! You cannot reopen it!");
			}
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
