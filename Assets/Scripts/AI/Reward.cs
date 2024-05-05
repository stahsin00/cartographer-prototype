public class Reward
{
    public string NeedType { get; private set; }
    public float Amount { get; private set; }

    public Reward(string needType, float amount)
    {
        NeedType = needType;
        Amount = amount;
    }
}
