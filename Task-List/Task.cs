using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_List
{
    class Task
    {
        // declare global vars and Properties
        public string TeamMemberName { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completed { get; set; }

        // Constructor
        public Task(string TeamMemberName, string Description, DateTime DueDate, bool Completed)
        {
            this.TeamMemberName = TeamMemberName;
            this.Description = Description;
            this.DueDate = DueDate;
            this.Completed = Completed;
        }

        public Task(string Name, string Description, DateTime DueDate)
        {
            this.TeamMemberName = Name;
            this.Description = Description;
            this.DueDate = DueDate;
        }
    }
}
