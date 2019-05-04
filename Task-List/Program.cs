using System;
using System.Collections.Generic;

namespace Task_List
{
    class Program
    {
        // list of task objects
        public static List<Task> tasks = new List<Task>();
        enum MenuAction { list=1, listTeamMember, listBeforeDate, add, edit, delete, complete, quit };
        static void Main(string[] args)
        {

            List<string> menuItems = new List<string> { "List tasks", "List tasks by team member", "List tasks before date", "Add task", "Edit task", "Delete task", "Mark task complete", "Quit" };
            Menu menu = new Menu(menuItems);

            //menu.PrintMenu("Task Actions");
            TaskApp tasks = new TaskApp();
            tasks.AddTask("Andre Otte", "make bed really well", DateTime.Parse("05/25/2019"));
            tasks.AddTask("Eric Holt", "write kick-ass code", DateTime.Today);
            tasks.AddTask("Eric Holt", "cook noodles", DateTime.Today);


            int filterChoiceName = -1;
            DateTime filterChoiceDate = DateTime.MaxValue;
            bool run = true;
            while (run)
            {
                Console.WriteLine();
                menu.PrintMenu("Task Actions");
                int userInput = Helper.GetIntFromUser("Which Action: ");

                switch (userInput)
                {
                    case (int)MenuAction.list:
                        Console.Clear();
                        filterChoiceName = -1;
                        filterChoiceDate = DateTime.MaxValue;
                        //menu.PrintMenu("Task Actions");
                        tasks.ListTasks();
                        break;
                    case (int)MenuAction.listTeamMember:
                        tasks.ListTaskTeamMembers();
                        filterChoiceName = Helper.GetIntFromUser("Enter number of team member: ");
                        tasks.ListTasks(filterChoiceName, filterChoiceDate);
                        break;
                    case (int)MenuAction.listBeforeDate:
                        filterChoiceDate = Helper.GetDateTimeFromUser("Enter date to filter tasks due before: ");
                        tasks.ListTasks(filterChoiceName, filterChoiceDate);
                        break;
                    case (int)MenuAction.add:
                        Console.Clear();
                        tasks.AddTask(
                            Helper.GetStringFromUser("Please enter team member name: "), 
                            Helper.GetStringFromUser("Please enter task description: "), 
                            Helper.GetDateTimeFromUser("Please enter task due date: ")
                            );
                        break;
                    case (int)MenuAction.edit:
                        Console.Clear();
                        tasks.EditTask(filterChoiceName, filterChoiceDate);
                        break;
                    case (int)MenuAction.delete:
                        tasks.DeleteTask(filterChoiceName, filterChoiceDate);
                        Console.Clear();
                        break;
                    case (int)MenuAction.complete:
                        tasks.MarkTaskComplete(filterChoiceName, filterChoiceDate);
                        Console.Clear();
                        break;
                    case (int)MenuAction.quit:
                        if (Helper.GetYesOrNoFromUser("Are you sure you want to quit?"))
                        {
                            run = false;
                            Console.WriteLine("Goodbye!");
                        }
                        break;
                }
            }


        }
    }
}
