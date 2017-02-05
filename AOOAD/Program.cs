using System;
using System.Collections.Generic;

namespace AOOAD
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			
			List<Ticket> ticketList = new List<Ticket>();

			List<ITSupportMember> ITSupportMemberList = new List<ITSupportMember>();
			ITSupportMember newUser = new ITSupportMember("123", "123", "123", "123", "123");
			Ticket newTicket = new Ticket("123", "123", "blue screen of death", "windows", " ", newUser, null , "fking bad", 10 ,null);
			ITSupportMemberList.Add(newUser);
			ticketList.Add(newTicket);
			newUser = null;
			newUser = new ITSupportMember("234", "123", "123", "123", "123");
			ITSupportMemberList.Add(newUser);
			List<Report> reportList = new List<Report>();
			List<Employee> employeeList = new List<Employee>();
			List<Admin> adminList = new List<Admin>();
			List<ReportManager> managerList = new List<ReportManager>();
			bool loggedin = false;
			ITSupportMember loggedinIT = null;
			Employee loggedinEmployee = null;
			ReportManager loggedinManager = null;
			Admin loggedinAdmin = null;
			while (loggedin == false)
			{
				Console.WriteLine("Please login \n Username: ");
				string username = Console.ReadLine();
				Console.WriteLine("Password: ");
				string password = Console.ReadLine();
				for (int i = 0; i < ITSupportMemberList.Count; i++)
				{
					if (ITSupportMemberList[i].userID == username && ITSupportMemberList[i].Password == password)
					{
						loggedinIT = ITSupportMemberList[i];
						Console.WriteLine("You have successfully logged in!");
						loggedin = true;
						break;
					}
				}
				for (int i = 0; i < employeeList.Count; i++)
				{
					if (employeeList[i].userID == username && employeeList[i].Password == password)
					{
						loggedinEmployee = employeeList[i];
						Console.WriteLine("You have successfully logged in!");
						loggedin = true;
						break;
					}
				}
				for (int i = 0; i < managerList.Count; i++)
				{
					if (managerList[i].userID == username && managerList[i].Password == password)
					{
						loggedinManager = managerList[i];
						Console.WriteLine("You have successfully logged in!");
						loggedin = true;
						break;
					}
				}
				for (int i = 0; i < adminList.Count; i++)
				{
					if (adminList[i].userID == username && adminList[i].Password == password)
					{
						loggedinAdmin = adminList[i];
						Console.WriteLine("You have successfully logged in!");
						loggedin = true;
						break;
					}
				}

				if (loggedin == false)
				{
					Console.WriteLine("Error, no such user found.");
				}
			}
			if (loggedinIT != null)
			{
				Itmenu();
				string option = Console.ReadLine();
				if (option == "1")
				{
					List<Ticket> openList = new List<Ticket>();
					Console.WriteLine("No.\tTicket ID\tTicket Desc.\t\tSolved");
					int no = 0;
					for (int i = 0; i < ticketList.Count; i++)
					{
						if (ticketList[i].viewStatus() == "open")
						{
							no = no + 1;
							openList.Add(ticketList[i]);
							Console.WriteLine(no + "\t" + ticketList[i].TicketID + "\t\t" + ticketList[i].Problem_desc + "\t" + ticketList[i].Solved);

						}
					}
					string ticketOption = "0";
					while (true)
					{
						Console.WriteLine("Please enter the ticket you want to pick: ");
						ticketOption = Console.ReadLine();
						if (openList.Count < Convert.ToInt32(ticketOption) || Convert.ToInt32(ticketOption) < 1)
						{
							Console.WriteLine("Invalid ticket option!");
						}
						else {
							break;
						}
					}
					Ticket selectedShareTicket = openList[Convert.ToInt32(ticketOption) - 1];
					bool sharesuccess = false;
					while (sharesuccess == false)
					{
						string shareusername = loggedinuser.userID;
						while (shareusername == loggedinuser.userID)
						{
							Console.WriteLine("Please enter the username you want to share to: ");
							shareusername = Console.ReadLine();
							if (shareusername == loggedinuser.userID)
							{
								Console.WriteLine("You cannot share to yourself!");
							}

						}
						for (int i = 0; i < ITSupportMemberList.Count; i++)
						{
							if (ITSupportMemberList[i].userID == shareusername)
							{
								for (int y = 0; y < ticketList.Count; y++)
								{
									if (ticketList[y] == selectedShareTicket)
									{
										ticketList[y].sharedList.Add(ITSupportMemberList[i]);
										ITSupportMemberList[i].sharedList.Add(ticketList[y]);
										sharesuccess = true;
									}
								}
							}
							else
							{
								continue;
							}
						}
						if (sharesuccess == false)
						{
							Console.WriteLine("No such username exists!");
						}
						else if (sharesuccess == true)
						{
							Console.WriteLine("Ticket shared successfully, would you like to share to another IT support staff?(Y/N)");
							string yorn = Console.ReadLine();
							if (yorn == "Y")
								sharesuccess = false;
							else
								break;
						}
					}


				}

			}
			else if (loggedinAdmin != null)
			{
			}
			else if (loggedinManager != null)
			{
			}
			else if (loggedinEmployee != null)
			{
			}








		}
		public static void Itmenu()
		{
			Console.WriteLine("-----------------------------");
			Console.WriteLine("1. Share a ticket");
			Console.WriteLine("Please enter your preferred option: ");
		}



	}


		



}
