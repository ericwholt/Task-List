using System;
using System.Collections.Generic;

namespace Task_List
{
    class Menu
    {
        public int MenuItem { get; }
        public List<string> MenuItems { get; }

        public Menu(List<string> MenuItems)
        {
            this.MenuItems = MenuItems;
        }

        public void PrintMenu()
        {
            for(int i = 1; i < (MenuItems.Count + 1); i++)
            {
                Console.WriteLine($"{i}) {MenuItems[i - 1]} ");
            }
        }
        public void PrintMenu(string header)
        {

            Console.WriteLine(header);
            PrintMenu();
        }
    }
}
