using System.Text;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        foreach (string content in text.Split(" "))
        {
            _words.Add(new Word(content));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        for (int count = 0; count < numberToHide; )
        {
            Word word = _words[Random.Shared.Next(_words.Count)];

            if (!word.IsHidden())
            {
                word.Hide();
                count++;
            }
        }
    }

    public string GetDisplayText()
    {
        List<string> content = new();

        foreach (Word word in _words)
        {
            content.Add(word.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()} {string.Join(' ', content)}";
    }

    public bool IsCompletelyHidden()
    {
        return !_words.Any((Word word) => !word.IsHidden());
    }
}