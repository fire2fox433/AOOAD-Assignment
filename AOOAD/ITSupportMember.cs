using System;
using System.Collections.Generic;
namespace AOOAD
{
	public class ITSupportMember:User
	{
		public List<Ticket> ticketList = new List<Ticket>();
		public List<Ticket> sharedList = new List<Ticket>();
		public ITSupportMember(string id, string password, string first, string last, string email)
		{
			UserID = id;
			this.password = password;
			firstName = first;
			lastName = last;
			this.email = email;
			this.userType = "ITSupportMember";
		}
	}
}
