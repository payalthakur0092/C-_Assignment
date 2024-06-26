using System.Collections.Generic;
using System.Globalization;
using System;


using System.IO;
using System.Linq;

namespace BirthdayProgram
{
    internal partial class Program
    {
        private static void DisplayUpcomingBirthdays()
        {
            Console.Write("\nPlease enter your Filename: ");
            string filePath = Console.ReadLine();

            while (!IsValidFilename(filePath))
            {
                Console.WriteLine("Invalid filename. Please enter a valid filename.");
                Console.Write("Filename: ");
                filePath = Console.ReadLine();
            }

            try
            {
                var employees = ReadEmployeeData(_birthdayPath);

                Console.WriteLine("\nUpcoming Birthdays:");
                DisplayUpcomingBirthdays(employees, 10);

                Console.WriteLine("\nPress 1: Logout\nPress 2: Exit");
                string choice = Console.ReadLine();

                while (!IsValidChoice(choice, 1, 2))
                {
                    Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                    Console.Write("Choice: ");
                    choice = Console.ReadLine();
                }

                if (choice == "1")
                {
                    Console.WriteLine("You have been logged out.");
                    AutoLogin();
                }
                else if (choice == "2")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Exiting program.");
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static List<Employee> ReadEmployeeData(string filePath)
        {
            var employees = new List<Employee>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 2)
                {
                    string name = parts[0].Trim();
                    if (DateTime.TryParseExact(parts[1].Trim(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dob))
                    {
                        employees.Add(new Employee { Name = name, DateOfBirth = dob });
                    }
                }
            }

            return employees;
        }

        static void DisplayUpcomingBirthdays(List<Employee> employees, int days)
        {
            var today = DateTime.Today;
            var upcomingBirthdays = new List<Employee>();

            foreach (var employee in employees)
            {
                var nextBirthday = employee.DateOfBirth.AddYears(today.Year - employee.DateOfBirth.Year);
                if (nextBirthday < today)
                {
                    nextBirthday = nextBirthday.AddYears(1);
                }

                if ((nextBirthday - today).Days <= days)
                {
                    upcomingBirthdays.Add(employee);
                }
            }

            upcomingBirthdays.Sort((emp1, emp2) => emp1.DateOfBirth.CompareTo(emp2.DateOfBirth));

            foreach (var employee in upcomingBirthdays)
            {
                var birthdayThisYear = employee.DateOfBirth.AddYears(today.Year - employee.DateOfBirth.Year);
                if (birthdayThisYear < today)
                {
                    birthdayThisYear = birthdayThisYear.AddYears(1);
                }
                Console.WriteLine($"{employee.Name} - {birthdayThisYear:dd MMMM}");
            }
        }
    }
}