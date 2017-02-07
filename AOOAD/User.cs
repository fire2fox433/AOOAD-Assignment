using System;
using System.Collections.Generic;
namespace AOOAD
{
	public class User
	{
		protected string UserID;
		public string userID
		{
			get
			{
				return this.UserID;
			}
			set
			{
				this.UserID = value;
			}
		}
		protected string password;
		public string Password
		{
			get
			{
				return this.password;
			}
			set
			{
				this.password = value;
			}
		}
		protected string firstName;
		public string FirstName
		{
			get
			{
				return this.firstName;
			}
			set
			{
				this.firstName = value;
			}
		}
		protected string lastName;
		public string LastName
		{
			get
			{
				return this.lastName;
			}
			set
			{
				this.lastName = value;
			}
		}
		protected string email;
		public string Email
		{
			get
			{
				return this.email;
			}
			set
			{
				this.email = value;
			}
		}
		protected string role;
		public string userType
		{
			get
			{
				return this.userType;
			}
			set
			{
				this.userType = value;
			}
		}
		/*/
		public User(string id, string password, string first, string last, string email)
		{
			UserID = id;
			this.password = password;
			firstName = first;
			lastName = last;
			this.email = email;
		}
		/*/
		public User login()
		{
			return this;
		}
			
	}
}
