public class JournalEntry
{
    // get and set is needed to properly define if JsonSerializer can parse the JournalEntry.
    public string _date { get; set; } = DateTime.Now.ToShortDateString();
    public string _prompt { get; set; } = "";
    public string _response { get; set; } = "";

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine(_response + "\n");
    }
}