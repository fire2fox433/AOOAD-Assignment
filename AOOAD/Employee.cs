using System;
using System.Collections.Generic;
namespace AOOAD
{
	public class Employee : User
	{
		private string phone_no;
		public string Phone_no
		{
			get
			{
				return this.phone_no;
			}
			set
			{
				this.phone_no = value;
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
		public Employee(string id, string password, string first, string last, string email, string phone, string address, string postal)
		{
			UserID = id;
			this.password = password;
			firstName = first;
			lastName = last;
			this.email = email;
			this.Phone_no = phone;
			this.Address = address;
			this.Postal_code = postal;
			this.Role = "Employee";
		}
		public void viewOnlineHelp()
		{
			Console.WriteLine("not implemented yet.");
		}

	}
}
