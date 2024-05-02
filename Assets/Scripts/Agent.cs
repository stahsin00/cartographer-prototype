using System.Collections.Generic;

public class Agent : Entity, IInteractable
{
    public AgentAction currentAction;
    private Queue<AgentAction> nextAction;

    public NeedManager needManager;

    List<Advertisement> advertisements;

    public Agent() {
        nextAction = new Queue<AgentAction>();

        needManager = new NeedManager();

        needManager.AddNeed(new Hunger());
        needManager.AddNeed(new Thirst());
        needManager.AddNeed(new Energy());

        advertisements = new List<Advertisement>();
        advertisements.Add(new Advertisement(new Queue<AgentAction>(new AgentAction[] {new AgentAction("Chat")}), "Social", 5f));
    }

    public void SelectAction() {
        // TODO :  ignore for now
    }

    public List<Advertisement> GetAdvertisements()
    {
        return advertisements;
    }
}
