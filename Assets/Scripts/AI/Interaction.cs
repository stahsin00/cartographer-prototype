using System.Collections.Generic;

public abstract class Interaction
{
    public string Name { get; protected set;}
    public int X { get; private set;}
    public int Y { get; private set;}
    public List<Reward> Rewards { get; protected set; }
    public float Duration { get; private set; }

    public Interaction() {
        Rewards = new List<Reward>();
    }

    public abstract void Execute();
}
