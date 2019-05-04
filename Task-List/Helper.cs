using System;

namespace Task_List
{
    class Helper
    {
        public static int GetIntFromUser(string message)
        {
            Console.WriteLine(message);
            try
            {
                return int.Parse(Console.ReadLine());

            }
            catch (Exception e)
            {

                Console.WriteLine("Invalid Input! " + message);
                return GetIntFromUser(message);
            }
        }

        public static DateTime GetDateTimeFromUser(string message)
        {
            Console.WriteLine(message);
            try
            {
                return DateTime.Parse(Console.ReadLine());

            }
            catch (Exception e)
            {

                Console.WriteLine("Invalid Input! " + message);
                return GetDateTimeFromUser(message);
            }
        }

        public static DateTime GetDateTimeFromUser(string message, bool sameLine)
        {
            Console.Write(message);
            try
            {
                return DateTime.Parse(Console.ReadLine());

            }
            catch (Exception e)
            {

                Console.WriteLine("Invalid Input! ");
                return GetDateTimeFromUser(message, true);
            }
        }

        public static double GetDoubleFromUser(string message)
        {
            Console.WriteLine(message);
            try
            {
                return Double.Parse(Console.ReadLine());

            }
            catch (Exception e)
            {

                Console.WriteLine("Invalid Input!");
                return GetDoubleFromUser(message);
            }
        }

        public static bool GetYesOrNoFromUser(string prompt)
        {
            Console.WriteLine(prompt.Trim() + " (Yes or No)");
            string answer = Console.ReadLine().ToLower();
            if (answer == "y" || answer == "yes")
            {
                return true;
            }
            else if(answer == "n" || answer == "no")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid Input!");
                return GetYesOrNoFromUser(prompt);

            }
        }

        public static string GetStringFromUser(string message)
        {
            Console.WriteLine(message);
            string answer = Console.ReadLine().Trim();
            if (String.IsNullOrWhiteSpace(answer))
            {
                Console.WriteLine("You must enter something!");
                return GetStringFromUser(message);
            }
            return answer;
        }

        public static string GetStringFromUser(string message, bool sameLine)
        {
            Console.Write(message);
            string answer = Console.ReadLine().Trim();
            if (String.IsNullOrWhiteSpace(answer))
            {
                Console.WriteLine("You must enter something!");
                return GetStringFromUser(message);
            }
            return answer;
        }

        public static string AddSpacesToString(string str, int numberOfSpaces)
        {
            {
                int leng = numberOfSpaces - str.Length;
                for (int i = 0; i < leng; i++)
                {
                    str += " ";
                }
                return str;
            }
        }
    }
}
