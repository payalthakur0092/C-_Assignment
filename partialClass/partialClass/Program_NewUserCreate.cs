using System.Linq;
using System;


using System.IO;


namespace BirthdayProgram
{
    internal partial class Program
    {
        private static string GenerateRandomEmail()
        {
            Random random = new Random();
            return $"user{random.Next(1, 1000)}@gmail.com";
        }

        private static string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static void NewUserCreate()
        {
            string newEmail = GenerateRandomEmail();
            string newPassword = GenerateRandomPassword();

            Console.WriteLine($"Your new account has been created.");
            Console.WriteLine($"Email: {newEmail}");
            Console.WriteLine($"Password: {newPassword}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            File.AppendAllText(_registrationLogPath, $"Email:{newEmail}:Password:{newPassword}{Environment.NewLine}");
        }
    }
}