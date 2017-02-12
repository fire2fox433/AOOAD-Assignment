using System;
using System.Collections.Generic;
namespace AOOAD
{
	public class Admin : User
	{
		private static Admin uniqueInstance = null;
        public List<Report> reportList = new List<Report>();
        public Admin(string id, string password, string first, string last, string email)
		{
			UserID = id;
			this.password = password;
			firstName = first;
			lastName = last;
			this.email = email;
			this.userType = "Admin";
		}
		public static Admin getInstance(string id, string password, string first, string last, string email)
		{
			if (uniqueInstance == null)
			{
				uniqueInstance = new Admin(id, password, first, last, email);
			}
			return uniqueInstance;
		}

	}

}
