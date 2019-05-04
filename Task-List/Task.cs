using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_List
{
    class Task
    {
        // declare global vars and Properties
        public string TeamMemberName { get; private set; }
        public string Description { get; private set; }
        public DateTime DueDate { get; private set; }
        public bool Completed { get; private set; }
        public double UniqueId { get; }
        

        // Constructor
        public Task(string TeamMemberName, string Description, DateTime DueDate, bool Completed)
        {
            this.UniqueId = Helper.GetUniqueId();
            this.TeamMemberName = TeamMemberName;
            this.Description = Description;
            this.DueDate = DueDate;
            this.Completed = Completed;
        }

        public Task(string Name, string Description, DateTime DueDate)
        {
            this.UniqueId = Helper.GetUniqueId();
            this.TeamMemberName = Name;
            this.Description = Description;
            this.DueDate = DueDate;
            this.Completed = false;
        }

        public void UpdateTask(string TeamMemberName, string Description, DateTime DueDate, bool Completed)
        {
            this.TeamMemberName = TeamMemberName;
            this.Description = Description;
            this.DueDate = DueDate;
            this.Completed = Completed;
        }

        public void UpdateTaskTeamMember(string TeamMemberName)
        {
            this.TeamMemberName = TeamMemberName;
        }

        public void UpdateTaskDescription(string Description)
        {
            this.Description = Description;
        }

        public void UpdateTaskDueDate(DateTime dueDate)
        {
            this.DueDate = dueDate;
        }

        public void ToggleComplete()
        {
            this.Completed = !this.Completed;
        }
    }
}
