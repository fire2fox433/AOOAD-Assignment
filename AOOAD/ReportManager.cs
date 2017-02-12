using System;
using System.Collections.Generic;
namespace AOOAD
{
	public class ReportManager : User
	{
        public List<Report> reportList = new List<Report>();
        public ReportManager(string id, string password, string first, string last, string email)
		{
			UserID = id;
			this.password = password;
			firstName = first;
			lastName = last;
			this.email = email;
			this.userType = "ReportManager";
		}
	}
}
