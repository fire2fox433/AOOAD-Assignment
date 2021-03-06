﻿//
//  Program.cs
//  AOOAD-Assignment
//
//  Created by Chen Yifan on 4/2/17
//  Copyright © 2017 Chen Yifan. All rights reserved.
//


using System;
using System.Collections.Generic;
using System.Linq;

namespace AOOAD
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Preinitialising Lists
            TicketList ticketList = new TicketList(10);
            List<Problem> problemList = new List<Problem>();
            List<ITSupportMember> ITSupportMemberList = new List<ITSupportMember>();
            List<Report> reportList = new List<Report>();
            List<Employee> employeeList = new List<Employee>();
            List<ReportManager> managerList = new List<ReportManager>();
            //Preinitialising Accounts, Tickets, Variables for login
            ITSupportMember newUser = new ITSupportMember("123", "123", "Kenneth", "San", "123");
            ITSupportMember newMember = new ITSupportMember("345", "345", "hehe", "xd", "123");
            ITSupportMemberList.Add(newMember);
            Ticket newTicket1 = new Ticket("123", "123", "blue screen of death", "windows", null, "bad", 10, null);
            ITSupportMemberList.Add(newUser);
            newTicket1.incharge = newUser;
            newUser.ticketList.Add(newTicket1);
            ticketList.add(newTicket1);
            Ticket newTicket2 = new Ticket("135", "135", "harddisk drive died", "Mac IOS", null, "Super good", 0, null);
            newTicket2.Solved = true;
            ticketList.add(newTicket2);
            newUser.ticketList.Add(newTicket2);
            newUser = new ITSupportMember("234", "123", "Matthew", "Chan", "123");
            newTicket2.incharge = newUser;
            ITSupportMemberList.Add(newUser);
            Admin adminAccount = Admin.getInstance("admin", "admin", "123", "123", "123"); // added by seanmarcus
            ReportManager newReportManager = new ReportManager("report", "report", "123", "123", "123"); // added by seanmarcus
            managerList.Add(newReportManager); // added by seanmarcus
            bool loggedin = false;
            ITSupportMember loggedinIT = null;
            Employee loggedinEmployee = null;
            ReportManager loggedinManager = null;
            Admin loggedinAdmin = null;


            // login
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

            //IT Support Member
            if (loggedinIT != null)
            {
                while (true)
                {
                    Itmenu();
                    string option = Console.ReadLine();
                    //yifan's usecase - Share ticket
                    if (option == "1")
                    {
                        //checks whether if logged in user is in charge of anything
                        if (loggedinIT.ticketList.Count != 0)
                        {
                            //placing all the open tickets into a list and display it
                            List<Ticket> openList = new List<Ticket>();
                            Console.WriteLine("No.\tTicket ID\tTicket Desc.\t\tSolved");
                            int no = 0;
                            for (int i = 0; i < loggedinIT.ticketList.Count; i++)
                            {
                                if (loggedinIT.ticketList[i].viewStatus() == "open")
                                {
                                    no = no + 1;
                                    openList.Add(ticketList.getInfo(i));
                                    Console.WriteLine(no + "\t" + ticketList.getInfo(i).TicketID + "\t\t" + ticketList.getInfo(i).Problem_desc + "\t" + ticketList.getInfo(i).Solved);

                                }
                            }
                            string ticketOption = "0";
                            //user selecting ticket
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
                            //sharing ticket based on userID
                            bool sharesuccess = false;
                            while (sharesuccess == false)
                            {
                                string shareusername = loggedinIT.userID;
                                while (shareusername == loggedinIT.userID)
                                {
                                    Console.WriteLine("Please enter the username you want to share to: ");
                                    shareusername = Console.ReadLine();
                                    //check for self share
                                    if (shareusername == loggedinIT.userID)
                                    {
                                        Console.WriteLine("You cannot share to yourself!");
                                    }

                                }
                                //check if valid userid and share
                                for (int i = 0; i < ITSupportMemberList.Count; i++)
                                {
                                    if (ITSupportMemberList[i].userID == shareusername)
                                    {
                                        for (int y = 0; y < ticketList.NumberOfTickets; y++)
                                        {
                                            if (ticketList.getInfo(y) == selectedShareTicket)
                                            {
                                                ticketList.getInfo(y).sharedList.Add(ITSupportMemberList[i]);
                                                ITSupportMemberList[i].sharedList.Add(ticketList.getInfo(y));
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
                                //asks if you want to share the ticket to more people
                                else if (sharesuccess == true)
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Ticket shared successfully, would you like to share to another IT support staff?(Y/N)");
                                        string yorn = Console.ReadLine();
                                        if (yorn == "Y" || yorn == "y" || yorn == "YES" || yorn == "Yes" || yorn == "yes")
                                        {
                                            sharesuccess = false;
                                            break;
                                        }
                                        else if (yorn == "n" || yorn == "N" || yorn == "No" || yorn == "NO" || yorn == "no")
                                            break;
                                        else
                                            Console.WriteLine("Sorry, I couldn't understand that input, please try again.");
                                    }

                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("You are not in charge of any tickets!");
                        }



                    }
                    else if (option == "2")
                    {
                        Console.WriteLine("Category\tProblem Desc\t\t\tSystem Name\tIn Charge\tStatus\tSolved\tShared With");
                        for (int i = 0; i < ticketList.NumberOfTickets; i++)
                        {
                            if (ticketList.getInfo(i).sharedList.ElementAtOrDefault(0) != null)
                            {
                                Console.WriteLine("{0} \t\t{1} \t\t{2} \t{3} \t{4} \t{5} \t{6}", ticketList.getInfo(i).Category, ticketList.getInfo(i).Problem_desc, ticketList.getInfo(i).System_name, ticketList.getInfo(i).incharge.FirstName, ticketList.getInfo(i).viewStatus(), ticketList.getInfo(i).Solved, ticketList.getInfo(i).sharedList[0].userID);
                                if (ticketList.getInfo(i).sharedList.ElementAtOrDefault(1) != null)
                                {
                                    for (int x = 1; x < ticketList.getInfo(i).sharedList.Count; x++)
                                    {
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t" + ticketList.getInfo(i).sharedList[x].userID);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("{0} \t\t{1} \t\t{2} \t{3} \t{4} \t{5} \tNo shared users.", ticketList.getInfo(i).Category, ticketList.getInfo(i).Problem_desc, ticketList.getInfo(i).System_name, ticketList.getInfo(i).incharge.FirstName, ticketList.getInfo(i).viewStatus(), ticketList.getInfo(i).Solved);
                            }


                        }
                    }
                    else if (option == "3")
                    {
                        Console.WriteLine("This function is not yet implemented.");
                    }
                    else if (option == "4")
                    {
                        //weijhin usecase
                    }
                    else if (option == "5")
                    {
                        Console.WriteLine("This function is not yet implemented.");
                    }
                    else if (option == "6")
                    {
                        Console.WriteLine("This function is not yet implemented.");
                    }
                    else if (option == "7")
                    {
                        Console.WriteLine("This function is not yet implemented.");
                    }
                    else if (option == "0")
                    {
                        Console.WriteLine("Logging out...");
                        break;
                    }
                }

            }
            //admin
            else if (loggedinAdmin != null)
            {
                while (true)
                {
                    AdminMenu();
                    string option = Console.ReadLine();
                    if (option == "1")
                    {
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
                                    reg = isIDValid(ITSupportMemberList, employeeList, managerList, userid);
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
                                    reg = isEmailValid(ITSupportMemberList, employeeList, managerList, email);
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
                                            employeeList.Add(newEmployee);
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
                                    reg = isIDValid(ITSupportMemberList, employeeList, managerList, userid);
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
                                    reg = isEmailValid(ITSupportMemberList, employeeList, managerList, email);
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
                                            ITSupportMemberList.Add(newSupport);
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
                                    reg = isIDValid(ITSupportMemberList, employeeList, managerList, userid);
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
                                    reg = isEmailValid(ITSupportMemberList, employeeList, managerList, email);
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
                                            managerList.Add(newManager);
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
                    else if (option == "2") //Generate Report
                    {
                        RMenu();
                        string alphaOpt = Console.ReadLine();
                        if (alphaOpt == "a" || alphaOpt == "A")
                        {
                            TicketIterator iIter = ticketList.createIterator(true);
                            while (iIter.hasNext() == true)
                            {
                                Console.WriteLine("ID: {0} \tProblem: {1} \tStatus: Solved", ((Ticket)iIter.CurrentItem(true)).TicketID, ((Ticket)iIter.next(true)).Problem_desc);
                            }
                            Report newrpt = new Report();
                            loggedinAdmin.reportList.Add(newrpt);
                            Console.WriteLine("Time printed: {0}", loggedinAdmin.reportList[0].Time_printed);
                        }
                        else if (alphaOpt == "b" || alphaOpt == "B")
                        {
                            TicketIterator iIter = ticketList.createIterator(false);
                            while (iIter.hasNext() == true)
                            {
                                Console.WriteLine("ID: {0} \tProblem: {1} \tStatus: Unsolved", ((Ticket)iIter.CurrentItem(false)).TicketID, ((Ticket)iIter.next(false)).Problem_desc);
                            }
                            Report newrpt = new Report();
                            loggedinAdmin.reportList.Add(newrpt);
                            Console.WriteLine("Time printed: {0}", loggedinAdmin.reportList[0].Time_printed);
                        }
                        else if (alphaOpt == "c" || alphaOpt == "C")
                        {
                            //View all tickets assigned by an IT member
                            foreach (ITSupportMember Member in ITSupportMemberList)
                            {
                                Console.WriteLine("ID: {0}   Name: {1} {2}", Member.userID, Member.FirstName, Member.LastName);
                            }
                            Console.WriteLine("Select the User you wish to view");
                            string memID = Console.ReadLine();
                            foreach (ITSupportMember Member in ITSupportMemberList)
                            {
                                if (Member.userID == memID)
                                {
                                    foreach (Ticket tick in Member.ticketList)
                                    {
                                        if (tick.Solved == true)
                                            Console.WriteLine("Ticket ID: {0} \tProblem: {1} \tStatus: Solved", tick.TicketID, tick.Problem_desc);
                                        else if (tick.Solved == false)
                                            Console.WriteLine("Ticket ID: {0} \tProblem: {1} \tStatus: Unsolved", tick.TicketID, tick.Problem_desc);
                                    }
                                }
                            }
                            Report newrpt = new Report();
                            loggedinAdmin.reportList.Add(newrpt);
                            Console.WriteLine("Time printed: {0}", loggedinAdmin.reportList[0].Time_printed);
                        }
                    }
                    else if (option == "0")
                        break;
                    else
                        Console.WriteLine("Invalid option inputted!");
                }

            }
            //Report Manager
            else if (loggedinManager != null)
            {
                while (true)
                {
                    RptMenu();
                    string option = Console.ReadLine();
                    if (option == "1") //Assign Ticket
                    {
                        foreach (ITSupportMember Member in ITSupportMemberList)
                        {
                            Console.WriteLine("ID: {0}   Name: {1} {2}", Member.userID, Member.FirstName, Member.LastName);
                        }
                        //Not implemented
                        Console.WriteLine("Assign Ticket is not implemented by our team");
                    }
                    else if (option == "2") //Generate Report
                    {
                        RMenu();
                        string alphaOpt = Console.ReadLine();
                        if (alphaOpt == "a" || alphaOpt == "A")
                        {
                            TicketIterator iIter = ticketList.createIterator(true);
                            while (iIter.hasNext() == true)
                            {
                                Console.WriteLine("ID: {0} \tProblem: {1} \tStatus: Solved", ((Ticket)iIter.CurrentItem(true)).TicketID, ((Ticket)iIter.next(true)).Problem_desc);
                            }
                            Report newrpt = new Report();
                            loggedinManager.reportList.Add(newrpt);
                            Console.WriteLine("Time printed: {0}", loggedinManager.reportList[0].Time_printed);
                        }
                        else if (alphaOpt == "b" || alphaOpt == "B")
                        {
                            TicketIterator iIter = ticketList.createIterator(false);
                            while (iIter.hasNext() == true)
                            {
                                Console.WriteLine("ID: {0} \tProblem: {1} \tStatus: Unsolved", ((Ticket)iIter.CurrentItem(false)).TicketID, ((Ticket)iIter.next(false)).Problem_desc);
                            }
                            Report newrpt = new Report();
                            loggedinManager.reportList.Add(newrpt);
                            Console.WriteLine("Time printed: {0}", loggedinManager.reportList[0].Time_printed);
                        }
                        else if (alphaOpt == "c" || alphaOpt == "C")
                        {
                            //View all tickets assigned by an IT member
                            foreach (ITSupportMember Member in ITSupportMemberList)
                            {
                                Console.WriteLine("ID: {0}   Name: {1} {2}", Member.userID, Member.FirstName, Member.LastName);
                            }
                            Console.WriteLine("Select the User you wish to view");
                            string memID = Console.ReadLine();
                            foreach (ITSupportMember Member in ITSupportMemberList)
                            {
                                if (Member.userID == memID)
                                {
                                    foreach (Ticket tick in Member.ticketList)
                                    {
                                        if (tick.Solved == true)
                                            Console.WriteLine("Ticket ID: {0} \tProblem: {1} \tStatus: Solved", tick.TicketID, tick.Problem_desc);
                                        else if (tick.Solved == false)
                                            Console.WriteLine("Ticket ID: {0} \tProblem: {1} \tStatus: Unsolved", tick.TicketID, tick.Problem_desc);
                                    }
                                }
                            }
                            Report newrpt = new Report();
                            loggedinManager.reportList.Add(newrpt);
                            Console.WriteLine("Time printed: {0}", loggedinManager.reportList[0].Time_printed);
                        }
                    }
                    else if (option == "3")
                    {
                        Console.WriteLine("This function is not yet implemented.");
                    }
                    else if (option == "0")
                        break;
                    else
                        Console.WriteLine("Wrong input");
                }
            }
            //employee
            else if (loggedinEmployee != null)
            {
                while (true)
                {
                    EmpyMenu();
                    string option = Console.ReadLine();
                    if (option == "1")
                    {
                        Console.WriteLine("This function is not yet implemented.");
                    }
                    else if (option == "0")
                        break;
                    else
                        Console.WriteLine("Invalid option inputted!");
                }

            }
        }


        //menus for each of the logins
        //IT Support Member Menu
        public static void Itmenu()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. Share a ticket");
            Console.WriteLine("2. View Ticket List");
            Console.WriteLine("3. Reopen Ticket // not implemented");
            Console.WriteLine("4. Raise Ticket");
            Console.WriteLine("5. Assign Ticket // not implemented");
            Console.WriteLine("6. Comment Ticket // not implemented");
            Console.WriteLine("7. Solve Ticket // not implemented");
            Console.WriteLine("0. Logout");
            Console.WriteLine("Please enter your preferred option: ");
        }

        //Admin Menu
        public static void AdminMenu()
        {
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("1. Register User");
            Console.WriteLine("2. Generate Report");
            Console.WriteLine("0. Logout");
            Console.WriteLine("Please enter your preferred option: ");
        }
        //Report Manager Menu
        public static void RptMenu()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. Assign Ticket to a IT member");
            Console.WriteLine("2. Generate Report");
            Console.WriteLine("3. Assign Ticket");
            Console.WriteLine("0. Logout");
            Console.WriteLine("Please enter your preferred option: ");
        }
        //Employee Menu
        public static void EmpyMenu() //added by ee zher
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. View online help");
            Console.WriteLine("0. Logout");
            Console.WriteLine("Please enter your preferred option: ");
        }

        public static void RMenu()
        {
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("a: View all Solved Ticket");
            Console.WriteLine("b: View all Unsolved Ticket");
            Console.WriteLine("c: View all Tickets assigned by a user");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Please enter your preferred option: ");
        }

        // check if ID is valid
        public static bool isIDValid(List<ITSupportMember> ITSupportMemberList, List<Employee> employeeList, List<ReportManager> managerList, string userid)
        {
            bool reg = true;
            foreach (User user in ITSupportMemberList)
            {
                if (user.userID == userid)
                {
                    reg = false;
                }
            }
            foreach (User user in employeeList)
            {
                if (user.userID == userid)
                {
                    reg = false;
                }
            }
            foreach (User user in managerList)
            {
                if (user.userID == userid)
                {
                    reg = false;
                }
            }
            if (reg)
                return true;
            else
                return false;
        }
        // check if Email is valid
        public static bool isEmailValid(List<ITSupportMember> ITSupportMemberList, List<Employee> employeeList, List<ReportManager> managerList, string email)
        {
            bool reg = true;
            foreach (User user in ITSupportMemberList)
            {
                if (user.Email == email)
                {
                    reg = false;
                }
            }
            foreach (User user in employeeList)
            {
                if (user.Email == email)
                {
                    reg = false;
                }
            }
            foreach (User user in managerList)
            {
                if (user.Email == email)
                {
                    reg = false;
                }
            }
            if (reg)
                return true;
            else
                return false;
        }
    }
}