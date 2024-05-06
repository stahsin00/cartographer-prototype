public class ChatInteraction : Interaction
{
    public ChatInteraction() : base()
    {
        Name = "Chat";
        Rewards.Add(new Reward("Social", 5f));
    }

    public override void Execute()
    {
        throw new System.NotImplementedException();
    }
}
