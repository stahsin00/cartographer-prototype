using System.Collections.Generic;

public class Advertisement
{
    public Task Task { get; private set; }
    public List<Reward> Rewards { get; private set; }

    public Advertisement(Task task)
    {
        Task = task;
        Rewards = new List<Reward>();
    }

    public void AddReward(Reward reward)
    {
        Rewards.Add(reward);
    }
}
