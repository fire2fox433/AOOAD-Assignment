using System;
namespace AOOAD
{
	public class Admin : User
	{
		private static Admin uniqueInstance = null;

		public Admin(string id, string password, string first, string last, string email)
		{
			UserID = id;
			this.password = password;
			firstName = first;
			lastName = last;
			this.email = email;
			this.Role = "Admin";
		}
		public void register()
		{
			Console.WriteLine("Sean your implementation");
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
