// My addition to the requirements was making a proper data parse method for loading each Goal.
using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new();
        manager.Start();
        Environment.Exit(0);
    }
}