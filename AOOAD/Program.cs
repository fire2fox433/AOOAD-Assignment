﻿using System;
using System.Collections.Generic;

namespace AOOAD
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			
			List<Ticket> ticketList = new List<Ticket>();

			List<ITSupportMember> ITSupportMemberList = new List<ITSupportMember>();
            List<object> userList = new List<object>(); // new added v2 sean
            ITSupportMember newUser = new ITSupportMember("123", "123", "123", "123", "123");
            userList.Add(newUser); // added v2
            Ticket newTicket1 = new Ticket("123", "123", "blue screen of death", "windows", " ", newUser, null , "fking bad", 10 ,null); //added the 1 by ee zher
			ITSupportMemberList.Add(newUser);
			ticketList.Add(newTicket1); //added the 1 by ee zher
            Ticket newTicket2 = new Ticket("135", "135", "donezo", "Mac IOS", " ", newUser, null, "Super good", 0, null); //added v2 by ee zher
            newTicket2.Solved = true; //added v2 by ee zher
            ticketList.Add(newTicket2); //added v2 by ee zher
            newUser = null;
			newUser = new ITSupportMember("234", "123", "123", "123", "123");
			ITSupportMemberList.Add(newUser);
            userList.Add(newUser); // added v2
            List<Report> reportList = new List<Report>();
			List<Employee> employeeList = new List<Employee>();
			List<ReportManager> managerList = new List<ReportManager>();
			Admin adminAccount = Admin.getInstance("admin", "admin", "123", "123", "123"); // added by seanmarcus
            userList.Add(newUser); // added v2
            ReportManager newReportManager = new ReportManager("report", "report", "123", "123", "123"); // added by seanmarcus
            managerList.Add(newReportManager); // added by seanmarcus
            userList.Add(newUser); // added v2
            bool loggedin = false;
			ITSupportMember loggedinIT = null;
			Employee loggedinEmployee = null;
			ReportManager loggedinManager = null;
			Admin loggedinAdmin = null;
			while (loggedin == false)
			{
				Console.WriteLine("Please login \nUsername: ");
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
				if (loggedin == true)
				{
					break;
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
				if (loggedin == true)
				{
					break;
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
				if (loggedin == true)
				{
					break;
				}
				if (adminAccount.userID == username && adminAccount.Password == password)
				{
					loggedinAdmin = adminAccount;
					Console.WriteLine("Welcome Administrator.");
					loggedin = true;
					break;
				}

				if (loggedin == false)
				{
					Console.WriteLine("Error, no such user found.");
				}
			}
			//IT
			if (loggedinIT != null)
			{
				while (true)
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
							else
							{
								break;
							}
						}
						Ticket selectedShareTicket = openList[Convert.ToInt32(ticketOption) - 1];
						bool sharesuccess = false;
						while (sharesuccess == false)
						{
							string shareusername = loggedinIT.userID;
							while (shareusername == loggedinIT.userID)
							{
								Console.WriteLine("Please enter the username you want to share to: ");
								shareusername = Console.ReadLine();
								if (shareusername == loggedinIT.userID)
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
					else if (option == "0")
					{
						Console.WriteLine("Logging out...");
						break;
					}
				}

            }
            else if (loggedinAdmin != null)
            {
                while (true)
                {
                    AdminMenu();
                    string option = Console.ReadLine();
                    //if (option != "0" || option != "1" || option != "2" || option != "3")
                    //    Console.WriteLine("Invalid option inputted!");
                    if (option == "1")
                    {
                        //List<string> register = new List<string>();
                        string userOption = "0";
                        while (true)
                        {
                            Console.WriteLine("Please input the number of the type of user type you are registering. (1 - 3)\n(1) \tEmployee\n(2) \tIT Support Member\n(3) \tReporting Manager");
                            userOption = Console.ReadLine();
                            if (userOption == "1" || userOption == "2" || userOption == "3")
                            {
                                break;
                            }
                            else
                                Console.WriteLine("Invalid option inputted!");
                        }
                        while (true)
                        {
                            // Register Employee
                            if (userOption == "1")
                            {
                                bool reg = true;
                                string userid;
                                string password;
                                string first;
                                string last;
                                string email;
                                string depNo;
                                string address;
                                string postal;
                                string regTrue;
                                while (true)
                                {
                                    reg = true;
                                    Console.WriteLine("Please enter the employee's user id:");
                                    userid = Console.ReadLine();
                                    foreach (User user in userList)
                                    {
                                        if (user.userID == userid)
                                        {
                                            reg = false;
                                        }
                                    }
                                    if (reg && userid != "")
                                        break;
                                    if (reg == false)
                                        Console.WriteLine("Username already exist!");
                                    else
                                        Console.WriteLine("Invalid user id!");
                                }

                                while (true)
                                {
                                    Console.WriteLine("Please enter employee's password:");
                                    password = Console.ReadLine();
                                    if (password != "")
                                        break;
                                    else
                                        Console.WriteLine("Invalid password!");
                                }
                                while (true)
                                {
                                    Console.WriteLine("Please enter first name of the employee:");
                                    first = Console.ReadLine();
                                    if (first != "")
                                        break;
                                    else
                                        Console.WriteLine("Invalid first name!");
                                }
                                while (true)
                                {
                                    Console.WriteLine("Please enter last name of the employee:");
                                    last = Console.ReadLine();
                                    if (last != "")
                                        break;
                                    else
                                        Console.WriteLine("Invalid last name!");
                                }
                                while (true)
                                {
                                    reg = true;
                                    Console.WriteLine("Please enter email of the employee:");
                                    email = Console.ReadLine();
                                    foreach (User user in userList)
                                    {
                                        if (user.Email == email)
                                        {
                                            reg = false;
                                        }
                                    }
                                    if (reg && email != "")
                                        break;
                                    if (reg == false)
                                        Console.WriteLine("Email already exist!");
                                    else
                                        Console.WriteLine("Invalid Email!");
                                }
                                while (true)
                                {
                                    Console.WriteLine("Please enter department number of employee:");
                                    depNo = Console.ReadLine();
                                    if (depNo != "")
                                        break;
                                    else
                                        Console.WriteLine("Invalid department number!");
                                }
                                while (true)
                                {
                                    Console.WriteLine("Please enter address of the employee:");
                                    address = Console.ReadLine();
                                    if (address != "")
                                        break;
                                    else
                                        Console.WriteLine("Invalid address!");
                                }
                                while (true)
                                {
                                    Console.WriteLine("Please enter postal code of the employee:");
                                    postal = Console.ReadLine();
                                    if (postal != "")
                                        break;
                                    else
                                        Console.WriteLine("Invalid postal code!");
                                }
                                while (true)
                                {
                                    Console.WriteLine("EMPLOYEE-------------------------------------------");
                                    Console.WriteLine("Username: \t" + userid);
                                    Console.WriteLine("Password: \t" + password);
                                    Console.WriteLine("Name: \t\t" + first + " " + last);
                                    Console.WriteLine("Email: \t\t" + email);
                                    Console.WriteLine("Address: \t" + address);
                                    Console.WriteLine("Postal Code: \t" + postal);
                                    Console.WriteLine("---------------------------------------------------\n");
                                    while (true)
                                    {
                                        Console.WriteLine("Confirm (Yes / No):");
                                        regTrue = Console.ReadLine();
                                        if (regTrue == "Yes" || regTrue == "yes" || regTrue == "YES" || regTrue == "Y" || regTrue == "y")
                                        {
                                            Employee newEmployee = new Employee(userid, password, first, last, email, depNo, address, postal);
                                            userList.Add(newEmployee);
                                            Console.WriteLine(userid + " is successfully registered!");
                                            break;
                                        }
                                        else if (regTrue == "No" || regTrue == "no" || regTrue == "NO" || regTrue == "N" || regTrue == "n")
                                        {
                                            Console.WriteLine("Good bye.");
                                            break;
                                        }
                                        else
                                            Console.WriteLine("Invalid option entered!");
                                    }
                                    break;
                                }
                                break;
                            }
                            // Register IT Support Member
                            else if (userOption == "2")
                            {
                                bool reg = true;
                                string userid;
                                string password;
                                string first;
                                string last;
                                string email;
                                string regTrue;
                                while (true)
                                {
                                    reg = true;
                                    Console.WriteLine("Please enter the IT Support Member's user id:");
                                    userid = Console.ReadLine();
                                    foreach (User user in userList)
                                    {
                                        if (user.userID == userid)
                                        {
                                            reg = false;
                                        }
                                    }
                                    if (reg && userid != "")
                                        break;
                                    if (reg == false)
                                    {
                                        Console.WriteLine("Username already exist!");
                                    }
                                    else
                                        Console.WriteLine("Invalid user id!");
                                }

                                while (true)
                                {
                                    Console.WriteLine("Please enter IT Support Member's password:");
                                    password = Console.ReadLine();
                                    if (password != "")
                                        break;
                                    else
                                        Console.WriteLine("Invalid password!");
                                }
                                while (true)
                                {
                                    Console.WriteLine("Please enter first name of the IT Support Member:");
                                    first = Console.ReadLine();
                                    if (first != "")
                                        break;
                                    else
                                        Console.WriteLine("Invalid first name!");
                                }
                                while (true)
                                {
                                    Console.WriteLine("Please enter last name of the IT Support Member:");
                                    last = Console.ReadLine();
                                    if (last != "")
                                        break;
                                    else
                                        Console.WriteLine("Invalid last name!");
                                }
                                while (true)
                                {
                                    reg = true;
                                    Console.WriteLine("Please enter email of the IT Support Member:");
                                    email = Console.ReadLine();
                                    foreach (User user in userList)
                                    {
                                        if (user.Email == email)
                                        {
                                            reg = false;
                                        }
                                    }
                                    if (reg && email != "")
                                        break;
                                    if (reg == false)
                                        Console.WriteLine("Email already exist!");
                                    else
                                        Console.WriteLine("Invalid Email!");
                                }
                                while (true)
                                {
                                    Console.WriteLine("IT SUPPORT MEMBER----------------------------------");
                                    Console.WriteLine("Username: \t" + userid);
                                    Console.WriteLine("Password: \t" + password);
                                    Console.WriteLine("Name: \t\t" + first + " " + last);
                                    Console.WriteLine("Email: \t\t" + email);
                                    Console.WriteLine("---------------------------------------------------\n");
                                    while (true)
                                    {
                                        Console.WriteLine("Confirm (Yes / No):");
                                        regTrue = Console.ReadLine();
                                        if (regTrue == "Yes" || regTrue == "yes" || regTrue == "YES" || regTrue == "Y" || regTrue == "y")
                                        {
                                            ITSupportMember newSupport = new ITSupportMember(userid, password, first, last, email);
                                            //ITSupportMemberList.Add(newSupport);
                                            userList.Add(newSupport); // added v2
                                            Console.WriteLine(userid + " is successfully registered!");
                                            break;
                                        }
                                        else if (regTrue == "No" || regTrue == "no" || regTrue == "NO" || regTrue == "N" || regTrue == "n")
                                        {
                                            Console.WriteLine("Good bye.");
                                            break;
                                        }
                                        else
                                            Console.WriteLine("Invalid option entered!");
                                    }
                                    break;
                                }
                                break;
                            }
                            // Register Reporting Manager
                            else if (userOption == "3")
                            {
                                bool reg = true;
                                string userid;
                                string password;
                                string first;
                                string last;
                                string email;
                                string regTrue;
                                while (true)
                                {
                                    reg = true;
                                    Console.WriteLine("Please enter the Reporting Manager's user id:");
                                    userid = Console.ReadLine();
                                    foreach (User user in userList)
                                    {
                                        if (user.userID == userid)
                                        {
                                            reg = false;
                                        }
                                    }
                                    if (reg && userid != "")
                                        break;
                                    if (reg == false)
                                        Console.WriteLine("Username already exist!");
                                    else
                                        Console.WriteLine("Invalid user id!");
                                }

                                while (true)
                                {
                                    Console.WriteLine("Please enter Reporting Manager's password:");
                                    password = Console.ReadLine();
                                    if (password != "")
                                        break;
                                    else
                                        Console.WriteLine("Invalid password!");
                                }
                                while (true)
                                {
                                    Console.WriteLine("Please enter first name of the Reporting Manager:");
                                    first = Console.ReadLine();
                                    if (first != "")
                                        break;
                                    else
                                        Console.WriteLine("Invalid first name!");
                                }
                                while (true)
                                {
                                    Console.WriteLine("Please enter last name of the Reporting Manager:");
                                    last = Console.ReadLine();
                                    if (last != "")
                                        break;
                                }
                                while (true)
                                {
                                    reg = true;
                                    Console.WriteLine("Please enter email of the Reporting Manager:");
                                    email = Console.ReadLine();
                                    foreach (User user in userList)
                                    {
                                        if (user.Email == email)
                                        {
                                            reg = false;
                                        }
                                    }
                                    if (reg && email != "")
                                        break;
                                    if (reg == false)
                                        Console.WriteLine("Email already exist!");
                                    else
                                        Console.WriteLine("Invalid Email!");
                                }
                                while (true)
                                {
                                    Console.WriteLine("REPORTING MANAGER----------------------------------");
                                    Console.WriteLine("Username: \t" + userid);
                                    Console.WriteLine("Password: \t" + password);
                                    Console.WriteLine("Name: \t\t" + first + " " + last);
                                    Console.WriteLine("Email: \t\t" + email);
                                    Console.WriteLine("---------------------------------------------------\n");
                                    while (true)
                                    {
                                        Console.WriteLine("Confirm (Yes / No):");
                                        regTrue = Console.ReadLine();
                                        if (regTrue == "Yes" || regTrue == "yes" || regTrue == "YES" || regTrue == "Y" || regTrue == "y")
                                        {
                                            ReportManager newManager = new ReportManager(userid, password, first, last, email);
                                            //managerList.Add(newManager);
                                            userList.Add(newManager); // added v2
                                            Console.WriteLine(userid + " is successfully registered!");
                                            break;
                                        }
                                        else if (regTrue == "No" || regTrue == "no" || regTrue == "NO" || regTrue == "N" || regTrue == "n")
                                        {
                                            Console.WriteLine("Good bye.");
                                            break;
                                        }
                                        else
                                            Console.WriteLine("Invalid option entered!");
                                    }
                                    break;
                                }
                                break;
                            }
                        }
                    }
                    else if (option == "2")
                    {
                        // To be implemented.
                    }
                    else if (option == "3")
                    {
                        for (int i = 0; i < userList.Count; i++)
                        {
                            Console.WriteLine(userList[i]);
                        }
                        for (int i = 0; i < managerList.Count; i++)
                        {
                            Console.WriteLine(managerList[i].userID + "\t" + managerList[i].userType);
                        }
                    }
                    else if (option == "0")
                        break;
                    else
                        Console.WriteLine("Invalid option inputted!");
                }
            }
            else if (loggedinManager != null) //added by ee zher
            {
                while (true)
                {
                    RptMenu();
                    string option = Console.ReadLine();
                    if (option == "1") //Assign Ticket
                        Console.WriteLine("Hello");
                    else if (option == "2") //Generate Report
                    {
                        RMenu();
                        string alphaOpt = Console.ReadLine();
                        if (alphaOpt == "a" || alphaOpt == "A")
                        {
                            //View all Solved Tickets
                            foreach (Ticket tick in ticketList)
                            {
                                if (tick.Solved == true)
                                {
                                    Console.WriteLine("ID: {0} \tProblem: {1} \tStatus: Solved", tick.TicketID, tick.Problem_desc);
                                }
                            }
                        }
                        else if (alphaOpt == "b" || alphaOpt == "B")
                        {
                            //View all Unsolved Tickets
                            foreach (Ticket tick in ticketList)
                            {
                                if (tick.Solved == false)
                                {
                                    Console.WriteLine("ID: {0} \tProblem: {1} \tStatus: Unsolved", tick.TicketID, tick.Problem_desc, tick.Solved);
                                }
                            }
                        }
                    }
                    else if (option == "0")
                        break;
                    else
                        Console.WriteLine("Wrong input");
                }
            }
            else if (loggedinEmployee != null)
            {
            }








		}
		public static void Itmenu() //added option 0 by ee zher
		{
			Console.WriteLine("-----------------------------");
			Console.WriteLine("1. Share a ticket");
            Console.WriteLine("0. Logout");
			Console.WriteLine("Please enter your preferred option: ");
		}

        // Seanmarcus Admin Menu
        public static void  AdminMenu() //added option 0 by ee zher
        {
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("1. Register User");
            Console.WriteLine("2. Generate Report");
            Console.WriteLine("0. Logout");
            Console.WriteLine("Please enter your preferred option: ");
        }

        public static void RptMenu() //added by ee zher
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. Assign Ticket to a IT member");
            Console.WriteLine("2. Generate Report");
            Console.WriteLine("0. Logout");
            Console.WriteLine("Please enter your preferred option: ");
        }

        public static void EmpyMenu() //added by ee zher
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. View online help");
            Console.WriteLine("0. Logout");
            Console.WriteLine("Please enter your preferred option: ");
        }

        public static void RMenu() //added by ee zher
        {
            Console.WriteLine("a: Print all Solved Ticket");
            Console.WriteLine("b: Print all Unsolved Ticket");
        }
	}


}
