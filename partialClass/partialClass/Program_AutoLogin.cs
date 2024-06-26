using System.IO;
using System;



using System.Linq;
using System.Reflection;

namespace BirthdayProgram
{
    internal partial class Program
    {
        private static void AutoLogin()
        {
            CheckFilesExist();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Press 1: Create New User\nPress 2: Login");
                Console.ResetColor();
                string choice = Console.ReadLine();

                while (!IsValidChoice(choice, 1, 2))
                {
                    Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                    Console.Write("Choice: ");
                    choice = Console.ReadLine();
                }

                switch (choice)
                {
                    case "1":
                        NewUserCreate();
                        break;

                    case "2":
                        if (UserLogin())
                        {
                            return;
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static void CheckFilesExist()
        {
            try
            {
                if (!Directory.Exists(_directoryPath))
                {
                    Directory.CreateDirectory(_directoryPath);
                }

                if (!File.Exists(_registrationLogPath))
                {
                    File.Create(_registrationLogPath).Close();
                }

                if (!File.Exists(_birthdayPath))
                {
                    File.Create(_birthdayPath).Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating directory or files: {ex.Message}");
            }
        }
    }
}