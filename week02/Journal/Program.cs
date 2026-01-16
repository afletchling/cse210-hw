using System;

class Program
{
    private static Journal _journal = new();
    private static List<string> choices = [
        "Write",
        "Display",
        "Load",
        "Save",
        "Quit"
    ];

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");

        while (true)
        {
            Console.WriteLine("Please select one of the following choices:");
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {choices[i]}");
            }

            Console.Write("What would you like to do? ");
            switch (Console.ReadLine())
            {
                case "1":
                    _journal.AddEntry();
                    break;
                case "2":
                    _journal.DisplayAll();
                    break;
                case "3":
                    _journal.LoadFromFile(GetFileName());
                    break;
                case "4":
                    _journal.SaveToFile(GetFileName());
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
    }

    private static string GetFileName()
    {
        Console.WriteLine("What is the filename?");
        return Console.ReadLine();
    }
}