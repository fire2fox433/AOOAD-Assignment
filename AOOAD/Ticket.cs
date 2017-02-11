using System;
using System.Collections.Generic;
namespace AOOAD
{
	public class Ticket
	{
		private TicketState OPEN;
		public TicketState oPEN
		{
			get
			{
				return this.OPEN;
			}
		}
		private TicketState CLOSE;
		public TicketState cLOSE
		{
			get
			{
				return this.CLOSE;
			}
		}
		private string ticketID;
		public string TicketID
		{
			get
			{
				return this.ticketID;
			}
			set
			{
				this.ticketID = value;
			}
		}
		private string category;
		public string Category
		{
			get
			{
				return this.category;
			}
			set
			{
				this.category = value;
			}
		}
		private string problem_desc;
		public string Problem_desc
		{
			get
			{
				return this.problem_desc;
			}
			set
			{
				this.problem_desc = value;
			}
		}
		private string system_name;
		public string System_name
		{
			get
			{
				return this.system_name;
			}
			set
			{
				this.system_name = value;
			}
		}
		private string module_name;
		public string Module_name
		{
			get
			{
				return this.module_name;
			}
			set
			{
				this.module_name = value;
			}
		}
		private ITSupportMember inCharge;
		public ITSupportMember incharge
		{
			get
			{
				return this.inCharge;
			}
			set
			{
				this.inCharge = value;
			}
		}
		private string severity;
		public string Severity
		{
			get
			{
				return this.severity;
			}
			set
			{
				this.severity = value;
			}
		}
		private int priority;
		public int Priority
		{
			get
			{
				return this.priority;
			}
			set
			{
				this.priority = value;
			}
		}
		private string solution;
		public string Solution
		{
			get
			{
				return this.solution;
			}
			set
			{
				this.solution = value;
			}
		}
		private DateTime open_time;
		public DateTime Open_time
		{
			get
			{
				return this.open_time;
			}
			set
			{
				this.open_time = value;
			}
		}
		private DateTime update_time;
		public DateTime Update_time
		{
			get
			{
				return this.update_time;
			}
			set
			{
				this.update_time = value;
			}
		}
		private TicketState status;
		public TicketState Status
		{
			get
			{
				return this.status;
			}
		}
		public List<string> comments = new List<string>();
		private Employee employee;
		public Employee Employee
		{
			get
			{
				return this.employee;
			}
			set
			{
				this.employee = value;
			}
		}
		private bool solved;
		public bool Solved
		{
			get
			{
				return this.solved;
			}
			set
			{
				this.solved = value;
			}

		}
        private Problem myProblem;
        public Problem myproblem
        {
            get
            {
                return this.myProblem;
            }
            set
            {
                this.myProblem = value;
            }
        }
        public List<User> sharedList = new List<User>();
		public void setStatus(TicketState state)
		{
			this.status = state;
		}
		public string viewStatus()
		{
			if (this.status == OPEN)
			{
				return "open";
			}
			else {
				return "close";
			}
		}

		public Ticket(string id, string category, string problem, string system, string module, string severity, int priority, Employee employee)
		{
			OPEN = new OpenState(this);
			CLOSE = new CloseState(this);
			status = OPEN;
			this.ticketID = id;
			this.category = category;
			this.problem_desc = problem;
			this.system_name = system;
			this.module_name = module;
			this.severity = severity;
			this.priority = priority;
			this.employee = employee;
			this.open_time = DateTime.Now;
			this.solved = false;
            this.incharge = null;
		}
	}
	
}
