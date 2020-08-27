using System;

namespace Social_Security_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter your social security number (YYMMDD-XXXX): ");

            string socialSecurityNumber = Console.ReadLine();

            string gender = "female";
            int age = 0;

            // Chooses the slot from social security number to use to determine what gender the person is
            //string genderNumber = socialSecurityNumber.Substring(9, 1);

            int genderNumber = int.Parse(socialSecurityNumber.Substring(socialSecurityNumber.Length - 2, 1));

            gender = genderNumber % 2 != 0 ? "female" : "male";

            //int ageNumber = int.Parse(socialSecurityNumber.Substring(socialSecurityNumber.Length - 11, 6));
            string ageNumber = socialSecurityNumber.Substring(socialSecurityNumber.Length - 11, 6);

            Console.WriteLine("You're a {0} and {1} years old.", gender, age);
            //Console.WriteLine($"This is a {gender}, and the age is {age}");

            // For testing purposes
            Console.WriteLine(ageNumber);
            Console.WriteLine(genderNumber);
            
        }
    }
}
