using System.Collections.Generic;

public class Interaction
{
    public string Name { get; private set;}
    public int X { get; private set;}
    public int Y { get; private set;}
    public List<Reward> Rewards { get; private set; }
    public float Duration { get; private set; }

    public Interaction(string name) {
        Name = name;
    }

    public void Execute() {

    }
}
