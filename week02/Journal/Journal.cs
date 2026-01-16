using System.Text.Json;

public class Journal
{
    public List<JournalEntry> _entries = new();

    public void AddEntry()
    {
        string prompt = PromptGenerator.GetRandomPrompt();
        if (prompt == "")
        {
            return;
        }

        Console.WriteLine(prompt);
        Console.Write("> ");

        JournalEntry entry = new();
        entry._prompt = prompt;
        entry._response = Console.ReadLine();

        _entries.Add(entry);
    }

    public void SaveToFile(string file)
    {
        try
        {
            using (StreamWriter output = new StreamWriter(file))
            {
                output.WriteLine(JsonSerializer.Serialize(_entries));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to write file: {e}");
        }
    }

    public void LoadFromFile(string file)
    {
        try
        {
            _entries.Clear(); // cleanup even though the garbage collector will probably handle this for us, oh well.
            _entries = JsonSerializer.Deserialize<List<JournalEntry>>(File.ReadAllText(file));
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File not found");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to parse file: {e}");
        }
    }

    public void DisplayAll()
    {
        _entries.ForEach((JournalEntry entry) => entry.Display());
    }
}