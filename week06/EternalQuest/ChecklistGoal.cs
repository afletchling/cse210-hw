public class ChecklistGoal : Goal
{
    private int _amountCompleted = 0;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{GetName()},{GetDescription()},{GetPoints()},{_bonus},{_target},{_amountCompleted}";
    }

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {GetName()} ({GetDescription()}) -- Currently Completed: {_amountCompleted}/{_target}";
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;
        return GetPoints() + (_amountCompleted >= _target ? _bonus : 0);
    }

    public override void LoadData(string[] data)
    {
        _amountCompleted = int.Parse(data[5]);
    }
}