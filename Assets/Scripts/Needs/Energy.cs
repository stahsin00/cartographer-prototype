public class Energy : Need
{
    public Energy() {
        Type = "Energy";
        Current = 100f;
    }

    public override void Decay()
    {
        Current -= Current * 0.1f;
    }
}
