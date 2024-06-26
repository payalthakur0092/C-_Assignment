using System;


using System.IO;
using System.Linq;

namespace BirthdayProgram
{
    internal partial class Program
    {
        private static bool UserLogin()
        {
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            while (!IsValidEmail(email))
            {
                Console.WriteLine("Invalid email format. Please enter a valid email address.");
                Console.Write("Enter Email: ");
                email = Console.ReadLine();
            }

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            while (!IsValidPassword(password))
            {
                Console.WriteLine("Invalid password format. Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one digit.");
                Console.Write("Enter Password: ");
                password = Console.ReadLine();
            }

            string[] lines = File.ReadAllLines(_registrationLogPath);
            foreach (var line in lines)
            {
                var parts = line.Split(':');
                if (parts.Length == 4 && parts[1] == email && parts[3] == password)
                {
                    Console.WriteLine($"Welcome {email}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Press 1: Display Upcoming Birthdays\nPress 2: Logout\nPress 3: Exit");
                    Console.ResetColor();
                    string choice = Console.ReadLine();

                    while (!IsValidChoice(choice, 1, 3))
                    {
                        Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                        Console.Write("Choice: ");
                        choice = Console.ReadLine();
                    }

                    switch (choice)
                    {
                        case "1":
                            DisplayUpcomingBirthdays();
                            return true;

                        case "2":
                            Console.WriteLine("Logged out successfully.");
                            return false;

                        case "3":
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Logging out.");
                            return false;
                    }
                }
            }

            Console.WriteLine("Invalid email or password. Please try again.");
            return false;
        }
    }
}