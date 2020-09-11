using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using static System.Console;

namespace Social_Security_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = "";
            string lastName = "";
            //string firstAndLastName = firstName + " " + lastName;
            string socialSecurityNumber;

            if (args.Length > 0)
            {
                Console.WriteLine($"Your name: {args[0]} {args[1]} \nSocial security number: {args[2]}");
                firstName = args[0];
                lastName = args[1];
                socialSecurityNumber = args[2];
            }
            else
            {
                Console.WriteLine("Enter your first name:");
                firstName = Console.ReadLine();
                Console.WriteLine("Enter your last name:");
                lastName = Console.ReadLine();
                Console.Write("Enter your social security number (YYMMDD-XXXX): ");
                socialSecurityNumber = Console.ReadLine();
            }

            string gender;

            // Chooses the slot from social security number to use to determine what gender the person is
            //string genderNumber = socialSecurityNumber.Substring(9, 1);
            int genderNumber, age;
            string ageNumber;
            GetGender(socialSecurityNumber, out gender, out genderNumber);
            CalculateAge(socialSecurityNumber, out ageNumber, out age);

            Console.Clear();
            Console.WriteLine("Name: {0} {1} \nSocial Security number: {2} \nGender: {3} \nAge: {4}", firstName, lastName, socialSecurityNumber, gender, age);
            //Console.WriteLine($"This is a {gender}, and the age is {age}");

            // For testing purposes
            Console.WriteLine("\n\n{0}", ageNumber);
            Console.WriteLine(genderNumber);

        }

        private static void GetGender(string socialSecurityNumber, out string gender, out int genderNumber)
        {
            genderNumber = int.Parse(socialSecurityNumber.Substring(socialSecurityNumber.Length - 2, 1));
            gender = genderNumber % 2 != 0 ? "Male" : "Female";

            //int ageNumber = int.Parse(socialSecurityNumber.Substring(socialSecurityNumber.Length - 11, 6));
            string ageNumber;
        }

        private static void CalculateAge(string socialSecurityNumber, out string ageNumber, out int age)
        {
            ageNumber = socialSecurityNumber.Substring(socialSecurityNumber.Length - 11, 6);
            DateTime birthDate = DateTime.ParseExact(ageNumber, "yyMMdd", CultureInfo.InvariantCulture);

            age = DateTime.Now.Year - birthDate.Year;
            if ((birthDate.Month > DateTime.Now.Month) || (birthDate.Month == DateTime.Now.Month && birthDate.Day > DateTime.Now.Day))
            {
                age--;
            }
        }
    }
}
