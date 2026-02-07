// Added a log file to the program that stores play counts for activities, also made proper use of the abstract class definition. (abstract Run method)
using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = [
            new BreathingActivity(),
            new ReflectingActivity([
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            ], [
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            ]),
            new ListingActivity([
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            ])
        ];

        while (true)
        {
            Console.WriteLine("Menu Options:");
            for (int index = 0; index < activities.Count; index++)
            {
                Console.WriteLine($"  {index + 1}: Start {activities[index].GetName().ToLower()} activity");
            }
            Console.WriteLine($"  {activities.Count + 1}: View log");
            Console.WriteLine($"  {activities.Count + 2}: Quit");
            Console.Write("Select a choice from the menu: ");

            int option;
            try
            {
                option = int.Parse(Console.ReadLine()) - 1;
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Invalid choice! Try again.");
                continue;
            }

            if (option == activities.Count + 1)
            {
                break;
            }
            else if (option == activities.Count)
            {
                Console.Clear();

                activities.ForEach((activity) =>
                {
                    Console.WriteLine($"{activity.GetName()} Activity: {activity.GetPlayCount()} plays");
                });

                Console.Write("Press enter to exit: ");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Activity activity;
                try
                {
                    activity = activities[option];
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Invalid choice! Try again.");
                    continue;
                }

                activity.DisplayStartingMessage();
                activity.Run();
                activity.DisplayEndingMessage();
            }
        }

        Environment.Exit(0);
    }
}