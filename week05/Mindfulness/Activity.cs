public abstract class Activity
{
    private string _name;
    private string _description;
    private int duration;
    private int playCount;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetDuration()
    {
        return duration;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine($"{_description}\n");
        Console.Write("How long, in seconds, would you like for your session? ");

        while (true)
        {
            try
            {
                duration = int.Parse(Console.ReadLine());
                break;
            }
            catch
            {
                Console.Write("Invalid duration! Please try again. ");
            }
        }

        Console.Clear();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!!");
        ShowSpinner(5);
        Console.WriteLine($"You have completed another {duration} seconds of the {_name} Activity.");
        ShowSpinner(5);
        Console.Clear();
        playCount++;
    }

    public abstract void Run();

    public void ShowSpinner(int seconds)
    {
        List<string> spinner = ["\\", "|", "/", "-"];
        Console.Write(spinner[0]);

        for (int timePassed = 0; timePassed < seconds; timePassed++)
        {
            for (int index = 0; index < spinner.Count; index++)
            {
                Console.Write("\b \b");
                Console.Write(spinner[index]);
                Thread.Sleep(1000 / spinner.Count);
            }
        }

        Console.Write("\b \b\n");
    }

    public void ShowCountDown(int seconds)
    {
        Console.Write(seconds);

        for (int countdown = seconds; countdown > 0; countdown--)
        {
            Console.Write("\b \b");
            Console.Write(countdown);
            Thread.Sleep(1000);
        }

        Console.Write("\b \b\n");
    }

    public int GetPlayCount()
    {
        return playCount;
    }
}