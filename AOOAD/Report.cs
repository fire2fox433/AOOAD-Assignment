using System;
using System.Collections.Generic;
namespace AOOAD
{
	public class Report
	{
		private List<Ticket> ticketList;
		private string description;
		private string status;
		private DateTime open_time;
		private DateTime update_time;
		public Report(List<Ticket> ticketList, string description, string status)
		{
			this.ticketList = ticketList;
			this.description = description;
			this.status = status;
			this.open_time = DateTime.Now;
		}
	}
}
