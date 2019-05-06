using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_List
{
    class TaskApp
    {
        private List<Task> _tasks = new List<Task>();
        private List<string> _teamMemberNames = new List<string>();
        private string ConsoleHeader = $"   {Helper.AddSpacesToString("Completed", 15)}{Helper.AddSpacesToString("Team Member", 18)}{Helper.AddSpacesToString("Due Date", 15)}{Helper.AddSpacesToString("Description", 35)}";

        /// <summary>
        /// Add Task
        /// </summary>
        /// <param name="teamMemberName">string</param>
        /// <param name="description">string</param>
        /// <param name="dueDate">DateTime</param>
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

        /// <summary>
        /// Delete task
        /// </summary>
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

        /// <summary>
        /// Delete task filtered by team member name.
        /// </summary>
        /// <param name="teamMemberNameIndex">int</param>
        public void DeleteTask(int teamMemberNameIndex)
        {
            if (teamMemberNameIndex == -1)
            {
                DeleteTask();
            }
            else
            {

                List<Task> filteredList = FilterTasksTeamMemberIndex(_tasks, teamMemberNameIndex);

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

        /// <summary>
        /// Delete task filtered before date
        /// </summary>
        /// <param name="beforeDate">DateTime</param>
        public void DeleteTask(DateTime beforeDate)
        {
            List<Task> filteredList = FilterTasksBeforeDate(_tasks, beforeDate);

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
        }


        /// <summary>
        /// Delete task filtered by team member name and before date
        /// </summary>
        /// <param name="teamMemberNameIndex">int</param>
        /// <param name="beforeDate">DateTime</param>
        public void DeleteTask(int teamMemberNameIndex, DateTime beforeDate)
        {
            if (teamMemberNameIndex == -1)
            {
                DeleteTask(beforeDate);
            }
            else
            {
                List<Task> filteredList = FilterTasksBeforeDate(FilterTasksTeamMemberIndex(_tasks, teamMemberNameIndex), beforeDate);

                Console.WriteLine("DELETE TASK");
                ListTasks(teamMemberNameIndex, beforeDate);//Don't subtract 1 because the ListTaskFilteredBy does it for you.
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

        /// <summary>
        /// Toggle task complete.
        /// </summary>
        public void ToggleTaskComplete()
        {
            Console.WriteLine("TOGGLE TASK COMPLETE");
            ListTasks();
            if (_tasks.Count > 0)
            {
                int task = Helper.GetIntFromUser("Choose task to toggle complete: ");
                _tasks[task].ToggleComplete();
            }
            else
            {
                Console.WriteLine("No tasks to mark complete!");
                return;
            }
        }

        /// <summary>
        /// Toggle task complete.
        /// </summary>
        /// <param name="beforeDate">DateTime</param>
        public void ToggleTaskComplete(DateTime beforeDate)
        {
            Console.WriteLine("TOGGLE TASK COMPLETE");
            ListTasks(beforeDate);
            List<Task> filteredList = FilterTasksBeforeDate(_tasks, beforeDate);
            if (_tasks.Count > 0)
            {
                int task = Helper.GetIntFromUser("Choose task to toggle complete: ");

                try
                {
                    foreach (Task item in _tasks)
                    {

                        if (item == filteredList[task - 1])
                        {
                            item.ToggleComplete();
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

        /// <summary>
        /// Toggle task complete. Tasks filtered by team name member.
        /// </summary>
        /// <param name="teamMemberNameIndex"></param>
        public void ToggleTaskComplete(int teamMemberNameIndex)
        {
            if (teamMemberNameIndex == -1)
            {
                ToggleTaskComplete();
            }
            else
            {
                List<Task> filteredList = FilterTasksTeamMemberIndex(_tasks, teamMemberNameIndex);
                Console.WriteLine("TOGGLE TASK COMPLETE");
                ListTasks(teamMemberNameIndex);//Don't subtract 1 because the ListTasks does it for you.
                if (filteredList.Count > 0)
                {

                    int task = Helper.GetIntFromUser("Choose task to toggle complete: ");

                    try
                    {
                        foreach (Task item in _tasks)
                        {

                            if (item == filteredList[task - 1])
                            {
                                item.ToggleComplete();
                            }
                        }
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Unable to toggle complete");
                    }

                }
                else
                {
                    Console.WriteLine("No tasks to mark complete!");
                    return;
                }
            }
        }

        /// <summary>
        /// Toggle task complete. Tasks filtered by team name member and before date.
        /// </summary>
        /// <param name="teamMemberNameIndex">int</param>
        /// <param name="beforeDate">DateTime</param>
        public void ToggleTaskComplete(int teamMemberNameIndex, DateTime beforeDate)
        {
            if (teamMemberNameIndex == -1)
            {
                ToggleTaskComplete(beforeDate);
            }
            else if (beforeDate == DateTime.MaxValue)
            {
                ToggleTaskComplete(teamMemberNameIndex);
            }
            else
            {
                List<Task> filteredList = FilterTasksBeforeDate(FilterTasksTeamMemberIndex(_tasks, teamMemberNameIndex), beforeDate);

                Console.WriteLine("TOGGLE TASK COMPLETE");
                ListTasks(teamMemberNameIndex, beforeDate);//Don't subtract 1 because the ListTasks does it for you.
                if (filteredList.Count > 0)
                {

                    int task = Helper.GetIntFromUser("Choose task to toggle complete: ");

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
                                    item.ToggleComplete();
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

        /// <summary>
        /// Edit selected task. Will ask if you want to edit each column.
        /// </summary>
        public void EditTask()
        {
            Console.WriteLine("EDIT TASK");
            ListTasks();
            int task = Helper.GetIntFromUser("What task would you like to edit?  ");


            bool status = Helper.GetYesOrNoFromUser($"Mark task as {(_tasks[task - 1].Completed ? "not completed?" : "completed?")} ");
            try
            {
                if (Helper.GetYesOrNoFromUser("Edit team member name?"))
                {
                    string teamMemberName = Helper.GetStringFromUser("Enter team member name: ");
                    _tasks[task - 1].UpdateTaskTeamMember(teamMemberName);
                }
                if (Helper.GetYesOrNoFromUser("Edit task description?"))
                {
                    string description = Helper.GetStringFromUser("Enter task description: ");
                    _tasks[task - 1].UpdateTaskDescription(description);
                }
                if (Helper.GetYesOrNoFromUser("Edit due date?"))
                {
                    DateTime dueDate = Helper.GetDateTimeFromUser("Enter due date: ");
                    _tasks[task - 1].UpdateTaskDueDate(dueDate);
                }
                if (Helper.GetYesOrNoFromUser("Toggle complete?"))
                {
                    _tasks[task - 1].ToggleComplete();
                }
                
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to edit task");
                return;
            }


        }

        /// <summary>
        /// Edit selected task. Will ask if you want to edit each column. Tasks are filtered by before date then gets user selection.
        /// </summary>
        /// <param name="beforeDate">DateTime</param>
        public void EditTask(DateTime beforeDate)
        {
            try
            {
                List<Task> filteredList = FilterTasksBeforeDate(_tasks, beforeDate);
                Console.WriteLine("EDIT TASK");
                ListTasks(beforeDate);
                if (filteredList.Count > 0)
                {

                    int task = Helper.GetIntFromUser("What task would you like to edit?  ");

                    foreach (Task item in _tasks)
                    {
                        if (item == filteredList[task - 1])
                        {
                            if (Helper.GetYesOrNoFromUser("Edit team member name?"))
                            {
                                string teamMemberName = Helper.GetStringFromUser("Enter team member name: ");
                                item.UpdateTaskTeamMember(teamMemberName);
                            }
                            if (Helper.GetYesOrNoFromUser("Edit task description?"))
                            {
                                string description = Helper.GetStringFromUser("Enter task description: ");
                                item.UpdateTaskDescription(description);
                            }
                            if (Helper.GetYesOrNoFromUser("Edit due date?"))
                            {
                                DateTime dueDate = Helper.GetDateTimeFromUser("Enter due date: ");
                                item.UpdateTaskDueDate(dueDate);
                            }
                            if (Helper.GetYesOrNoFromUser("Toggle complete?"))
                            {
                                item.ToggleComplete();
                            }
                            //item.UpdateTask(teamMemberName, description, dueDate, status);
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

        /// <summary>
        /// Edit selected task. Will ask if you want to edit each column. Tasks are filtered by team member name and before date then gets user selection.
        /// </summary>
        /// <param name="teamMemberNameIndex">int</param>
        /// <param name="beforeDate">DateTime</param>
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

                    List<Task> filteredList = FilterTasksBeforeDate(FilterTasksTeamMemberIndex(_tasks, teamMemberNameIndex), beforeDate);
                    Console.WriteLine("EDIT TASK");
                    ListTasks(teamMemberNameIndex, beforeDate);
                    if (filteredList.Count > 0)
                    {

                        int task = Helper.GetIntFromUser("What task would you like to edit?  ");

                        foreach (Task item in _tasks)
                        {
                            if (item == filteredList[task - 1])
                            {
                                if (Helper.GetYesOrNoFromUser("Edit team member name?"))
                                {
                                    string teamMemberName = Helper.GetStringFromUser("Enter team member name: ");
                                    item.UpdateTaskTeamMember(teamMemberName);
                                }
                                if (Helper.GetYesOrNoFromUser("Edit task description?"))
                                {
                                    string description = Helper.GetStringFromUser("Enter task description: ");
                                    item.UpdateTaskDescription(description);
                                }
                                if (Helper.GetYesOrNoFromUser("Edit due date?"))
                                {
                                    DateTime dueDate = Helper.GetDateTimeFromUser("Enter due date: ");
                                    item.UpdateTaskDueDate(dueDate);
                                }
                                if (Helper.GetYesOrNoFromUser("Toggle complete?"))
                                {
                                    item.ToggleComplete();
                                }
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

        /// <summary>
        /// List all tasks
        /// </summary>
        public void ListTasks()
        {
            List<string> tasksList = new List<string>();

            Console.WriteLine();//Create seperator
            Console.WriteLine("LIST TASK");//Action description
            Console.WriteLine(ConsoleHeader);//Display header
            foreach (Task task in _tasks)
            {
                tasksList.Add(task.GetConsoleText());
            }
            Menu menu = new Menu(tasksList);
            menu.PrintMenu();

        }

        /// <summary>
        /// List tasks matching team member name(index of task)
        /// </summary>
        /// <param name="teamMemberNameIndex">int</param>
        public void ListTasks(int teamMemberNameIndex)
        {
            try
            {
                List<string> tasksList = new List<string>();

                Console.WriteLine();//Create seperator
                Console.WriteLine("LIST TASK");//Action description
                Console.WriteLine(ConsoleHeader);//Display header
                foreach (Task task in _tasks)
                {
                    if (task.TeamMemberName == _teamMemberNames[teamMemberNameIndex - 1])
                    {
                        tasksList.Add(task.GetConsoleText());
                    }
                }
                Menu menu = new Menu(tasksList);
                menu.PrintMenu();
            }
            catch (Exception)
            {

                Console.WriteLine("Invalid Team Member Selected. Displaying unfiltered list.");
                ListTasks();
            }
        }

        /// <summary>
        /// List all tasks before date
        /// </summary>
        /// <param name="beforeDate"></param>
        public void ListTasks(DateTime beforeDate)
        {
            //string header = $"   {Helper.AddSpacesToString("Completed", 15)}{Helper.AddSpacesToString("Team Member", 18)}{Helper.AddSpacesToString("Due Date", 15)}{Helper.AddSpacesToString("Description", 35)}";
            List<string> tasksList = new List<string>();
            Console.WriteLine();//Create seperator
            Console.WriteLine("LIST TASK");//Action description
            Console.WriteLine(ConsoleHeader);//Display header
            foreach (Task task in _tasks)
            {
                if (task.DueDate < beforeDate)
                {
                        tasksList.Add(task.GetConsoleText());
                }
            }
            Menu menu = new Menu(tasksList);
            menu.PrintMenu();
        }

        /// <summary>
        /// List tasks by team member and any task before date
        /// </summary>
        /// <param name="teamMemberNameIndex">int</param>
        /// <param name="beforeDate">DateTime</param>
        public void ListTasks(int teamMemberNameIndex, DateTime beforeDate)
        {
            if (teamMemberNameIndex == -1)
            {
                ListTasks(beforeDate);
            }
            else
            {
                List<string> tasksList = new List<string>();

                Console.WriteLine();//Create seperator
                Console.WriteLine("LIST TASK");//Action description
                Console.WriteLine(ConsoleHeader);//Display header
                foreach (Task task in _tasks)
                {
                    if (task.DueDate < beforeDate && task.TeamMemberName == _teamMemberNames[teamMemberNameIndex - 1])
                    {
                        tasksList.Add(task.GetConsoleText());
                    }
                }
                Menu menu = new Menu(tasksList);
                menu.PrintMenu();
            }
        }

        /// <summary>
        /// Prints menu of team members.
        /// </summary>
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
            menu.PrintMenu();
        }


        /// <summary>
        /// Filter a list of tasks before date
        /// </summary>
        /// <param name="tasks">List<Task></param>
        /// <param name="beforeDate">DateTime</param>
        /// <returns>List<Task></returns>
        private List<Task> FilterTasksBeforeDate(List<Task> tasks, DateTime beforeDate)
        {
            List<Task> filteredList = tasks.Where(x => x.DueDate < beforeDate).ToList();
            return filteredList;
        }

        /// <summary>
        /// Filter a list of tasks by team Member Name Index
        /// </summary>
        /// <param name="tasks">List<Task></param>
        /// <param name="teamMemberNameIndex">Int</param>
        /// <returns>List<Task></returns>
        private List<Task> FilterTasksTeamMemberIndex(List<Task> tasks, int teamMemberNameIndex)
        {
            List<Task> filteredList = tasks.Where(x => x.TeamMemberName == _teamMemberNames[teamMemberNameIndex - 1]).ToList();
            return filteredList;
        }
    }
}
