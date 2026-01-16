public class PromptGenerator
{
    private static Random random = new();
    private static List<string> _prompts = [
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What goal have I accomplished today?",
        "What detail did I notice today?"
    ];

    public static string GetRandomPrompt()
    {
        if (_prompts.Count <= 0)
        {
            Console.WriteLine("You have ran out of prompts for today!");
            return "";
        }

        int index = random.Next(_prompts.Count - 1);
        string prompt = _prompts[index];

        _prompts.RemoveAt(index);
        return prompt;
    }
}