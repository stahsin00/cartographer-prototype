public class Thirst : Need
{
    private const float DECAY_RATE = 0.1f;

    public Thirst() {
        Type = "Thirst";
        Current = 100f;
    }

    public override void Decay()
    {
        Current -= DECAY_RATE;
    }
}
