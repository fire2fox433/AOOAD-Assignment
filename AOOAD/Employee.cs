using System;
using System.Collections.Generic;
namespace AOOAD
{
	public class Employee : User
	{
		private string depNo;
		public string DepNo
		{
			get
			{
				return this.depNo;
			}
			set
			{
				this.depNo = value;
			}
		}
		private string address;
		public string Address
		{
			get
			{
				return this.address;
			}
			set
			{
				this.address = value;
			}
		}
		private string postal_code;
		public string Postal_code
		{
			get
			{
				return this.postal_code;
			}
			set
			{
				this.postal_code = value;
			}
		}
		public Employee(string id, string password, string first, string last, string email, string depNo, string address, string postal)
		{
			UserID = id;
			this.password = password;
			firstName = first;
			lastName = last;
			this.email = email;
			this.depNo = depNo;
			this.Address = address;
			this.Postal_code = postal;
			this.userType = "Employee";
		}
		public void viewOnlineHelp()
		{
			Console.WriteLine("not implemented yet.");
		}

	}
}
