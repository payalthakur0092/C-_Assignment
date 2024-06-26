using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BirthdayProgram
{
    internal partial class Program
    {
        private static readonly string _directoryPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\", "UserDetails");
        private static readonly string _registrationLogPath = Path.Combine(_directoryPath, "UserRegistrationDetails.txt");
        private static readonly string _birthdayPath = Path.Combine(_directoryPath, "details.txt");

        static void Main(string[] args)
        {
            AutoLogin();
        }

        class Employee
        {
            public string Name { get; set; }
            public DateTime DateOfBirth { get; set; }
        }
    }
}