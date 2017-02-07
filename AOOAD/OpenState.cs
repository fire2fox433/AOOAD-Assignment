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
			this.myTicket.sharedList.Add(member);
			Console.WriteLine("The ticket was shared to " + member.userID + ".");
		}
		public void reopen()
		{
			Console.WriteLine("The ticket is open, you cannot reopen on open ticket.");
		}
		public void closeTicket()
		{
			myTicket.setStatus(myTicket.cLOSE);
			Console.WriteLine("The ticket has been closed.");
		}
		public void commentTicket(string comment)
		{
			myTicket.comments.Add(comment);
			Console.WriteLine("Comment successfully added");
		}
		public void assign(int priority)
		{
			myTicket.Priority = priority;
			Console.WriteLine("The ticket's priority has successfully be assigned");
		}
	}
}
