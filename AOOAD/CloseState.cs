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
			this.myTicket.sharedList.Add(member);
			Console.WriteLine("The ticket was shared to " + member.name + ".");
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
		public void assign(int priority, ITSupportMember member)
		{
			myTicket.Priority = priority;
			myTicket.Assignee = member;
			Console.WriteLine("The ticket has successfully be assigned");
		}
	}
}
