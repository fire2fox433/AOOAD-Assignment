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
		public void commentTicket(string comment, ITSupportMember member)
		{
            bool commentStatus = false;
            for (int i = 0; i < myTicket.sharedList.Count; i++)
            {
                if (myTicket.sharedList[i] == member)
                {
                    commentStatus = true;
                    myTicket.comments.Add(comment);
                    Console.WriteLine("Comment succesfully added!");
                }
            }
            if (commentStatus == false)
            {
                Console.WriteLine("This member is not shared to this ticket!");
            }
			myTicket.comments.Add(comment);
			Console.WriteLine("Comment successfully added");
		}
		public void assignPriority(int priority)
		{
			myTicket.Priority = priority;
			Console.WriteLine("The ticket's priority has successfully be assigned");
		}
		public void assignMember(ITSupportMember member)
		{
			if (myTicket.incharge != null)
            {
                myTicket.incharge = member;
                Console.WriteLine("IT support member has successfully been assigned.");
            }
            else
            {
                Console.WriteLine("IT Support Member, " + myTicket.incharge.userID + "is already in charge, would you like to replace this user?");
                string choice = Console.ReadLine();
                if (choice == "Y" || choice == "y" || choice == "Yes" || choice == "YES" || choice == "yes")
                {
                    myTicket.incharge = member;
                    Console.WriteLine("The member in charge of this ticket has successfully been changed");
                }
                else if (choice == "N" || choice == "n" || choice == "NO" || choice == "no" || choice == "No")
                {
                    Console.WriteLine("The member in charge of this ticket is not changed.");
                }
                else
                {
                    Console.WriteLine("Your input was incorrect, exiting...");
                }
            }
		}
	}
}
