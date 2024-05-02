public class Hunger : Need
{
    private const float DECAY_RATE = 1f;

    public Hunger() {
        Type = "Hunger";
        Current = 100f;
    }

    public override void Decay()
    {
        Current -= DECAY_RATE;
    }
}
