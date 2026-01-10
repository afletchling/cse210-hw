using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        userNumber = SquareNumber(userNumber);

        DisplayResult(userName, userNumber);
    }

    private static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    private static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    private static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");

        try
        {
            return int.Parse(Console.ReadLine());
        }
        catch
        {
            return 0;
        }
    }

    private static int SquareNumber(int input)
    {
        return input * input;
    }

    private static void DisplayResult(string name, int number)
    {
        Console.WriteLine($"{name}, the square of your number is {number}");
    }
}