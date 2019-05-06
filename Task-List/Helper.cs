using System;

namespace Task_List
{
    class Helper
    {

        private static double _uniqueId = -1; 

        /// <summary>
        /// Get a UniqueId starting at 0 and increased when used. Can overflow to negative value. Will be unique till it reachs -1.
        /// </summary>
        /// <returns>double</returns>
        public static double GetUniqueId()
        {
            SetUniqueId(_uniqueId + 1);
            
            return _uniqueId;
        }

        /// <summary>
        /// Method for GetUniqueID to set the value of _uniqueId
        /// </summary>
        /// <param name="value">double</param>
        private static void SetUniqueId(double value)
        {
            _uniqueId = value;
        }

        /// <summary>
        /// Prompts user with message, gets valid response and returns value(int).
        /// </summary>
        /// <param name="message">string</param>
        /// <returns>int</returns>
        public static int GetIntFromUser(string message)
        {
            Console.Write(message);
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

        /// <summary>
        /// Prompts user with message, gets valid response and returns value(DateTime).
        /// </summary>
        /// <param name="message">string</param>
        /// <returns>DateTime</returns>
        public static DateTime GetDateTimeFromUser(string message)
        {
            Console.Write(message);
            try
            {
                return DateTime.Parse(Console.ReadLine());

            }
            catch (Exception e)
            {

                Console.WriteLine("Invalid Input! ");
                return GetDateTimeFromUser(message);
            }
        }

        /// <summary>
        /// Prompts user with message, gets valid response and returns value(double).
        /// </summary>
        /// <param name="message">string</param>
        /// <returns>double</returns>
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

        /// <summary>
        /// Pass string into method with message. Add's Yes or No to it and writes it to console. Returns true for yes and false for no
        /// </summary>
        /// <param name="prompt">string</param>
        /// <returns>bool</returns>
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

        /// <summary>
        /// Get a string from user. Validates it is not null or just whitespace
        /// </summary>
        /// <param name="message">string</param>
        /// <returns>string</returns>
        public static string GetStringFromUser(string message)
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

        /// <summary>
        /// Returns string with spaces on right side equal to string length minus int number of spaces.
        /// </summary>
        /// <param name="str">string</param>
        /// <param name="numberOfSpaces">int</param>
        /// <returns>string</returns>
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
