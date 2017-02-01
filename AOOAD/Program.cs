using System;
using System.Collections.Generic;

namespace AOOAD
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int lastTicketNo = 0;
			List<ITSupportMember> itSupportList = new List<ITSupportMember>();
			ITSupportMember member = new ITSupportMember("fire2fox433");
			itSupportList.Add(member);
			Ticket newTicket = new Ticket(member, lastTicketNo + 1);
			ITSupportMember currentUser = member;

		}
	}
	public class Ticket
	{
		private int ticketID;
		private ITSupportMember raisedBy;
		private List<ITSupportMember> sharedList = new List<ITSupportMember>();
		public Ticket(ITSupportMember raisedBy, int ticketID)
		{
			this.raisedBy = raisedBy;
			this.ticketID = ticketID;
		}
		public void share(ITSupportMember member)
		{
			sharedList.Add(member);
		}
	}
	public class ITSupportMember
	{
		public string userID { get; set; }
		public List<Ticket> TicketList = new List<Ticket>();
		public ITSupportMember(string userID)
		{
			this.userID = userID;
		}
		public void addTicket(Ticket ticket)
		{
			TicketList.Add(ticket);
		}
	}

}
