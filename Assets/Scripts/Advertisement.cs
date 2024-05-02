using System.Collections.Generic;

public class Advertisement
{
    public Queue<AgentAction> actions;
    public string NeedType;
    public float Effectiveness;

    public Advertisement(Queue<AgentAction> actions, string NeedType, float Effectiveness) {
        this.actions = actions;
        this.NeedType = NeedType;
        this.Effectiveness = Effectiveness;

    }
}
