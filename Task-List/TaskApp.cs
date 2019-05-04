using System;
using System.Collections.Generic;

namespace Task_List
{
    class TaskApp
    {
        private List<Task> _tasks = new List<Task>();

        public void AddTask(string name, string description, DateTime dueDate)
        {
            //Console.WriteLine("ADD TASK");
            Task task = new Task(name, description, dueDate);
            _tasks.Add(task);
        }

        public void ListTasks()
        {
            Console.WriteLine();
            Console.WriteLine("LIST TASK");
            List<string> taskNames = new List<string>();
            string yes = "yes";
            string no = "no";
            string header = $"   {Helper.AddSpacesToString("Completed", 15)}{Helper.AddSpacesToString("Team Member", 18)}{Helper.AddSpacesToString("Due Date", 20)}{Helper.AddSpacesToString("Description", 35)}";
            Console.WriteLine(header);
            foreach (Task task in _tasks)
            {
                taskNames.Add($"{Helper.AddSpacesToString((task.Completed ? yes : no), 15)}{Helper.AddSpacesToString(task.TeamMemberName, 18)}{Helper.AddSpacesToString(task.DueDate.ToString(),20)}{Helper.AddSpacesToString(task.Description, 35)}");
            }

            Menu menu = new Menu(taskNames);
            Console.WriteLine();
            menu.PrintMenu();
        }

        public void DeleteTask()
        {
            Console.WriteLine("DELETE TASK");
            ListTasks();
            int delete = Helper.GetIntFromUser("What task would you like to delete?");

            // confirm that the user wants to actually delete
            bool confirmed = Helper.GetYesOrNoFromUser("Are you sure?");
            if(confirmed)
            {
                _tasks.RemoveAt(delete - 1);
            }
        }

        public void MarkTaskComplete()
        {
            Console.WriteLine("MARK TASK COMPLETE");
            ListTasks();
            Console.WriteLine("What task is completed?");
            int task = int.Parse(Console.ReadLine()) - 1;
            _tasks[task].Completed = !_tasks[task].Completed;
        }

    }
}
