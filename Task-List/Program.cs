using System;
using System.Collections.Generic;

namespace Task_List
{
    class Program
    {
        enum MenuAction { list=1, clearFilters, filterByTeamMember, filterByBeforeDate, add, edit, delete, complete, quit };//Enum for switch statments
        static void Main(string[] args)
        {
            //Create menu strings
            List<string> menuItems = new List<string> {
                "List tasks",
                "Clear Filters",
                "Add Filter by team member",
                "Add Filter before date",
                "Add task",
                "Edit task",
                "Delete task",
                "Toggle task complete",
                "Quit"
            };
            Menu menu = new Menu(menuItems);

            TaskApp tasks = new TaskApp();//create our task app and add some tasks 
            tasks.AddTask("Andre Otte", "make bed really well", DateTime.Parse("05/25/2019"));
            tasks.AddTask("Eric Holt", "write kick-ass code", DateTime.Today);
            tasks.AddTask("Eric Holt", "cook noodles", DateTime.Today);

            int filterChoiceName = -1;//Non filter starting number
            DateTime filterChoiceDate = DateTime.MaxValue;//Set to max date when not filtered
            bool run = true;
            while (run)
            {
                Console.WriteLine("---------------------------------");
                menu.PrintMenu("Task Actions");
                int userInput = Helper.GetIntFromUser("Which Action: ");

                switch (userInput)
                {
                    case (int)MenuAction.list:
                        Console.Clear();
                        tasks.ListTasks(filterChoiceName, filterChoiceDate);
                        break;
                    case (int)MenuAction.clearFilters:
                        filterChoiceName = -1;
                        filterChoiceDate = DateTime.MaxValue;
                        break;
                    case (int)MenuAction.filterByTeamMember:
                        tasks.ListTaskTeamMembers();
                        filterChoiceName = Helper.GetIntFromUser("Enter number of team member: ");
                        break;
                    case (int)MenuAction.filterByBeforeDate:
                        filterChoiceDate = Helper.GetDateTimeFromUser("Enter date to filter tasks due before: ");
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
                        tasks.ToggleTaskComplete(filterChoiceName, filterChoiceDate);
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
