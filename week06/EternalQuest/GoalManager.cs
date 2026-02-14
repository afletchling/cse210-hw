using System.Text;

public class GoalManager
{
    private List<Goal> _goals = [];
    private int _score = 0;

    public GoalManager()
    {

    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine($"\nYou have {_score} points.\n");
            Console.WriteLine("""
            Menu Options:
                1. Create New Goal
                2. List Goals
                3. Save Goals
                4. Load Goals
                5. Record Event
                6. Quit
            """);

            Console.Write("Select a choice from the menu: ");
            switch (Console.ReadLine())
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    return;
            }
        }
    }

    private void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("""
            1. Simple Goal
            2. Eternal Goal
            3. Checklist Goal
        """);

        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        int points = ParseInt("What is the amount of points associated with this goal? ");

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else
        {
            int target = ParseInt("How many times does this goal need to be accomplished for a bonus? ");
            int bonus = ParseInt("What is the bonus for accomplishing it that many times? ");

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    private void RecordEvent()
    {
        if (_goals.Count <= 0)
        {
            Console.WriteLine("You have no goals!");
            return;
        }

        ListGoalNames();

        Goal goal;
        while (true)
        {
            Console.Write("Which goal did you accomplish? ");
            try
            {
                goal = _goals[int.Parse(Console.ReadLine()) - 1];
                break;
            }
            catch
            {
                Console.WriteLine("Invalid goal! Please try again.");
            }
        }

        if (!goal.IsComplete())
        {
            int points = goal.RecordEvent();
            Console.WriteLine($"Congratulations! You have earned {points} points!");

            _score += points;
            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("This goal has already been completed.");
        }
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(_score.ToString());
                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
        }
        catch
        {
            Console.WriteLine("Failed to write to file.");
        }
    }

    private void LoadGoals()
    {
        _goals.Clear();
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        //try
        //{
            string[] content = File.ReadAllLines(fileName);
            _score = int.Parse(content[0].Trim());

            for (int index = 1; index < content.Length; index++)
            {
                string entry = content[index];
                string[] info = entry.Split(":");
                string[] data = info[1].Split(",");

                Goal goal;
                if (info[0] == "SimpleGoal")
                {
                    goal = new SimpleGoal(data[0], data[1], int.Parse(data[2]));
                }
                else if (info[0] == "EternalGoal")
                {
                    goal = new EternalGoal(data[0], data[1], int.Parse(data[2]));
                }
                else
                {
                    goal = new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[4]), int.Parse(data[3]));
                }

                goal.LoadData(data);
                _goals.Add(goal);
            }
        //}
        //catch
        //{
        //    Console.WriteLine("Failed to read from file.");
        //}
    }

    private int ParseInt(string message)
    {
        while (true)
        {
            Console.Write(message);

            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid number, try again!");
            }
        }
    }
}