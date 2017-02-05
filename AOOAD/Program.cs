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
            List<string> userList = new List<string>(); // added by Seanmarcus
            Admin newAdmin = new Admin("admin", "admin", "123", "123", "123"); // added by seanmarcus
            adminList.Add(newAdmin); // added by seanmarcus
            ReportManager newReportManager = new ReportManager("report", "report", "123", "123", "123"); // added by seanmarcus
            managerList.Add(newReportManager); // added by seanmarcus
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
				if (loggedin == true)
				{
					break;
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

            }
            else if (loggedinAdmin != null)
            {
                while (true)
                {
                    AdminMenu();
                    string option = Console.ReadLine();
                    if (option == "1")
                    {
                        //List<string> register = new List<string>();
                        string userOption = "0";
                        while (true)
                        {
                            Console.WriteLine("Please type in the number of the type of user you are registering.\n(1) Employee\n(2) IT Support Member\n(3) Reporting Manager");
                            userOption = Console.ReadLine();
                            if (userOption == "1" || userOption == "2" || userOption == "3")
                            {
                                break;
                            }
                            else
                                Console.WriteLine("Invalid option inputted.");
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
                                while (true)
                                {
                                    reg = true;
                                    Console.WriteLine("Please enter the employee's user id:");
                                    userid = Console.ReadLine();
                                    for (int i = 0; i < employeeList.Count; i++)
                                    {
                                        if (employeeList[i].userID == userid)
                                        {
                                            reg = false;
                                        }
                                    }
                                    for (int i = 0; i < ITSupportMemberList.Count; i++)
                                    {
                                        if (ITSupportMemberList[i].userID == userid)
                                        {
                                            reg = false;
                                        }
                                    }
                                    for (int i = 0; i < managerList.Count; i++)
                                    {
                                        if (managerList[i].userID == userid)
                                        {
                                            reg = false;
                                        }
                                    }
                                    if (reg && userid != "")
                                        break;
                                    else
                                        Console.WriteLine("Invalid user id!");
                                }

                                while (true)
                                {
                                    Console.WriteLine("Please enter employee's password:");
                                    password = Console.ReadLine();
                                    if (password != "")
                                        break;
                                }
                                while (true)
                                {
                                    Console.WriteLine("Please enter first name of the employee:");
                                    first = Console.ReadLine();
                                    if (first != "")
                                        break;
                                }
                                while (true)
                                {
                                    Console.WriteLine("Please enter last name of the employee:");
                                    last = Console.ReadLine();
                                    if (last != "")
                                        break;
                                }
                                while (true)
                                {
                                    Console.WriteLine("Please enter email of the employee:");
                                    email = Console.ReadLine();
                                    if (last != "")
                                        break;
                                }
                                while (true)
                                {
                                    Console.WriteLine("Please enter department number of employee:");
                                    depNo = Console.ReadLine();
                                    if (depNo != "")
                                        break;
                                }
                                while (true)
                                {
                                    Console.WriteLine("Please enter address of the employee:");
                                    address = Console.ReadLine();
                                    if (address != "")
                                        break;
                                }
                                while (true)
                                {
                                    Console.WriteLine("Please enter postal code of the employee:");
                                    postal = Console.ReadLine();
                                    if (postal != "")
                                        break;
                                }
                                Employee newEmployee = new Employee(userid, password, first, last, email, depNo, address, postal);
                                employeeList.Add(newEmployee);
                                Console.WriteLine(userid + " is successfully registered!");
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
                                while (true)
                                {
                                    reg = true;
                                    Console.WriteLine("Please enter the IT Support Member's user id:");
                                    userid = Console.ReadLine();
                                    for (int i = 0; i < employeeList.Count; i++)
                                    {
                                        if (employeeList[i].userID == userid)
                                        {
                                            reg = false;
                                        }
                                    }
                                    for (int i = 0; i < ITSupportMemberList.Count; i++)
                                    {
                                        if (ITSupportMemberList[i].userID == userid)
                                        {
                                            reg = false;
                                        }
                                    }
                                    for (int i = 0; i < managerList.Count; i++)
                                    {
                                        if (managerList[i].userID == userid)
                                        {
                                            reg = false;
                                        }
                                    }
                                    if (reg && userid != "")
                                        break;
                                    else
                                        Console.WriteLine("Invalid user id!");
                                }

                                while (true)
                                {
                                    Console.WriteLine("Please enter IT Support Member's password:");
                                    password = Console.ReadLine();
                                    if (password != "")
                                        break;
                                }
                                while (true)
                                {
                                    Console.WriteLine("Please enter first name of the IT Support Member:");
                                    first = Console.ReadLine();
                                    if (first != "")
                                        break;
                                }
                                while (true)
                                {
                                    Console.WriteLine("Please enter last name of the IT Support Member:");
                                    last = Console.ReadLine();
                                    if (last != "")
                                        break;
                                }
                                while (true)
                                {
                                    Console.WriteLine("Please enter email of the IT Support Member:");
                                    email = Console.ReadLine();
                                    if (last != "")
                                        break;
                                }
                                ITSupportMember newSupport = new ITSupportMember(userid, password, first, last, email);
                                ITSupportMemberList.Add(newSupport);
                                Console.WriteLine(userid + " is successfully registered!");
                                break;
                            }
                            // Register Reporting Manager
                            //user id, password, first name, last name and email
                            else if (userOption == "3")
                            {
                                bool reg = true;
                                string userid;
                                string password;
                                string first;
                                string last;
                                string email;
                                while (true)
                                {
                                    reg = true;
                                    Console.WriteLine("Please enter the Reporting Manager's user id:");
                                    userid = Console.ReadLine();
                                    for (int i = 0; i < employeeList.Count; i++)
                                    {
                                        if (employeeList[i].userID == userid)
                                        {
                                            reg = false;
                                        }
                                    }
                                    for (int i = 0; i < ITSupportMemberList.Count; i++)
                                    {
                                        if (ITSupportMemberList[i].userID == userid)
                                        {
                                            reg = false;
                                        }
                                    }
                                    for (int i = 0; i < managerList.Count; i++)
                                    {
                                        if (managerList[i].userID == userid)
                                        {
                                            reg = false;
                                        }
                                    }
                                    if (reg && userid != "")
                                        break;
                                    else
                                        Console.WriteLine("Invalid user id!");
                                }

                                while (true)
                                {
                                    Console.WriteLine("Please enter Reporting Manager's password:");
                                    password = Console.ReadLine();
                                    if (password != "")
                                        break;
                                }
                                while (true)
                                {
                                    Console.WriteLine("Please enter first name of the Reporting Manager:");
                                    first = Console.ReadLine();
                                    if (first != "")
                                        break;
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
                                    Console.WriteLine("Please enter email of the Reporting Manager:");
                                    email = Console.ReadLine();
                                    if (last != "")
                                        break;
                                }
                                ReportManager newManager = new ReportManager(userid, password, first, last, email);
                                managerList.Add(newManager);
                                Console.WriteLine(userid + " is successfully registered!");
                                break;
                            }
                        }
                    }
                    if (option == "2")
                    {
                        // To be implemented.
                    }
                }
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

        // Seanmarcus Admin Menu
        public static void  AdminMenu()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. Register User");
            Console.WriteLine("2. Generate Report");
            Console.WriteLine("Please enter your preferred option: ");
        }
	}


		



}
