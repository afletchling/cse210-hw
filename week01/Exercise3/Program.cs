using System;

class Program
{
    private static Random random = new();

    static void Main(string[] args)
    {
        while (true)
        {
            int magicNumber = 1 + random.Next(99);
            int guessCount = 0;

            while (true)
            {
                int currentGuess;
                Console.Write("What is your guess? ");

                try
                {
                    currentGuess = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid guess number, please try again!");
                    continue;
                }

                guessCount++;

                string guessMessage = "You guessed it!";
                bool endGame = false;

                if (currentGuess == magicNumber)
                {
                    endGame = true;
                }
                else if (currentGuess > magicNumber)
                {
                    guessMessage = "Lower";
                }
                else
                {
                    guessMessage = "Higher";
                }

                Console.WriteLine(guessMessage);

                if (endGame)
                {
                    Console.Write($"You have guessed {guessCount} times, do you want to play again? ");

                    string playAnswer = Console.ReadLine().ToLower();
                    if (playAnswer == "yes")
                    {
                        break;
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}