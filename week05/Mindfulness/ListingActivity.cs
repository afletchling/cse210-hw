public class ListingActivity : Activity
{
    private List<string> _prompts;

    public ListingActivity(List<string> prompts) : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = prompts;
    }

    public override void Run()
    {
        int count = 0;
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        GetRandomPrompt();

        Console.Write("You may begin in: ");
        ShowCountDown(5);

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"You listed {count} items!\n");
    }

    private void GetRandomPrompt()
    {
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {_prompts[Random.Shared.Next(_prompts.Count)]} ---");
    }
}