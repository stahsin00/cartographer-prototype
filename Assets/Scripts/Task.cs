using System.Collections.Generic;

public class Task
{
    public string Name { get; private set;}
    public int X { get; private set;}
    public int Y { get; private set;}
    public List<Reward> Rewards { get; private set; }

    public Task(string name) {
        Name = name;
    }

    public void Execute() {

    }
}
