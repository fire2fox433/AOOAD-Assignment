using System;
using System.Collections.Generic;

namespace AOOAD
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			List<Ticket> ticketList = new List<Ticket>();
			List<User> userList = new List<User>();
			User newUser = new ITSupportMember("123", "123", "123", "123", "123");
			userList.Add(newUser);
			newUser = new ITSupportMember("234", "123", "123", "123", "123");
			userList.Add(newUser);
			List<Report> reportList = new List<Report>();
			User loggedinuser = null;
			while (loggedinuser == null)
			{
				Console.WriteLine("Please login \n Username: ");
				string username = Console.ReadLine();
				Console.WriteLine("Password: ");
				string password = Console.ReadLine();
				for (int i = 0; i < userList.Count; i++)
				{
					if (userList[i].userID == username && userList[i].Password == password)
					{
						loggedinuser = userList[i];
						Console.WriteLine("You have successfully logged in!");
						break;
					}
				}
				if (loggedinuser == null)
				{
					Console.WriteLine("Error, no such user found.");
				}
			}
		}
		void Itmenu()
		{
			Console.WriteLine("-----------------------------");
			Console.WriteLine("1.Login");
			Console.WriteLine("2. Share a ticket");
		}

	}

		



}
