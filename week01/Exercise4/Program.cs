using System;
using System.Collections.Generic;

class Program
{
    private static List<int> numberList = new();

    static void Main(string[] args)
    {
        double sum = 0;
        int bigNumber = 0;
        int smallNumber = int.MaxValue;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            int inputNumber;
            Console.Write("Enter Number: ");

            try
            {
                inputNumber = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid number, please try again!");
                continue;
            }

            if (inputNumber == 0)
            {
                break;
            }
            else
            {
                numberList.Add(inputNumber);
            }
        }

        numberList.Sort();

        foreach (int number in numberList)
        {
            sum += number;
            bigNumber = int.Max(bigNumber, number);
            smallNumber = number > 0 ? int.Min(smallNumber, number) : smallNumber;
        }

        double average = 0;
        if (numberList.Count > 0)
        {
            average = sum / numberList.Count;
        }
        else
        {
            smallNumber = 0;
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {bigNumber}");
        Console.WriteLine($"The smallest positive number is: {smallNumber}");

        Console.WriteLine("The sorted list is:");
        numberList.ForEach(Console.WriteLine);
    }
}