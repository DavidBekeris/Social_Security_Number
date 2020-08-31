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


            string socialSecurityNumber;

            if (args.Length > 0)
            {
                Console.WriteLine($"Your numbers: {args[0]}");
                socialSecurityNumber = args[0];

            }
            else
            {
                Console.Write("Enter your social security number (YYMMDD-XXXX): ");
                socialSecurityNumber = args[1];
            }






            string gender;

            // Chooses the slot from social security number to use to determine what gender the person is
            //string genderNumber = socialSecurityNumber.Substring(9, 1);

            int genderNumber = int.Parse(socialSecurityNumber.Substring(socialSecurityNumber.Length - 2, 1));

            gender = genderNumber % 2 != 0 ? "male" : "female";

            //int ageNumber = int.Parse(socialSecurityNumber.Substring(socialSecurityNumber.Length - 11, 6));
            string ageNumber = socialSecurityNumber.Substring(socialSecurityNumber.Length - 11, 6);

            DateTime birthDate = DateTime.ParseExact(ageNumber, "yyMMdd", CultureInfo.InvariantCulture);

            int age = DateTime.Now.Year - birthDate.Year;

            if ((birthDate.Month > DateTime.Now.Month) || (birthDate.Month == DateTime.Now.Month && birthDate.Day > DateTime.Now.Day))
            {
                age--;
            }


            Console.WriteLine("You're a {0} and {1} years old.", gender, age);
            //Console.WriteLine($"This is a {gender}, and the age is {age}");

            // For testing purposes
            Console.WriteLine(ageNumber);
            Console.WriteLine(genderNumber);
            
        }
    }
}
