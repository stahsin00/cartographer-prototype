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
            DecideBestAction(WorldController.Instance.GetAdvertisements());
        }
    }

    public void DecideBestAction(List<Advertisement> actions)
        {
            float score = 0f;
            int nextBestActionIndex = 0;
            
            for (int i = 0; i < actions.Count; i++)
            {
                float curScore = ScoreAdvertisement(actions[i]);
                if (curScore > score)
                {
                    nextBestActionIndex = i;
                    score = curScore;
                }
            }

            currentTask = actions[nextBestActionIndex].Task;
        }

    public float ScoreAdvertisement(Advertisement action)
        {
            // TODO : placeholder
            float score = 1f;
            for (int i = 0; i < action.Rewards.Count; i++)
            {
                float rewards = action.Rewards[i].Amount;
                score += rewards;
            }

            return score;
        }

    public List<Advertisement> GetAdvertisements()
    {
        return advertisements;
    }
}
