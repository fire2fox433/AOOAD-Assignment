using System;
using System.Collections.Generic;
namespace AOOAD
{
	public class Report
	{
        private DateTime time_printed;
        public DateTime Time_printed
        {
            get
            {
                return this.time_printed;
            }
            set
            {
                this.time_printed = value;
            }
        }
        public Report()
        {
            this.time_printed = DateTime.Now;
        }
    }
}
