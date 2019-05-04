using System;
using System.Collections.Generic;

namespace Task_List
{
    class Program
    {
        // list of task objects
        public static List<Task> tasks = new List<Task>();
        enum MenuAction { list=1, add, delete, complete, quit };
        static void Main(string[] args)
        {
            List<string> menuItems = new List<string> { "List tasks", "Add task", "Delete task", "Mark task complete", "Quit" };
            Menu menu = new Menu(menuItems);

            menu.PrintMenu("Task Actions");
            TaskApp tasks = new TaskApp();
            tasks.AddTask("Andre Otte", "make bed really well", DateTime.Parse("05/25/2019"));
            tasks.AddTask("Eric Holt", "write kick-ass code", DateTime.Today);
            tasks.AddTask("Eric Holt", "cook noodles", DateTime.Today);

            

            bool run = true;
            while (run)
            {
                int userInput = Helper.GetIntFromUser("Which Action");

                switch (userInput)
                {
                    case (int)MenuAction.list:
                        Console.Clear();
                        menu.PrintMenu("Task Actions");
                        tasks.ListTasks();
                        break;
                    case (int)MenuAction.add:
                        Console.Clear();
                        tasks.AddTask(
                            Helper.GetStringFromUser("Please enter team member name: ", true), 
                            Helper.GetStringFromUser("Please enter task description: ", true), 
                            Helper.GetDateTimeFromUser("Please enter task due date: ", true)
                            );
                        menu.PrintMenu("Task Actions");
                        break;
                    case (int)MenuAction.delete:
                        tasks.DeleteTask();
                        Console.Clear();
                        menu.PrintMenu("Task Actions");
                        break;
                    case (int)MenuAction.complete:
                        tasks.MarkTaskComplete();
                        Console.Clear();
                        menu.PrintMenu("Task Actions");
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
