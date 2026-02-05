using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment assignment = new("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(assignment.GetSummary());
        Console.WriteLine(assignment.GetHomeworkList());

        WritingAssignment assignment2 = new("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetWritingInformation());
    }
}