using System;

class Program
{
    static void Main(string[] args)
    {
        List<Fractions> fractions = [new(), new(5), new(3, 4), new(1, 3)];

        fractions.ForEach((fraction) =>
        {
            Console.WriteLine(fraction.GetFractionString());
            Console.WriteLine(fraction.GetDecimalValue());
        });
    }
}