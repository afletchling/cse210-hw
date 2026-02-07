public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {

    }

    public override void Run()
    {
        Console.WriteLine("Get ready...");
        ShowSpinner(5);

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            ShowCountDown(3);

            Console.Write("Now breathe out...");
            ShowCountDown(3);

            Console.Write("\n");
        }
    }
}