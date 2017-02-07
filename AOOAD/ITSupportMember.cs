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
    //public class TicketList:Subject
    //{
    //    private List<Observer> observers;
    //    private string comment;

    //    public TicketList()
    //    {
    //        observers = new List<Observer>();
    //    }

    //    public void registerObserver(Observer o)
    //    {
    //        observers.Add(o);
    //    }

    //    public void removeObserver(Observer o)
    //    {
    //        observers.Remove(o);
    //    }

    //    public void notifyObservers()
    //    {
    //        foreach (Observer o in observers)
    //            o.update(comment);
    //    }
    //    public void measurementsChanged()
    //    {
    //        notifyObservers();
    //    }
    //}
}
