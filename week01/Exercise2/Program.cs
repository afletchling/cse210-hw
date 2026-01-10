using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        int gradePercent;

        while (true)
        {
            Console.Write("What is your grade percentage? ");
            try
            {
                gradePercent = int.Parse(Console.ReadLine());
                break;
            }
            catch
            {
                Console.WriteLine("Invalid grade percentage, please try again!");
            }
        }

        string gradeLetter;
        if (gradePercent >= 90)
        {
            gradeLetter = "A";
        }
        else if (gradePercent >= 80)
        {
            gradeLetter = "B";
        }
        else if (gradePercent >= 70)
        {
            gradeLetter = "C";
        }
        else if (gradePercent >= 60)
        {
            gradeLetter = "D";
        }
        else
        {
            gradeLetter = "F";
        }

        // Extra grade logic
        if (gradePercent < 97 && gradePercent > 59) // Simple bound checks for adding extra symbols
        {
            if (gradePercent % 10 >= 7)
            {
                gradeLetter += "+";
            }
            else if (gradePercent % 10 < 3)
            {
                gradeLetter += "-";
            }
        }

        Console.WriteLine($"You got a grade of {gradeLetter}");

        if (gradePercent >= 70)
        {
            Console.WriteLine("Congratulations for passing the class!");
        }
        else
        {
            Console.WriteLine("The percentage was not above the pass rate, better luck next time.");
        }
    }
}