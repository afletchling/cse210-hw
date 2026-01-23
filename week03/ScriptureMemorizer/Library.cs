public class Library
{
    private List<Scripture> _scriptures = new();

    public void AddScripture(Scripture scripture)
    {
        _scriptures.Add(scripture);
    }

    public void AddScriptures(List<Scripture> scriptures)
    {
        scriptures.ForEach(AddScripture);
    }

    public Scripture GetRandomScripture()
    {
        return _scriptures[Random.Shared.Next(_scriptures.Count)];
    }
}