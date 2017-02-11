using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOOAD
{
    public class Problem
    {
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
        private List<Ticket> ticketList = new List<Ticket>();
        public List<Ticket> TicketList
        {
            get
            {
                return this.ticketList;
            }
        }
        public Problem(string system, string problemdesc)
        {
            this.problem_desc = problemdesc;
            this.system_name = system;
        }
        public bool hasProblem(string system, string problemdesc)
        {
            if(this.system_name == system || this.problem_desc == problemdesc)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void updateSolution(string probsolution)
        {
            this.solution = probsolution;
        }
        public void addTicket(Ticket ticket)
        {
            this.ticketList.Add(ticket);
        }

    }
}
