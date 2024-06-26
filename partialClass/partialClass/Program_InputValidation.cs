using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


﻿using System;


namespace BirthdayProgram
{
    internal partial class Program
    {
        private static bool IsValidEmail(string email)
        {
            
            return !string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private static bool IsValidPassword(string password)
        {
            
            return !string.IsNullOrWhiteSpace(password) &&
                   password.Length >= 8 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) &&
                   password.Any(char.IsDigit);
        }

        private static bool IsValidChoice(string choice, int min, int max)
        {
           
            if (int.TryParse(choice, out int parsedChoice))
            {
                return parsedChoice >= min && parsedChoice <= max;
            }
            return false;
        }

        private static bool IsValidFilename(string filename)
        {
            
            return !string.IsNullOrWhiteSpace(filename) && filename.IndexOfAny(Path.GetInvalidFileNameChars()) < 0;
        }
    }
}