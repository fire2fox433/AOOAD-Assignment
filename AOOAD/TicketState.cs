using System;
using System.Collections.Generic;
namespace AOOAD
{
	public interface TicketState
	{
		void share(ITSupportMember member);
		void reopen();
		void closeTicket();
		void commentTicket(string comment, ITSupportMember member);
		void assignPriority(int priorty);
		void assignMember(ITSupportMember member);
	}
}
