using System;

namespace Lab3_1StudentInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Joseph Murphy", "Brianna Stephenson", "Ronnie Ramirez" };
            string[] foods = { "Cheeseburgers", "Baby Back Ribs", "Pizza" };
            string[] titles = { "Business Analyst", "Delay Analyst", "Desktop Support" };
            int userInput = 0;
            bool validInput = false;

            Console.WriteLine("Welcome to our Dev.Build class. Here are the students in the class:");
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"{i + 1} {names[i]}");
            }
            Console.Write($"Which student would you like to learn more about? (enter a number 1-{names.Length}): ");    
            while (!validInput)
            {
                validInput = IsValidInteger(Console.ReadLine(), 1, 3, out userInput);
            }
            Console.WriteLine($"Student {userInput} is {names[userInput - 1]}. What would you like to know about {names[userInput - 1]}? (enter “favorite food” or “previous title”): ");
        }

        // Takes in a string, a minimum integer, a maximum integer, and out int parameter. The method will return true if the string is a positive integer that fits within the minimum and maximum parameters and copy that value to the out parameter. If the string does not hit the previously stated criteria, the method will return false and the out parameter will be assigned a value of 0.
        // Note: I am open on suggestions to this method. As I was putting it together it was feeling a bit clunky...
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
                        Console.Write($"Sorry, the max number that this program can go to is {max}! Try again: ");
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
                    Console.Write("Whoops, your input needs to be a whole number! Try again: ");
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
    }
}
