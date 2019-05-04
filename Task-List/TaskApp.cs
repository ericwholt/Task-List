using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_List
{
    class TaskApp
    {
        private List<Task> _tasks = new List<Task>();
        private List<string> _teamMemberNames = new List<string>();
        public void AddTask(string teamMemberName, string description, DateTime dueDate)
        {
            try
            {
                Task task = new Task(teamMemberName, description, dueDate);
                _tasks.Add(task);
                if (!_teamMemberNames.Contains(task.TeamMemberName))
                {
                    _teamMemberNames.Add(task.TeamMemberName);
                }

            }
            catch (Exception)
            {

                Console.WriteLine("Unable to add task!");
            }
        }

        public void DeleteTask()
        {
            Console.WriteLine("DELETE TASK");
            ListTasks();
            if (_tasks.Count > 0)
            {
                int delete = Helper.GetIntFromUser("What task would you like to delete?");

                // confirm that the user wants to actually delete
                bool confirmed = Helper.GetYesOrNoFromUser("Are you sure?");
                if (confirmed)
                {
                    _tasks.RemoveAt(delete - 1);
                }
            }
            else
            {
                Console.WriteLine("No tasks to delete!");
                return;
            }
        }

        public void DeleteTask(int teamMemberNameIndex)
        {
            if (teamMemberNameIndex == -1)
            {
                DeleteTask();
            }
            else
            {

                List<Task> filteredList = _tasks.Where(x => x.TeamMemberName == _teamMemberNames[teamMemberNameIndex - 1]).ToList();

                Console.WriteLine("DELETE TASK");
                ListTasks(teamMemberNameIndex);//Don't subtract 1 because the ListTaskFilteredBy does it for you.
                if (filteredList.Count > 0)
                {

                    int delete = Helper.GetIntFromUser("What task would you like to delete?");

                    // confirm that the user wants to actually delete
                    bool confirmed = Helper.GetYesOrNoFromUser("Are you sure?");
                    if (confirmed)
                    {
                        try
                        {
                            _tasks.Remove(filteredList[delete - 1]);

                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Unable to delete");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No tasks to delete");
                    return;
                }
            }
        }

        public void DeleteTask(DateTime beforeDate)
        {
            //if (teamMemberNameIndex == -1)
            //{
            //    DeleteTask();
            //}
            //else
            //{

            List<Task> filteredList = _tasks.Where(x => x.DueDate < beforeDate).ToList();

            Console.WriteLine("DELETE TASK");
                ListTasks(beforeDate);//Don't subtract 1 because the ListTaskFilteredBy does it for you.
                if (filteredList.Count > 0)
                {

                    int delete = Helper.GetIntFromUser("What task would you like to delete?");

                    // confirm that the user wants to actually delete
                    bool confirmed = Helper.GetYesOrNoFromUser("Are you sure?");
                    if (confirmed)
                    {
                        try
                        {
                            _tasks.Remove(filteredList[delete - 1]);

                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Unable to delete");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No tasks to delete");
                    return;
                }
            //}
        }

        public void DeleteTask(int teamMemberNameIndex, DateTime beforeDate)
        {
            if (teamMemberNameIndex == -1)
            {
                DeleteTask(beforeDate);
            }
            else
            {
                List<Task> filteredList1 = _tasks.Where(x => x.TeamMemberName == _teamMemberNames[teamMemberNameIndex - 1]).ToList();
                List<Task> filteredList = filteredList1.Where(x => x.DueDate < beforeDate).ToList();

                Console.WriteLine("DELETE TASK");
                ListTasks(teamMemberNameIndex);//Don't subtract 1 because the ListTaskFilteredBy does it for you.
                if (filteredList.Count > 0)
                {

                    int delete = Helper.GetIntFromUser("What task would you like to delete?");

                    // confirm that the user wants to actually delete
                    bool confirmed = Helper.GetYesOrNoFromUser("Are you sure?");
                    if (confirmed)
                    {
                        try
                        {
                            _tasks.Remove(filteredList[delete - 1]);

                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Unable to delete");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No tasks to delete");
                    return;
                }
            }
        }

        public void MarkTaskComplete()
        {
            Console.WriteLine("MARK TASK COMPLETE");
            ListTasks();
            if (_tasks.Count > 0)
            {
                int task = Helper.GetIntFromUser("What task is completed?");
                _tasks[task].Completed = !_tasks[task].Completed;
            }
            else
            {
                Console.WriteLine("No tasks to mark complete!");
                return;
            }
        }

        public void MarkTaskComplete(DateTime beforeDate)
        {
            Console.WriteLine("MARK TASK COMPLETE");
            ListTasks(beforeDate);
            List<Task> filteredList = _tasks.Where(x => x.DueDate < beforeDate).ToList();
            if (_tasks.Count > 0)
            {
                int task = Helper.GetIntFromUser("What task is completed?");
                //_tasks[task].Completed = !_tasks[task].Completed;

                try
                {
                    foreach (Task item in _tasks)
                    {

                        if (item == filteredList[task - 1])
                        {
                            item.Completed = !item.Completed;
                        }
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Unable to mark complete");
                }
            }
            else
            {
                Console.WriteLine("No tasks to mark complete!");
                return;
            }
        }

        public void MarkTaskComplete(int teamMemberNameIndex)
        {
            if (teamMemberNameIndex == -1)
            {
                MarkTaskComplete();
            }
            else
            {
                List<Task> filteredList = _tasks.Where(x => x.TeamMemberName == _teamMemberNames[teamMemberNameIndex - 1]).ToList();
                Console.WriteLine("MARK TASK COMPLETE");
                ListTasks(teamMemberNameIndex);//Don't subtract 1 because the ListTasks does it for you.
                if (filteredList.Count > 0)
                {

                    int task = Helper.GetIntFromUser("What task is completed?");

                    try
                    {
                        foreach (Task item in _tasks)
                        {

                            if (item == filteredList[task - 1])
                            {
                                item.Completed = !item.Completed;
                            }
                        }
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Unable to mark complete");
                    }

                }
                else
                {
                    Console.WriteLine("No tasks to mark complete!");
                    return;
                }
            }
        }

        public void MarkTaskComplete(int teamMemberNameIndex, DateTime beforeDate)
        {
            if (teamMemberNameIndex == -1)
            {
                MarkTaskComplete(beforeDate);
            }
            else if (beforeDate == DateTime.MaxValue)
            {
                MarkTaskComplete(teamMemberNameIndex);
            }
            else
            {
                List<Task> filteredList1 = _tasks.Where(x => x.TeamMemberName == _teamMemberNames[teamMemberNameIndex - 1]).ToList();
                List<Task> filteredList = filteredList1.Where(x => x.DueDate < beforeDate).ToList();
                Console.WriteLine("MARK TASK COMPLETE");
                ListTasks(teamMemberNameIndex);//Don't subtract 1 because the ListTasks does it for you.
                if (filteredList.Count > 0)
                {

                    int task = Helper.GetIntFromUser("What task is completed?");

                    // confirm that the user wants to actually delete
                    bool confirmed = Helper.GetYesOrNoFromUser("Are you sure?");
                    if (confirmed)
                    {
                        try
                        {
                            foreach (Task item in _tasks)
                            {

                                if (item == filteredList[task - 1])
                                {
                                    item.Completed = !item.Completed;
                                }
                            }
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Unable to mark complete");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No tasks to mark complete!");
                    return;
                }
            }
        }

        public void EditTask()
        {
            Console.WriteLine("EDIT TASK");
            ListTasks();
            int task = Helper.GetIntFromUser("What task would you like to edit?  ");
            string teamMemberName = Helper.GetStringFromUser("Enter team member name: ");
            string description = Helper.GetStringFromUser("Enter task description: ");
            DateTime dueDate = Helper.GetDateTimeFromUser("Enter due date: ");
            bool status = Helper.GetYesOrNoFromUser($"Mark task as {(_tasks[task - 1].Completed ? "not completed?" : "completed?")} ");
            try
            {
                _tasks[task - 1].UpdateTask(teamMemberName, description, dueDate, status);
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to edit task");
                return;
            }


        }

        public void EditTask(DateTime beforeDate)
        {
            try
            {

                //List<Task> filteredList1 = _tasks.Where(x => x.TeamMemberName == _teamMemberNames[teamMemberNameIndex - 1]).ToList();
                List<Task> filteredList = _tasks.Where(x => x.DueDate < beforeDate).ToList();
                Console.WriteLine("EDIT TASK");
                ListTasks(beforeDate);
                if (filteredList.Count > 0)
                {

                    int task = Helper.GetIntFromUser("What task would you like to edit?  ");
                    string teamMemberName = Helper.GetStringFromUser("Enter team member name: ");
                    string description = Helper.GetStringFromUser("Enter task description: ");
                    DateTime dueDate = Helper.GetDateTimeFromUser("Enter due date: ");
                    bool status = Helper.GetYesOrNoFromUser($"Mark task as {(_tasks[task - 1].Completed ? "not completed?" : "completed?")} ");

                    foreach (Task item in _tasks)
                    {
                        if (item == filteredList[task - 1])
                        {
                            item.UpdateTask(teamMemberName, description, dueDate, status);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Nothing to edit.");
                }
            }
            catch (Exception)
            {
                EditTask();
            }
        }

        public void EditTask(int teamMemberNameIndex, DateTime beforeDate)
        {
            if (teamMemberNameIndex == -1)
            {
                EditTask(beforeDate);
            }
            else
            {

                try
                {

                    List<Task> filteredList1 = _tasks.Where(x => x.TeamMemberName == _teamMemberNames[teamMemberNameIndex - 1]).ToList();
                    List<Task> filteredList = filteredList1.Where(x => x.DueDate < beforeDate).ToList();
                    Console.WriteLine("EDIT TASK");
                    ListTasks(teamMemberNameIndex, beforeDate);
                    if (filteredList.Count > 0)
                    {

                        int task = Helper.GetIntFromUser("What task would you like to edit?  ");
                        string teamMemberName = Helper.GetStringFromUser("Enter team member name: ");
                        string description = Helper.GetStringFromUser("Enter task description: ");
                        DateTime dueDate = Helper.GetDateTimeFromUser("Enter due date: ");
                        bool status = Helper.GetYesOrNoFromUser($"Mark task as {(_tasks[task - 1].Completed ? "not completed?" : "completed?")} ");

                        foreach (Task item in _tasks)
                        {
                            if (item == filteredList[task - 1])
                            {
                                item.UpdateTask(teamMemberName, description, dueDate, status);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nothing to edit.");
                    }
                }
                catch (Exception)
                {
                    EditTask();
                }
            }
        }

        public void ListTasks()
        {
            List<string> tasksList = new List<string>();
            string yes = "yes";
            string no = "no";
            string header = $"   {Helper.AddSpacesToString("Completed", 15)}{Helper.AddSpacesToString("Team Member", 18)}{Helper.AddSpacesToString("Due Date", 15)}{Helper.AddSpacesToString("Description", 35)}";

            Console.WriteLine();//Create seperator
            Console.WriteLine("LIST TASK");//Action description
            Console.WriteLine(header);//Display header
            foreach (Task task in _tasks)
            {
                tasksList.Add($"{Helper.AddSpacesToString((task.Completed ? yes : no), 15)}{Helper.AddSpacesToString(task.TeamMemberName, 18)}{Helper.AddSpacesToString(task.DueDate.ToString("MM/dd/yyyy"), 15)}{Helper.AddSpacesToString(task.Description, 35)}");
            }
            Menu menu = new Menu(tasksList);
            Console.WriteLine();
            menu.PrintMenu();

        }

        public void ListTasks(int teamMemberNameIndex)
        {
            try
            {
                List<string> tasksList = new List<string>();
                string yes = "yes";
                string no = "no";
                string header = $"   {Helper.AddSpacesToString("Completed", 15)}{Helper.AddSpacesToString("Team Member", 18)}{Helper.AddSpacesToString("Due Date", 15)}{Helper.AddSpacesToString("Description", 35)}";

                Console.WriteLine();//Create seperator
                Console.WriteLine("LIST TASK");//Action description
                Console.WriteLine(header);//Display header
                foreach (Task task in _tasks)
                {
                    if (task.TeamMemberName == _teamMemberNames[teamMemberNameIndex - 1])
                    {
                        tasksList.Add($"{Helper.AddSpacesToString((task.Completed ? yes : no), 15)}{Helper.AddSpacesToString(task.TeamMemberName, 18)}{Helper.AddSpacesToString(task.DueDate.ToString("MM/dd/yyyy"), 15)}{Helper.AddSpacesToString(task.Description, 35)}");
                    }
                }
                Menu menu = new Menu(tasksList);
                Console.WriteLine();
                menu.PrintMenu();
            }
            catch (Exception)
            {

                Console.WriteLine("Invalid Team Member Selected. Displaying unfiltered list.");
                ListTasks();
            }
        }

        public void ListTasks(DateTime date)
        {
            string header = $"   {Helper.AddSpacesToString("Completed", 15)}{Helper.AddSpacesToString("Team Member", 18)}{Helper.AddSpacesToString("Due Date", 15)}{Helper.AddSpacesToString("Description", 35)}";
            List<string> tasksList = new List<string>();
            string yes = "yes";
            string no = "no";
            Console.WriteLine();//Create seperator
            Console.WriteLine("LIST TASK");//Action description
            Console.WriteLine(header);//Display header
            foreach (Task task in _tasks)
            {
                if (task.DueDate < date)
                {
                    tasksList.Add($"{Helper.AddSpacesToString((task.Completed ? yes : no), 15)}{Helper.AddSpacesToString(task.TeamMemberName, 18)}{Helper.AddSpacesToString(task.DueDate.ToString("MM/dd/yyyy"), 15)}{Helper.AddSpacesToString(task.Description, 35)}");
                }
            }
            Menu menu = new Menu(tasksList);
            Console.WriteLine();
            menu.PrintMenu();
        }

        public void ListTasks(int teamMemberNameIndex, DateTime date)
        {
            if (teamMemberNameIndex == -1)
            {
                ListTasks(date);
            }
            else
            {

                string header = $"   {Helper.AddSpacesToString("Completed", 15)}{Helper.AddSpacesToString("Team Member", 18)}{Helper.AddSpacesToString("Due Date", 15)}{Helper.AddSpacesToString("Description", 35)}";
                List<string> tasksList = new List<string>();
                string yes = "yes";
                string no = "no";
                Console.WriteLine();//Create seperator
                Console.WriteLine("LIST TASK");//Action description
                Console.WriteLine(header);//Display header
                foreach (Task task in _tasks)
                {
                    if (task.DueDate < date && task.TeamMemberName == _teamMemberNames[teamMemberNameIndex - 1])
                    {
                        tasksList.Add($"{Helper.AddSpacesToString((task.Completed ? yes : no), 15)}{Helper.AddSpacesToString(task.TeamMemberName, 18)}{Helper.AddSpacesToString(task.DueDate.ToString("MM/dd/yyyy"), 15)}{Helper.AddSpacesToString(task.Description, 35)}");
                    }
                }
                Menu menu = new Menu(tasksList);
                Console.WriteLine();
                menu.PrintMenu();
            }
        }

        public void ListTaskTeamMembers()
        {
            List<string> nameList = new List<string>();
            string header = $"   {Helper.AddSpacesToString("Team Member", 18)}";

            Console.WriteLine();//Create seperator
            Console.WriteLine("LIST TEAM MEMBERS");//Action description
            Console.WriteLine(header);//Display header
            foreach (string name in _teamMemberNames)
            {
                nameList.Add($"{Helper.AddSpacesToString(name, 18)}");
            }

            Menu menu = new Menu(nameList);
            Console.WriteLine();
            menu.PrintMenu();
        }


    }
}
