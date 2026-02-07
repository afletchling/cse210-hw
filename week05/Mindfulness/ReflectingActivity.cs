public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity(List<string> prompts, List<string> questions) : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = prompts;
        _questions = questions;
    }

    public override void Run()
    {
        Console.WriteLine("Get ready...");
        ShowSpinner(5);

        DisplayPrompt();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.Clear();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            DisplayQuestion();
            ShowSpinner(15);
        }
    }

    private string GetRandomPrompt()
    {
        return _prompts[Random.Shared.Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        return _questions[Random.Shared.Next(_questions.Count)];
    }

    private void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($"--- {GetRandomPrompt()} ---\n");
    }

    private void DisplayQuestion()
    {
        Console.Write($"> {GetRandomQuestion()} ");
    }
}