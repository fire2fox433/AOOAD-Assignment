using System;
namespace AOOAD
{
	public class Admin : User
	{
		
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
	}

}
