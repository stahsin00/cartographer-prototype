using System.Collections.Generic;

public class Agent : Entity, IInteractable
{
    public Task currentTask;
    private Queue<Task> nextTask;

    public NeedManager needManager;

    List<Advertisement> advertisements;

    public Agent() {
        nextTask = new Queue<Task>();

        needManager = new NeedManager();

        needManager.AddNeed(new Hunger());
        needManager.AddNeed(new Thirst());
        needManager.AddNeed(new Energy());

        advertisements = new List<Advertisement>();

        Advertisement advertisement = new Advertisement(new Task("Chat"));
        advertisement.AddReward(new Reward("Social", 5f));
        advertisements.Add(advertisement);
    }

    public void SelectAction() {
        // TODO :  ignore for now
        if (nextTask.Count > 0) {
            currentTask = nextTask.Dequeue();
        } else {
            
        }
    }

    public List<Advertisement> GetAdvertisements()
    {
        return advertisements;
    }
}
