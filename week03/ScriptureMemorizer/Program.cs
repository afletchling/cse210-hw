using System;

class Program
{
    static void Main(string[] args)
    {
        Library library = new();
        library.AddScriptures([
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths."
            ),
            new Scripture(
                new Reference("Moses", 3, 1),
                "And I, God, blessed the seventh day, and sanctified it; because that in it I had rested from all my work which I, God, had created and made."
            ),
            new Scripture(
                new Reference("Genesis", 3, 2, 3),
                "And the woman said unto the serpent, We may eat of the fruit of the trees of the garden: But of the fruit of the tree which is in the midst of the garden, God hath said, Ye shall not eat of it, neither shall ye touch it, lest ye die."
            )
        ]);

        Scripture scripture = library.GetRandomScripture();
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            scripture.HideRandomWords(3);

            string input = Console.ReadLine().ToLower().Trim();
            if (input == "quit")
            {
                break;
            }
        }

        Environment.Exit(0);
    }
}