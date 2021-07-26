using System;

namespace Lab3_1StudentInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                // Creating student data and declaring variables
                string[] names = { "Joseph Murphy", "Brianna Stephenson", "Ronnie Ramirez" };
                string[] foods = { "Cheeseburgers", "Baby Back Ribs", "Pizza" };
                string[] titles = { "Business Analyst", "Delay Analyst", "Desktop Support" };
                int userInt = 0;
                bool validInput = false;
                string userString = "";

                // Display student names for user
                Console.WriteLine("Welcome to our Dev.Build class. Here are the students in the class:");
                for (int i = 0; i < names.Length; i++)
                {
                    Console.WriteLine($"{i + 1} {names[i]}");
                }

                // Have user select a student to get more information about
                Console.Write($"Which student would you like to learn more about? (enter a number 1-{names.Length}): ");
                while (!validInput)
                {
                    validInput = IsValidInteger(Console.ReadLine(), 1, names.Length, out userInt);
                }

                // Find out which piece of information they would like to know about he student
                validInput = false;
                while (!validInput)
                {
                    Console.Write($"\nStudent {userInt} is {names[userInt - 1]}. What would you like to know about {names[userInt - 1]}? (enter “favorite food” or “previous title”): ");
                    userString = Console.ReadLine();
                    validInput = IsValidString(userString, "favorite food", "previous title");
                }

                // Display chose information
                DisplayInformation(userString, names[userInt - 1], foods[userInt - 1]);

            } while (KeepGoing()); 
        }

        // Takes in a string, a minimum integer, a maximum integer, and out int parameter. The method will return true if the string is a positive integer that fits within the minimum and maximum parameters and copy that value to the out parameter. If the string does not hit the previously stated criteria, the method will return false and the out parameter will be assigned a value of 0.
        static bool IsValidInteger(string userInput, int min, int max, out int parsedInput)
        {
            while (true)
            {
                // Using TryParse to attempt to get an integer from the string provided by the user.
                bool inputIsNumber = Int32.TryParse(userInput, out parsedInput);

                // If TryParse returns true and the parsed integer is greater than the minimum and less than or equal to max, then return true. If it is greater than or equal the maximum, then return false and direct the user to pick a smaller integer.
                if (inputIsNumber && parsedInput >= min)
                {
                    if (parsedInput > max)
                    {
                        Console.Write($"Sorry, there are only {max} students in the class! Please input a number between {min} and {max}: ");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                // If TryParse returns false, then tell the user to input a whole number.
                else if (!inputIsNumber)
                {
                    Console.Write($"Whoops, your input needs to be a whole number between {min} and {max}! Try again: ");
                    return false;
                }
                // If the parsed integer is less than 1, then direct the user to pick a number greater than 0.
                else if (parsedInput < min)
                {
                    Console.Write($"Whoops, your input needs to be at least {min}! Try again: ");
                    parsedInput = 0;
                    return false;
                }
                // Otherwise, return false.
                else
                {
                    return false;
                }
            }
        }

        //static bool IsValidString(string userInput, string validInput1, string validInput2)
        //{
        //    while (true)
        //    {
        //        if (userInput.ToUpper() == validInput1.ToUpper() || userInput.ToUpper() == validInput2.ToUpper())
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}

        static bool IsValidString(string userInput, string validInput1, string validInput2)
        {
            bool validString = false;
            while (!validString)
            {
                validString = false;
                for (int i = 0; i < userInput.Length; i++)
                {
                    char letter = char.ToUpper(userInput[i]);
                    if (letter != char.ToUpper(validInput1[i]) && letter != char.ToUpper(validInput2[i]))
                    {
                        validString = false;
                        break;
                    }
                    else
                    {
                        validString = true;
                    }
                }
            }
            return validString;
        }

        static void DisplayInformation(string userInput, string student, string food)
        {
            if (userInput.ToUpper() == "FAVORITE FOOD")
            {
                Console.WriteLine($"\n{student}'s favorite food is {food}\n");
            }
            else
            {
                Console.WriteLine($"\n{student}'s previous title was {food}\n");
            }
        }

        static bool KeepGoing()
        {
            while (true)
            {
                Console.Write("Would you like to know about another student? (enter “yes” or “no): ");
                string response = Console.ReadLine().ToUpper();

                if (response == "Y" || response == "YES")
                {
                    Console.WriteLine();
                    return true;
                }
                else if (response == "N" || response == "NO")
                {
                    Console.WriteLine("\nThanks!");
                    return false;
                }
                else
                {
                    Console.WriteLine("Please enter 'yes' or 'no'");
                }
            }
        }
    }
}
